using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMultiplicationTable.Web.Models.Input
{
    public class PrimeInputModelView
    {
        [Display(Name = "Count of primes")]
        [Range(minimum: 1, maximum: 10000, ErrorMessage = "Count has to be in a range: 1-10000")]
        public int PrimesCount { get; set; }
    }
}
