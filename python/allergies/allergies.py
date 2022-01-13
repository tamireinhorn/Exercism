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
        score = format(self.score, 'b')[::-1]
        allergy_list = []
        for character, allergen in zip(score, SCORE_ALLERGIES.items()):
            if character == '1':
                allergy_list.append(allergen[1])
        return allergy_list


    # @property
    # def lst(self):
    #     return self._list_of_allergies
 
    