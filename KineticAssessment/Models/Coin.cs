using KineticAssessment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticAssessment.Models
{

    public class Coin : ICoin
    {
        public Coin(decimal amount, decimal volume)
        {
            Amount = amount;
            Volume = volume;
        }
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }

}
