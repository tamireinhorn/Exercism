from itertools import chain
from functools import partial
import numpy as np 


def comparison(x, y, flag_for_less = 1):
    if flag_for_less == 1:
        return x <= y
    else:
        return y <= x


# def recursion(coins, target, item):
#     if item == 0:
        

def find_fewest_coins(coins: list[int], target: int):
    viable_coins = list(filter(partial(comparison, y = target), coins))
    viable_median = np.median(viable_coins)
    viable_coins = list(filter(partial(comparison, y = viable_median, flag_for_less = 0), viable_coins))
    target_list = [target - coin for coin in viable_coins]
    print(target_list)
    

##Pega todas as moedas abaixo do valor escolhido.
## Calcula a mediana delas
## Seleciona, dentre elas, as acima da mediana. 
## Faça valor - estas moedas, gerando uma nova lista. Se o valor for 0 ou igual a uma moeda, já era.
