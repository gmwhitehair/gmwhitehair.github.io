import random
##"123" anything in quotation marks is a string
##int() changes to int
##str() changes to string
##print(5 + 5) = 10
##print("5" + "5") = 55 means to concatinate
##print("Gabe" * 5) = Gabe Gabe Gabe Gabe Gabe
##print(len("hello world")) prints the length of hello world
##
##word = "hello world"
##print(word[0]) prints "h"
##
##list1 = [1,2,3,4,5]
##list2 = ["a", "b", "c", "d", "e"]
##
##print(list1[4]) prints 5
##
##
##if 5 == 5:
##    print("5 is equal to 5"
##else:
##    print("5 is not equal to itself")
##
##name = "Steven"
##if len(name) > 20:
##    print("Longer than 20 characters")
##else:
##    print("Less than 20 characters")
##
##name = input("Enter your name: ")
##print("hello" + name)
##
##
##i=0
##while i < 6:
##    print(i)
##    i += 1
##

##answer = random.randint(1,10)
##while True:
##    guess = input("Enter a number between 1 and 10: ")
##    guess = int(guess)
##    try: 
##        if guess > answer:
##            print("Too high. Try again.")
##        elif guess < answer:
##            print("Too low. Try again.")
##        else:
##            print("You got it!")
##            break
##    except:
##        print("Invalid input")

##sentance = "Hello, you are looking good today"
##sentance = sentance.split()
##print(sentance)
##
##for word in sentance:
##    print(word)
##
word1 = "hello world"
for nothing in word1:
    print(nothing)

##
##sentence = ("Hello, you are looking *adj today.")
##sentence = sentence.split()
##adj = ["beautiful", "handsome","pretty","warm"]
##
##indexCount = 0
##for word in sentence:
##    if word == "*adj":
##        wordChoice = random.choice(adj)
##        sentence[indexCount] = wordChoice
##    indexCount += 1
##
##sentence = " ".join(sentence)
##print(sentence)
