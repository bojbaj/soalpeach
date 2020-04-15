import sys
import math

def is_prime(number):
   if(number < 2):
      return False

   if(number == 2):
      return True

   if(number % 2 == 0):
      return False

   sqrt_of_number = math.floor(math.sqrt(number)) 
   for i in range(3, sqrt_of_number + 1, 2):
      if (number % i == 0):
         return False
   return True

with open(sys.argv[1]) as inputs:
   for input_data in inputs:         
      print(1 if is_prime(int(input_data)) else 0)