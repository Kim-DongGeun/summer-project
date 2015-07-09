import math

class Shape:
    area = 0
    def calcArea(self):
        pass

class TwoDim(Shape):
    perimeter = 0
    def calcPerimeter(self):
        pass
    def Print(self):
        print "Area : {0} Perimeter : {1}".format(self.area, self.perimeter)

class ThreeDim(Shape):
    volume = 0
    def calcVolume(self):
        pass
    def Print(self):
        print "Area : {0} Perimeter : {1}".format(self.area, self.volume)

class Rectangle(TwoDim):
    x = 0
    y = 0
    def __init__(self, x, y):
        self.x = x
        self.y = y
    def calcArea(self):
        self.area = self.x * self.y
    def calcPerimeter(self):
        self.perimeter = 2 * (self.x + self.y)

class Triangle(TwoDim):
    len = 0
    def __init__(self, len):
        self.len = len
    def calcArea(self):
        self.area = self.len**2 * math.sqrt(3) / 4
    def calcPerimeter(self):
        self.perimeter = 3 * self.len

class Circle(TwoDim):
    r = 0
    def __init__(self, r):
        self.r = r
    def calcArea(self):
        self.area = 3.14 * self.r**2
    def calcPerimeter(self):
        self.perimeter = 2 * 3.14 * self.r

class Sphere(ThreeDim):
    R = 0
    def __init__(self, R):
        self.R = R
    def calcArea(self):
        self.area = 4 * 3.14 * (self.R**2)
    def calcVolume(self):
        self.volume = 4 / 3 * 3.14 * (self.R**3)

class Cube(ThreeDim):
    a = 0
    def __init__(self, a):
        self.a = a
    def calcArea(self):
        self.area = 6 * (self.a**2)
    def calcVolume(self):
        self.volume = self.a**3

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

cube = Cube(3)
cube.calcArea()
cube.calcVolume()
cube.Print()

sphere = Sphere(5)
sphere.calcArea()
sphere.calcVolume()
sphere.Print()