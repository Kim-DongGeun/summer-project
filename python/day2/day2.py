#a = raw_input()

#for i in range(1,10):
   #print a + " x " + str(i) + " = " + str(int(a)*i)


import random

while (1):
    a = (random.randint(1, 9), random.randint(1, 9), random.randint(1, 9))
    if a[0] is not a[1] and a[0] is not a[2] and a[1] is not a[2]:
        break
print a
while (1):
    ball = 0
    strike = 0
    while(1):
        print "input three int number (1~9)"
        b = [input(), input(), input()]
        if b[0] is not b[1] and b[0] is not b[2] and b[1] is not b[2]:
            break
        else:
            print "Re input"

    if a[0] is b[0] and a[1] is b[1] and a[2] is b[2]:
        print "answer!"
        break
    for i in [0, 1, 2]:
        if a[i] is b[0] or a[i] is b[1] or a[i] is b[2]:
            if a[i] is b[i]:
                strike += 1
            else:
                ball += 1
    if ball is 0 and strike is not 0:
        print str(strike) + " strike"
    elif strike is 0 and ball is not 0:
        print str(ball) + " ball"
    elif ball is 0 and strike is 0:
        print "0 strike 0 ball"
    else:
        print str(ball) + " ball " + str(strike) + " strike"





