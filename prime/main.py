import sys

def is_prime(number: int) -> bool:
   if(number < 2):
      return False
   for i in range(2, number):
      if (number % i == 0):
         return False
   return True

with open(sys.argv[1]) as inputs:
   for input_data in inputs:   
      print(1 if is_prime(int(input_data)) else 0)