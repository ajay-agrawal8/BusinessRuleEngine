using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Order
{
    public class BookProcessor : IOrderProcessor, ICommission
    {
        public void GenerateCommission()
        {
            Console.WriteLine("Commission has been generated for agent.");
        }

        public void ProcessOrder()
        {
            Console.WriteLine("Duplicate Packing slip has been generated for Royalty dept.");
        }
    }
}
