#-*- coding:utf-8 -*-
#파일 입출력 및 예외처리 예제
try:
    name = raw_input()
    R = open(name,'a+')
except IOError:
    print "input content"
    W = open(name,'w')
    W.write(raw_input())
else:
    print R.read()
    print "input content"
    R.write(raw_input())