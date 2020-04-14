import sys

def is_prime(number: int) -> bool:
   if(number < 2):
      return False
   for i in range(2, number):
      if (number % i == 0):
         return False
   return True

fileObject = open(sys.argv[1], 'r')
fileContents = fileObject.readlines()
for number in fileContents:
    print(1 if is_prime(int(number)) else 0)