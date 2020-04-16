import sys, math
# import time
# start_time = time.time()

def is_prime(number: int) -> bool:
   if(number <= 3):
      return number == 2 or number == 3

   if(number % 2 == 0 or number % 3 == 0):
      return False

   sqrt_of_number = min(int(math.sqrt(number)), 12)
   for i in range(5, sqrt_of_number, 6):
      if ((number % i == 0) or (number % (i+2) == 0)):
         return False
   else:      
      return True

file_path = sys.argv[1]
with open(file_path) as inputs:
   for input_data in inputs:   
      print(1 if is_prime(int(input_data)) else 0)

# print("--- %s seconds ---" % (time.time() - start_time))