import json 


def _clean_url(url: str) -> str :
    return url.removeprefix('/')


class RestAPI:
    def __init__(self, database: dict =None):
        self.database = database 
        self.valid_gets = ['users']

    def get(self, url: str, payload: str = None):
        clean_url = _clean_url(url)
        if clean_url not in self.valid_gets:
             raise ValueError(f'Invalid request. GET only accepts the following requests: {self.valid_gets}.')
        if payload:
            payload = json.loads(payload)
            return json.dumps({'users': [self.__get_user(user) for user in payload['users']]})
        else:
            return json.dumps(self.database)
    
    def post(self, url: str, payload: str =None):
        url = _clean_url(url)
        if not payload:
            raise ValueError('Incorrect request. A POST method requires a payload.')
        payload = json.loads(payload)
        if url == 'add':
            return self.__add_user(payload)
        if url == 'iou':
            return self.__add_iou(payload)
        raise ValueError('Incorrect request passed to API. Valid POST methods are add, iou.')
            
    def __get_user(self, user_name) -> str:
        return [user for user in self.database['users'] if user['name'] == user_name][0]

    def __add_user(self, payload: str) -> str:
        users_list = self.database['users']
        new_user = payload['user']
        new_user_entry = {'name': new_user , 'owes': {}, 'owed_by': {}, 'balance': 0.0}
        users_list.append(new_user_entry)
        return json.dumps(new_user_entry)
    
    def __add_iou(self, payload: str) -> str:
        # For the lender, we have to do:
        lender = payload['lender']
        borrower = payload['borrower']
        amount = payload['amount']
        lender_entry = self.__modify_user(lender, borrower, amount, True)
        borrower_entry = self.__modify_user(lender, borrower, amount, False)
        return json.dumps({'users': sorted([lender_entry, borrower_entry], key = lambda x: x['name'])})

    def __modify_user(self, lender: str, borrower: str, amount: float, is_lender: bool) -> str:
        if is_lender:
            user = lender 
            other_guy = borrower
            previous_debt_reference = 'owes' # We wish to verify if the lender user had BORROWED money from the current borrower.
            current_debt_reference = 'owed_by'
        else:
            user = borrower 
            other_guy = lender 
            previous_debt_reference = 'owed_by' # We verify if the current lender had previously lonaed the borrower money.
            current_debt_reference = 'owes'
        user_data = self.__get_user(user)
        if is_lender:
            user_data['balance'] += amount # A new loan increases the lender's balance.
        else:
            user_data['balance'] -= amount # A new loan decreases the borrower's balance. 
        if other_guy in user_data[previous_debt_reference]: # We want to verify if there was a previous debt where the roles were switched.
            previous_debt = user_data[previous_debt_reference][other_guy]
            previous_debt -= amount # Reduce the debt by the new loan
            if previous_debt > 0: # If despite the new loan, there is still some debt left.
                user_data[previous_debt_reference][other_guy] = previous_debt # You update the previous debt.
                return user_data
            else: 
                del user_data[previous_debt_reference][other_guy] # The previous debt is erased
                amount = -1 * previous_debt # The difference between the old debt and the new loan
        current_debt = user_data[current_debt_reference].get(other_guy, 0) # If there was the same type of debt before, we have to increase it!
        total = amount + current_debt
        if total <= 0:
            return user_data
        else:
            user_data[current_debt_reference][other_guy] = total 
            return user_data