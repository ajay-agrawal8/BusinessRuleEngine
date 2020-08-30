using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Order
{
    public class MembershipProcessor : IOrderProcessor, IEmailSender
    {
        MembershipProcessorModel _membershipModel;
        public MembershipProcessor(IOrderProcessorModel orderProcessorModel)
        {
            _membershipModel = (MembershipProcessorModel)orderProcessorModel;
        }

        public void ProcessOrder()
        {
            if (MembershipType.New == _membershipModel.MembershipType)
            {
                Console.WriteLine("New membership has been activated.");
            }
            else
            {
                Console.WriteLine("Existing membership has been upgraded.");
            }
        }

        public void SendEmail()
        {
            Console.WriteLine("Email has been sent regarding your payment success.");
        }
    }
}
