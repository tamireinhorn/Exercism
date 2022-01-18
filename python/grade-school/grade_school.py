import itertools
from collections import defaultdict

class School:
    def __init__(self):
        self._roster = []
        self._added = []
        self._grades = defaultdict(lambda: [])

    def add_student(self, name, grade):
        if name in self._roster:
            self._added.append(False)
        else:
            self._grades[grade].append(name)
            self._grades[grade] = sorted(self._grades[grade])
            self._added.append(True)
            self._roster.append(name)

    def added(self):
        return self._added

    def roster(self):
        self._roster = list(itertools.chain.from_iterable([self._grades[grade] for grade in sorted(self._grades)]))
        return self._roster

    def grade(self, grade_number):
        return self._grades.get(grade_number, list())
