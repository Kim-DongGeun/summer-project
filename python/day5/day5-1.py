import math
class Fraction:
    numerator = 0
    denominator = 0

    def __init__(self, numerator, denominator):
        self.numerator = numerator
        self.denominator = denominator

    def __add__(self, other):
        a = self.numerator*other.denominator + self.denominator*other.numerator
        b = self.denominator*other.denominator
        while (b != 0):
            c = b
            b = a%b
            a = c
        return "{0}/{1}".format((self.numerator*other.denominator + self.denominator*other.numerator)/a, (self.denominator*other.denominator)/a)
    def __sub__(self, other):
        a = math.fabs(self.numerator*other.denominator - self.denominator*other.numerator)
        b = self.denominator*other.denominator
        while (b != 0):
            c = b
            b = a%b
            a = c
        if self.numerator*other.denominator - self.denominator*other.numerator < 0:
            return "-{0}/{1}".format(int((math.fabs(self.numerator*other.denominator - self.denominator*other.numerator))/a), int((self.denominator*other.denominator)/a))
        elif self.numerator*other.denominator - self.denominator*other.numerator > 0:
            return "{0}/{1}".format(int((math.fabs(self.numerator*other.denominator - self.denominator*other.numerator))/a), int((self.denominator*other.denominator)/a))
    def __mul__(self, other):
        a = self.numerator*other.numerator
        b = self.denominator*other.denominator
        while (b != 0):
            c = b
            b = a%b
            a = c
        return "{0}/{1}".format(int(self.numerator*other.numerator)/a, int(self.denominator*other.denominator)/a)
    def __div__(self, other):
        a = self.numerator * other.denominator
        b = self.denominator * other.numerator
        while (b != 0):
            c = b
            b = a%b
            a = c
        return "{0}/{1}".format((self.numerator*other.denominator)/a, (self.denominator*other.numerator)/a)

frac1 = Fraction(3,4)
frac2 = Fraction(6,9)

print "{0}/{1} + {2}/{3} = {4}".format(frac1.numerator, frac1.denominator, frac2.numerator, frac2.denominator, frac1+frac2)
print "{0}/{1} - {2}/{3} = {4}".format(frac1.numerator, frac1.denominator, frac2.numerator, frac2.denominator, frac1-frac2)
print "{0}/{1} * {2}/{3} = {4}".format(frac1.numerator, frac1.denominator, frac2.numerator, frac2.denominator, frac1*frac2)
print "{0}/{1} / {2}/{3} = {4}".format(frac1.numerator, frac1.denominator, frac2.numerator, frac2.denominator, frac1/frac2)
