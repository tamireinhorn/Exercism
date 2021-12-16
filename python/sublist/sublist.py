"""
This exercise stub and the test suite contain several enumerated constants.

Since Python 2 does not have the enum module, the idiomatic way to write
enumerated constants has traditionally been a NAME assigned to an arbitrary,
but unique value. An integer is traditionally used because it’s memory
efficient.
It is a common practice to export both constants and functions that work with
those constants (ex. the constants in the os, subprocess and re modules).

You can learn more here: https://en.wikipedia.org/wiki/Enumerated_type
"""
from copy import copy
from collections import Counter
# Possible sublist categories.
# Change the values as you see fit.
SUBLIST = -1
SUPERLIST = 1
EQUAL = 0
UNEQUAL = -2


def sublist(list_one, list_two):
    if len(list_one) > len(list_two):
        big_list = list_one
        small_list = list_two
    else:
        big_list = list_two
        small_list = list_one
    big_list_counter = Counter(big_list)
    small_list_counter = Counter(small_list)
    print('2')
            
