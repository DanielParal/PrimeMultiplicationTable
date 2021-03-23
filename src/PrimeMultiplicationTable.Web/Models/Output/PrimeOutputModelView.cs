using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMultiplicationTable.Web.Models.Output
{
    public class PrimeOutputModelView
    {
        public string ErrorMessage { get; set; }
        public int InputValue { get; set; }
        public List<int> AxisXPrimeNumbers { get; set; }
        public List<int> AxisYPrimeNumbers => new List<int>(AxisXPrimeNumbers);

        public PrimeOutputModelView()
        {
            AxisXPrimeNumbers = new List<int>();
        }
    }
}
