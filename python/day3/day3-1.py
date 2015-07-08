Sub = open("subject.txt",'r')
User = open("user.txt", 'r')
user1 = []
user2 = []
user3 = []
user4 = []
user = [user1, user2, user3, user4]
subject = {}

for j in range(0,4):
    value = ''
    B = User.readline()
    for i in B:
        if i == ' ' or i == '\n':
            user[j].append(value)
            value = ''
            continue
        if i == '\n':
            pass
        else:
            value += i
while 1:
    count = 0
    key = ''
    value = ''
    B = Sub.readline()
    if B == '':
        break
    for i in B:
        if i == ' ':
            count = 1
            continue
        if count % 2 == 0:
            key += i
        elif (count % 2 == 1) and (i != '\n'):
            value += i
        elif i == '\n':
            subject[key] = value
while 1:
    print "1 - show total list\n2 - apply\n3 - delete subject\n4 - show subject list\n5 - end"
    a = input()
    if a == 1:#show total list
        print "subject name/subject number"
        for i in subject.keys():
            print i + ' / ' + subject[i]
    elif a == 2:#apply
        print "input user name and subject number"
        b = raw_input()
        c = raw_input()
        hold = 0
        for i in user:
            if (b in i) and (c in i):
                print "already exist"
                hold = 1
                break
            if (c in subject.values()) and (b in i):
                i.insert(1, c)
                hold = 1
                break
        if hold == 0:
            print "Not Found"
    elif a == 3:#delete
        print "input user name and subject number"
        d = raw_input()
        e = raw_input()
        hold = 0
        for i in user:
            if (e in subject.values()) and (d in i):
                i.remove(e)
                hold = 1
                break
        if hold == 0:
            print "Not Found"
    elif a == 4:#show applied list
        print "input user name"
        f = raw_input()
        for i in user:
            if f in i:
                print "user name : " + f
                for j in i:
                    for k in subject.items():
                        if j in k[1]:
                            print "subject name / number " + str(k)
    elif a == 5:#end
        input = open("user.txt",'w')
        for i in user:
            for j in i:
                input.write(j + ' ')
            input.write('\n')
        break