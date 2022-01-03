import re
from collections import defaultdict


def is_positive(x):
    if x > 0:
        return 1
    else:
        return 0 

is_not_positive = lambda x: 1 - x
class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __eq__(self, other):
        return self.x == other.x and self.y == other.y

class WordSearch:
    def __init__(self, puzzle):
        self.puzzle = puzzle
        self.rows = len(puzzle)
        self.columns = len(puzzle[0])
    def search(self, word):
        rows = self.rows
        puzzle = self.puzzle
        reversed_word = word[::-1]
        for index, row in enumerate(puzzle):
                match = re.search(word, row)
                reverse_match = re.search(reversed_word, row)
                if match:
                    a = Point(match.start(), index)
                    b = Point(match.end()-1, index)
                    return a, b
                elif reverse_match:
                    a = Point(reverse_match.start(), index)
                    b = Point(reverse_match.end() - 1, index)
                    return b, a
        columns = [''.join([puzzle[row][column] for row in range(rows)]) for column in range(self.columns)]
        for index, column in enumerate(columns):
            match = re.search(word, column)
            reverse_match = re.search(reversed_word, column)
            if match:
                a = Point(index, match.start())
                b = Point(index, match.end()-1)
                return a,b
            elif reverse_match:
                a = Point(index, reverse_match.start())
                b = Point(index, reverse_match.end() - 1)
                return b, a
        matrix =[list(row) for row in puzzle]
        diagonal1 = defaultdict(list) # For the top right to bottom left
        diagonal2 = defaultdict(list) # For the top left to bottom right
        for i in range(rows):
            for j in range(rows):
                diagonal1[i-j].append(matrix[i][j])
                diagonal2[i+j].append(matrix[i][j])
        diagonal1 = {item[0]: ''.join(item[1]) for item in diagonal1.items()}
        #These diagonals follow this pattern:
        #If it's 0, it starts at (0,0), adding (1, 1)
        # If it's positive, let i be the index of the diagonal.
        # Since the POSITIVE diagonals are the ones UNDER the main one, they start at (0, i)
        # They grow adding (1,1)
        # The negative ones are ABOVE the main one, and start at (-i, 0).
        # All you do is get its beggining and add (i,i) * match.start()
        # The end position is its and add (i,i) * match.end() - 1
        diagonal2 = {item[0] - (rows -1) : ''.join(item[1]) for item in diagonal2.items()}
        # These diagonals always add (-1, 1).
        # As before, 0 is the main one, now starting at (n-1, 0)
        # Positive ones are under the main one, starting at (n-1, i)
        # Negative ones are above the main one, starting at (n-1 +i, 0)
        for key, diagonal in diagonal1.items():
            match = re.search(word, diagonal)
            reverse_match = re.search(reversed_word, diagonal)
            f = is_positive(key)
            g = is_not_positive(f)
            if match:
                a = Point(-(key * g) + match.start(),(key * f)  + match.start())
                b = Point(-(key * g) + match.end() -1,(key * f) +  match.end() - 1)
                return a, b
            if reverse_match:
                a = Point(-(key * g) + reverse_match.start(), (key * f ) + reverse_match.start())
                b = Point(-(key * g) + reverse_match.end()-1, ( key * f ) + reverse_match.end() - 1)
                return b, a
        for key, diagonal in diagonal2.items():
            match = re.search(word, diagonal)
            reverse_match = re.search(reversed_word, diagonal)
            f = is_positive(key)
            g = is_not_positive(f)
            if match:
                a = Point(rows - 1 - (key * g) - match.start(), (key * f) + match.start())
                b = Point(rows -1 - (key * g) - (match.end() -1), (key * f) + match.end() -1)
                return a,b
            elif reverse_match:
                a = Point(rows - 1 + (key * g) - reverse_match.start(), (key * f ) + reverse_match.start())
                b = Point(rows - 1 + (key * g) - (reverse_match.end() -1), (key * f) + reverse_match.end() - 1)
                return b, a
        