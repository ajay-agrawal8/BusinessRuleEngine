using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Order
{
    public class MembershipProcessorModel : IOrderProcessorModel
    {
        public MembershipType MembershipType { get; set; }
    }
}
