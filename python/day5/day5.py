import math

class Shape:
    perimeter = 0
    area = 0

    def calcArea(self):
        pass
    def calcPerimeter(self):
        pass
    def Print(self):
        print "Area : {0} Perimeter : {1}".format(self.area, self.perimeter)

class Rectangle(Shape):
    x = 0
    y = 0
    def __init__(self, x, y):
        self.x = x
        self.y = y
    def calcArea(self):
        self.area = self.x * self.y
    def calcPerimeter(self):
        self.perimeter = 2 * (self.x + self.y)
class Triangle(Shape):
    len = 0
    def __init__(self, len):
        self.len = len
    def calcArea(self):
        self.area = self.len**2 * math.sqrt(3) / 4
    def calcPerimeter(self):
        self.perimeter = 3 * self.len

class Circle(Shape):
    r = 0
    def __init__(self, r):
        self.r = r
    def calcArea(self):
        self.area = 3.14 * self.r**2
    def calcPerimeter(self):
        self.perimeter = 2 * 3.14 * self.r


rect = Rectangle(3, 5)
rect.calcArea()
rect.calcPerimeter()
rect.Print()

tria = Triangle(5)
tria.calcArea()
tria.calcPerimeter()
tria.Print()

circle = Circle(4)
circle.calcArea()
circle.calcPerimeter()
circle.Print()