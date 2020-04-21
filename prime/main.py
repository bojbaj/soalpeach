import sys, math
# import time
# start_time = time.time()

result = []
cached_primes = []
MAX_PRIME_CHECKED = 100000

def Sieve(n):
   prime = [1 for i in range(n+1)] 

   p = 2
   while(p * p <= n):         
      if (prime[p] == 1): 
         for i in range(p * 2, n + 1, p): 
               prime[i] = 0
      p += 1
   
   return prime

def is_prime(number: int) -> int:
   if (number <= MAX_PRIME_CHECKED):         
      return cached_primes[number]

   if(number <= 3):
      return number == 2 or number == 3

   if(number % 2 == 0 or number % 3 == 0):
      return 0

   sqrt_of_number = min(int(math.sqrt(number)), 12)
   for i in range(5, sqrt_of_number, 6):
      if ((number % i == 0) or (number % (i+2) == 0)):
         return 0
   else:      
      return 1

cached_primes = Sieve(MAX_PRIME_CHECKED) 

file_path = sys.argv[1]
with open(file_path) as inputs:
   for input_data in inputs:        
      result.append(is_prime(int(input_data)))

print('\n'.join(map(str, result))) 
# print("--- %s seconds ---" % (time.time() - start_time))