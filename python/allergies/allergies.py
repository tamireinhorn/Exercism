ALLERGIES_SCORE = {'eggs': 1, 'peanuts': 2, 'shellfish': 4, 'strawberries': 8,
'tomatoes': 16, 'chocolate': 32, 'pollen': 64, 'cats': 128}
SCORE_ALLERGIES = {score: item for item, score in sorted(ALLERGIES_SCORE.items(), key = lambda item: item[1], reverse= True)}

from copy import copy


class Allergies:

    def __init__(self, score):
        self.score = score
        self.lst = self.list_of_allergies()
     

    def allergic_to(self, item):
        return item in self.lst


    def list_of_allergies(self):
        score = self.score 
        allergy_list = []
        score_allergies = copy(SCORE_ALLERGIES)
        a_score = score_allergies.get(score, -1)
        #If the score is EXACTLY one allergen, it's done.
        if a_score != -1:
            allergy_list.append(a_score)
            return allergy_list
        #If the score is odd, then 'eggs' are an allergen for sure.
        if score % 2 != 0:
            allergy_list.append(score_allergies[1])
            del score_allergies[1]
            score -= 1
        #Now, we loop over the biggest items and go adding the allergies.
        for allergen_score, item in score_allergies.items():
            diff = score - allergen_score
            #Our dict is incomplete.
            #Therefore, if we have still 256 of allergic score and nothing on the dict
            #We KNOW that if 2 is in 256, the remanining 254 won't fit!
            # So if we are on the last item (which has the smallest value)
            # And score - allergen_score will have SOMETHING left but will be too small for the next allergen: STOP.
            
            if allergen_score == min(score_allergies) and 0 < diff < max(score_allergies) * 2:
                break
            if diff >= 0:
                score -= allergen_score
                allergy_list.append(item)
            #We stop when we run out of 'allergic score'  
            if score <= 0:
                break
        return allergy_list


    # @property
    # def lst(self):
    #     return self._list_of_allergies
 
    