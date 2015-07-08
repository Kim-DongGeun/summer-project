refrigerator = {}
A = open("refrigerator.txt", 'r')
def add(d,e):
    if d in refrigerator.keys():
        refrigerator[d] += e
    else:
        refrigerator[d] = e
def delete(d, e):
    if d in refrigerator:
        if refrigerator[d] < e:
            print "exceed number"
        elif refrigerator[d] > e:
            refrigerator[d] -= e
        else:
            del refrigerator[d]
def show():
    print refrigerator

while 1:
    count = 0
    key = ''
    value = 0
    B = A.readline()
    if B == '':
        break
    for i in B:
        if i == ' ':
            count += 1
        elif i == '\n':
            pass
        if count % 2 == 0:
            key += i
        elif (count % 2 == 1) and (i != '\n') and (i != ' '):
            value = i
            refrigerator[key] = int(value)
while 1:
    print "select option < add, del, list, end> "
    a = raw_input()
    if a == "add":
        print "input goods and number"
        b = raw_input()
        c = input()
        add(b,c)
    elif a == "del":
        print "input goods and number"
        b = raw_input()
        c = input()
        delete(b, c)
    elif a == "list":
        show()
    elif a == "end":
        C = open("refrigerator.txt", 'w')
        for i in refrigerator.keys():
            C.write(i + ' ' + str(refrigerator[i]) + "\n")
        break

