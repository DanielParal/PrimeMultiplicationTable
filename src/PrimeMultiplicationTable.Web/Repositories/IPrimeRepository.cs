using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMultiplicationTable.Web.Repositories
{
    public interface IPrimeRepository
    {
        public bool IsPrime(int inputNumber);
        public List<int> GetPrimesList(int countOfPrimes);
    }
}
