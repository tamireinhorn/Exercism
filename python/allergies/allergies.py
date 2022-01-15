ALLERGIES_SCORE = {'eggs': 1, 'peanuts': 2, 'shellfish': 4, 'strawberries': 8,
'tomatoes': 16, 'chocolate': 32, 'pollen': 64, 'cats': 128}
SCORE_ALLERGIES = {score: item for item, score in sorted(ALLERGIES_SCORE.items(), key = lambda item: item[1])}

from copy import copy


class Allergies:

    def __init__(self, score):
        self.score = score
        self.lst = self.list_of_allergies()
     

    def allergic_to(self, item):
        return item in self.lst


    def list_of_allergies(self):
        score = self.score # Convert the score to binary. 
        mask = 1 #This mask starts as 0b1, which stands for eggs.
        #The idea is if we do a bitwise AND (&) with a score of, for example, 3, which is 0b11.
        #This will return 0b01, which would be True, that is, you are allergic to eggs.
        allergy_list = []
        for allergen in SCORE_ALLERGIES.items():
            if score < mask:
                break 
            if score & mask : #Bitwise AND can be done in ints!
                allergy_list.append(allergen[1])
            #Shift the bit on the mask to the left for the next allergen
            mask <<= 1
        return allergy_list


    # @property
    # def lst(self):
    #     return self._list_of_allergies
 
    