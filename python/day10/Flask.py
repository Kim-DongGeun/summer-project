#-*- coding:utf-8 -*-
from flask import Flask, render_template, redirect
from flaskext.mysql import MySQL


mysql = MySQL()
app = Flask(__name__)
app.config['MYSQL_DATABASE_USER'] = 'serverstudy'
app.config['MYSQL_DATABASE_PASSWORD'] = 'serverstudy!@#'
app.config['MYSQL_DATABASE_DB'] = 'serverstudy'
app.config['MYSQL_DATABASE_HOST'] = 'data.khuhacker.com'
app.config['MYSQL_CHARSET'] = 'utf-8'
mysql.init_app(app)

@app.route('/userlist/')
def showUsers():
    cur = mysql.connect().cursor()
    cur.execute('SELECT * FROM KDG_users')
    data = cur.fetchall()
    cur.close()
    output = ""

    for user in data:
        output += "Num : %s, Name : %s, Content : %s<br>"%(user[0], user[1], user[2])
    return output

@app.route('/adduser/<Name>/<Content>')
def addUser(Name, Content):
    con = mysql.connect()
    cur = con.cursor()
    cur.execute('INSERT INTO KDG_users (name, content) VALUES (%s, %s)',(Name, Content))
    con.commit()
    cur.close()
    return redirect('/userlist')

'''@app.route('/index')
@app.route('/index/<name>')
def hello_world(name=''):
    return render_template('hello.html', username=name)

@app.route('/sum/<int:num1>/<int:num2>')
def sum(num1,num2):
    return str(num1+num2)'''

if __name__ == '__main__':
    app.run()
