from collections import namedtuple


def largest(min_factor, max_factor):
    """Given a range of numbers, find the largest palindromes which
       are products of two numbers within that range.

    :param min_factor: int with a default value of 0
    :param max_factor: int
    :return: tuple of (palindrome, iterable).
             Iterable should contain both factors of the palindrome in an arbitrary order.
    """
    if max_factor < min_factor:
        raise ValueError("min must be <= max")
    Palindrome = namedtuple('Palindrome', 'number factors')
    PalindromeList = []
    #Use two pointers in the range:
    # [1,2,3,4,5,6,7,8,9] 
    # First pointer is at 1, and then we start the second pointer at the same place, but we walk it all over the list.
    # 
    for first_pointer in range(max_factor, min_factor-1, -1):
        for i in range(first_pointer, min_factor-1, -1):
            mult = first_pointer * i 
            if str(mult) == str(mult)[::-1]:
                PalindromeList.append(Palindrome(mult, [first_pointer, i]))
                break    
    max_palindrome = None
    if PalindromeList:
        max_palindrome = max(i.number for i in PalindromeList)
    factors = []
    temp = (i.factors for i in PalindromeList if i.number == max_palindrome)
    list(map(factors.append, temp))
    return max_palindrome, factors


def smallest(min_factor, max_factor):
    """Given a range of numbers, find the smallest palindromes which
    are products of two numbers within that range.

    :param min_factor: int with a default value of 0
    :param max_factor: int
    :return: tuple of (palindrome, iterable).
    Iterable should contain both factors of the palindrome in an arbitrary order.
    """
    if max_factor < min_factor:
        raise ValueError("min must be <= max")
    Palindrome = namedtuple('Palindrome', 'number factors')
    PalindromeList = []
    #Use two pointers in the range:
    # [1,2,3,4,5,6,7,8,9] 
    # First pointer is at 1, and then we start the second pointer at the same place, but we walk it all over the list.
    # 
    first_pointer = min_factor
    for first_pointer in range(min_factor, max_factor):
        for i in range(first_pointer, max_factor+1):
            mult = first_pointer * i 
            if str(mult) == str(mult)[::-1]:
                PalindromeList.append(Palindrome(mult, [first_pointer, i]))
                break    
    min_palindrome = None
    if PalindromeList:
        min_palindrome = min(i.number for i in PalindromeList)
    factors = []
    temp = (i.factors for i in PalindromeList if i.number == min_palindrome)
    list(map(factors.append, temp))
    return min_palindrome, factors