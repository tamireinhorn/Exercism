from copy import copy
def aux(x):
    ans = []
    if isinstance(x, list):
        for element in x:
            
    for element in x:
        if not isinstance(element, list):
            ans.append(element)
    return ans
def flatten(iterable):
    answer = []
    for element in iterable:
        print(element)
        answer.append(aux(element))
    print(answer)


input_1 = [1, [2, 3, 4, 5, 6, 7], 8]
print(aux(input_1))           
flatten(input_1)


#Think about it in pseudocode I guess
#You walk over the list.
#If the element is not a list, you append it to the answer.
#If the element is a list, you need to iterate over it. Rinse and repeat

