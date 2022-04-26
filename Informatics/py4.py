##sentence = "Hello, you are looking good today."
##sentence = sentence.split()
##print(sentence)
##
##sentence[4] = "striking"
##print(sentence)
##
##sen2 = "Hi my name is Gabe"
##sen2 = sen2.split()
##print(sen2)
##sen2[4] = input("New name: ")
##
##print(sen2)


##sentence = "Hello, you are looking good today."
##sentence = sentence.split()
##
##for word in sentence:
##    print(word)

import random

sentence = "The weather is very *adj in *noun today."
sentence = sentence.split()
adjectives = ["nice", "warm", "cold", "rainy", "snowy"]
nouns = ["Kansas","Indiana","Bloomington","Overland Park"]
indexCount = 0
for word in sentence:
    if "*adj" in word:
        wordChoice = random.choice(adjectives)
        sentence[indexCount] = wordChoice
    if "*noun" in word:
        wordChoice2 = random.choice(nouns)
        sentence[indexCount] = wordChoice2
    indexCount += 1
sentence = " ".join(sentence)
print(sentence)
