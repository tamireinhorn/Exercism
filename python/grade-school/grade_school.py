from itertools import chain
import itertools


class School:
    def __init__(self):
        self._roster = list()
        self._added = list()
        self._grades = dict()

    def add_student(self, name, grade):
        if self._grades.get(grade, -1) == -1:
            self._grades[grade]  = list()
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
        self._roster = list(itertools.chain.from_iterable([item[1] for item in sorted(self._grades.items(), key = lambda item: item[0])]))
        return self._roster

    def grade(self, grade_number):
        return self._grades.get(grade_number, list())
