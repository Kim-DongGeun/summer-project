subA = raw_input()
a = input()
subB = raw_input()
b = input()
subC = raw_input()
c = input()
aver = (a + b + c) / 3.0
sum = a+ b + c

sum = "Total score " + str(sum)
aver = "Aver " + str(round(aver, 3))
subA = subA + ' ' + str(a)
subB = subB + ' ' + str(b)
subC = subC + ' ' + str(c)

print subA + "\n" + subB + "\n" + subC
print sum + "\n" + aver
