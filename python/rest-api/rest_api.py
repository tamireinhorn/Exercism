import json 

def _clean_url(url):
    return url[1:]

class RestAPI:
    def __init__(self, database=None):
        self.database = database 

    def get(self, url, payload=None):
        clean_url = _clean_url(url)
        if payload:
            payload = json.loads(payload)
        else: 
            return json.dumps(self.database)
        if clean_url == 'users':
            return json.dumps({'users': [self.__get_user(user) for user in payload.get('users')]})
        else:
            raise ValueError('Invalid request. GET only accepts users as a request.')
    
    def post(self, url, payload=None):
        url = _clean_url(url)
        if not payload:
            raise ValueError('Incorrect request. A POST method requires a payload.')
        payload = json.loads(payload)
        if url == 'add':
            return self.__add_user(payload)
        if url == 'iou':
            return self.__add_iou(payload)
        else:
            raise ValueError('Incorrect request passed to API. Valid POST methods are add, iou.')
            
    def __get_user(self, user_name):
        return [user for user in self.database['users'] if user['name'] == user_name][0]

    def __add_user(self, payload):
        users_list = self.database.get('users')
        new_user = payload.get('user')
        ob = {"name": f"{new_user}" , "owes": {}, "owed_by": {}, "balance": 0.0}
        users_list.append(ob)
        return json.dumps(ob)
    
    def __add_iou(self, payload):
        # For the lender, we have to do:
        lender = payload.get('lender')
        borrower = payload.get('borrower')
        amount = payload.get('amount')
        lender_dict = self.__modify_borrower(lender, borrower, amount)
        borrower_dict = self.__modify_lender(lender, borrower, amount)
        return json.dumps({'users': sorted([lender_dict, borrower_dict], key = lambda x: x['name'])})

    def __modify_lender(self, lender, borrower, amount):
        lender_dict = self.__get_user(lender)
        lender_dict['balance'] += amount
        # If the lender already owes to the borrower:
        if borrower in lender_dict['owes']:
            # Reduce his debt
            value_owed_to_borrower = lender_dict['owes'][borrower] #Get how much he owed to the borrower. 
            # This value should be reduced by the current loan
            value_owed_to_borrower -= amount # Reduce the debt
            if value_owed_to_borrower > 0: # If there is still some debt left, you update it and changed who you're owed by.
                lender_dict['owes'][borrower] = value_owed_to_borrower
                return lender_dict  
            else: # If this new loan cleared your previous debt
                del lender_dict['owes'][borrower]
                amount = -1 * value_owed_to_borrower # Now we get the difference of the old debt and the new loan 
        value_owed_by_borrower = lender_dict['owed_by'].get(borrower, 0)
        total = amount + value_owed_by_borrower
        if total <= 0: # If what the borrower previously owed us + the new value is not a debt, we end the call
            return lender_dict
        else:
            lender_dict['owed_by'][borrower] = total
            return lender_dict
    
    def __modify_borrower(self, lender, borrower, amount):
        borrower_dict = self.__get_user(borrower)
        borrower_dict['balance'] -= amount 
        # If the borrower had already loaned to the lender:
        if lender in borrower_dict['owed_by']:
            value_owned_by_lender = borrower_dict['owed_by'][lender]
            value_owned_by_lender -= amount # Reduce the previous debt
            if value_owned_by_lender > 0: # If there is still some debt left, you don't change how much you owe. 
                borrower_dict['owed_by'][lender] = value_owned_by_lender # Update the database and reduce the debt
                return borrower_dict
            else: 
                del borrower_dict['owed_by'][lender] # The debt is erased. 
                amount = -1 * value_owned_by_lender # Hence, the difference between how much he owed you and how much you got is now your debt.
        value_owed_to_lender = borrower_dict['owes'].get(lender, 0)
        total = amount + value_owed_to_lender
        if total <= 0:
            return borrower_dict
        else:
            borrower_dict['owes'][lender] = total
            return borrower_dict
