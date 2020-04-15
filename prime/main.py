import sys
import math

def is_prime(number):
   if(number <= 3):
      return number == 2 or number == 3

   if(number % 2 == 0 or number % 3 == 0):
      return False

   sqrt_of_number = math.floor(math.sqrt(number)) 
   for i in range(5, sqrt_of_number, 6):
      if ((number % i == 0) or (number % (i+2) == 0)):
         return False
   return True

with open(sys.argv[1]) as inputs:
   for input_data in inputs:         
      print(1 if is_prime(int(input_data)) else 0)