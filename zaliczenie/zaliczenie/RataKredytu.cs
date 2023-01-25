using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaliczenie
{

    internal class RataKredytu
    {

        
        public double loanAmount { get; set; }
        public double interest { get; set; }
        public double numberOfYears { get; set; }
        public double paymentAmountG { get; internal set; }

        double rateOfInterest;
        double numberOfPayments;

        internal double paymentAmount;
        internal double interestG;

        public RataKredytu()
        {
            rateOfInterest = interest / 1200;
            numberOfPayments = (numberOfYears * 12);

        // loan amount = (interest rate * loan amount) / (1 - (1 + interest rate)^(number of payments * -1))
        paymentAmount = ((int)((rateOfInterest * loanAmount) / (1 - Math.Pow(1 + rateOfInterest, numberOfPayments * -1))));

        }

        
        
            
        
    }

   
}
