from copy import copy
def return_smallest_list(list1, list2):
    if len(list1) < len(list2):
        return list1
    else:
        return list2
def coin_recursion(coins: list[int], target:int, current_change: list[int]):
    # Base case for recursion: target is directly a value in coins
    if target in coins:
        current_change.append(target)
        return current_change
    # If it's not, we gotta recurse.
    # Generate a list of viable coins.
    possible_coins = [coin for coin in coins if coin <= target]
    counter = [0 for i in range(target*10)]
    print(2)
    for coin in possible_coins:
        new_change = copy(current_change)
        new_change.append(coin)
        eval = coin_recursion(coins, target - coin, new_change)
        counter = return_smallest_list(eval, counter)
    return counter


def find_fewest_coins(coins: list[int], target: int):
    current_change = []
    if target < 0:
        raise ValueError("target can't be negative")
    return coin_recursion(coins, target, current_change)
    

##Pega todas as moedas abaixo do valor escolhido.
## Calcula a mediana delas
## Seleciona, dentre elas, as acima da mediana. 
## Faça valor - estas moedas, gerando uma nova lista. Se o valor for 0 ou igual a uma moeda, já era.
