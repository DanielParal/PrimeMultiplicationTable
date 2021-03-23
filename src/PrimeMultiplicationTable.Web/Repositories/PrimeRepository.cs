using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMultiplicationTable.Web.Repositories
{
    public class PrimeRepository : IPrimeRepository
    {
        public List<int> GetPrimesList(int countOfPrimes)
        {
            List<int> primesToReturn = new List<int>();

            int numberToProccess = 0;
            while (primesToReturn.Count < countOfPrimes)
            {
                if (IsPrime(numberToProccess))
                    primesToReturn.Add(numberToProccess);

                numberToProccess++;
            }

            return primesToReturn;
        }

        public bool IsPrime(int n)
        {
            // if number is less then or equel to 1 -> not a prime number
            if (n <= 1)
                return false;

            // 2 and 3 are primes numbers
            if (n == 2 || n == 3)
                return true;

            // if number is divisible by 2 or 3 -> not a prime number
            if ((n % 2 == 0) || (n % 3 == 0))
                return false;

            // no need to loop through till N -> Math.Sqrt(N)
            // (6k +- 1) -> Prime number
            for (int i = 5; i <= Math.Sqrt(n); i += 6)
            {
                if ((n % i == 0) || (n % (i + 2) == 0))
                    return false;
            }

            return true;
        }
    }
}
