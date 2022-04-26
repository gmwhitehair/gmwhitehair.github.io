import random

##userInput = input("Enter number between 1 and 100: ")

##name = input("Enter your name: ")
##print("Hello " + name)


##n1 = input("N1: ")
##n2 = input("N2: ")
##
##try:
##    print(int(n1) + int(n2))
##except:
##    print("NaN")

##tabs and colons matter, don't add semi colons like in java!

##i = 1
##
##while i<= 5:
##    print(i)
##    i = i + 1
##
##    
##i = 1
##
##while i<= 100:
##    print(i)
##    i = i + 1

##while True:
##    a = input("Please enter a number: ")
##    b = input("Please enter another number: ")
##
##    try:
##        print(int(a) + int(b))
##        break
##    except:
##        print("One of those is not a number")

##IMPORTANT!!!:
##
##answer = 12
##
##while True:
##    guess = input("Enter a num from 10-20: ")
##    try:
##        guess = int(guess)
##        if guess > answer:
##            print("Too high")
##        elif guess < answer:
##            print("Too low")
##        else:
##            print("Correct")
##            break
##    except:
##        print("NaN")
##



##answer = random.randint(10,13)
##
##while True:
##    guess = input("Enter a num from 10-13: " )
##    try:
##        guess = int(guess)
##        if guess > answer:
##            print("Too high")
##        elif guess < answer:
##            print("Too low")
##        else:
##            print("Correct")
##            break
##    except:
##        print("NaN")


##colorsList = ["black", "brown", "orange", "green", "blue", "purple", "yellow"]
##myColor = random.choice(colorsList)
##print(myColor)
##
##
##colorsList2 = ["black", "brown", "orange", "green", "blue", "purple", "yellow"]
##colorsList2.remove("orange")
##print(colorsList2)


##colorsList = ["black", "brown", "orange", "green", "blue", "purple", "yellow"]
##while colorsList:
##    myColor = random.choice(colorsList)
##    print(myColor)
##    colorsList.remove(myColor)


##randomizing: random.choice(List) random.randint(10,1)
##removing from list: colorsList.remove(guess)

numbers = [1,2,3,4,5,6,7,8,9,10]
correctNumber = random.choice(numbers)

while True:
    print(numbers)
    guess = input("Guess a number from the numbers remaining: ")
    try:
        guess = int(guess)
        if guess != correctNumber:
            print(str(guess) + " is not the right answer. Try again.")
            numbers.remove(guess)
        else:
            print(str(guess) + " is the correct answer. Good job mate.")
            break
    except:
        print("Value entered is not a number or not in list. Try again.")
 







        
