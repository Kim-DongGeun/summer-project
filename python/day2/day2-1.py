refrigerator = {}
while 1:
    print "select option < add, del, list, end> "
    a = raw_input()
    if a == "add":
        print "input goods and number"
        b = raw_input()
        c = input()
        if b in refrigerator.keys():
            refrigerator[b] += c
        else:
            refrigerator[b] = c
    elif a == "del":
        print "input goods and number"
        b = raw_input()
        c = input()
        if b in refrigerator:
            if refrigerator[b] < c:
                print "exceed number"
                continue
            elif refrigerator[b] > c:
                refrigerator[b] -= c
            else:
                del refrigerator[b]
    elif a == "list":
        print refrigerator
    elif a == "end":
        break
