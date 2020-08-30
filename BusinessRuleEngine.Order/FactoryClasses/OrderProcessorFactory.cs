using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Order
{
    public class OrderProcessorFactory
    {
        public static IOrderProcessor CreateOrderProcessor(ProductType productType, IOrderProcessorModel orderProcessorModel)
        {
            IOrderProcessor orderProcessor = null;
            switch (productType)
            {
                case ProductType.Book:
                    orderProcessor = new BookProcessor();
                    break;
                case ProductType.PhysicalProduct:
                    orderProcessor = new PhysicalProductProcessor();
                    break;
                case ProductType.ExistingMembership:
                case ProductType.NewMembership:
                    orderProcessor = new MembershipProcessor(orderProcessorModel);
                    break;
                case ProductType.Video:
                    orderProcessor = new VideoProcessor(orderProcessorModel);
                    break;
            }
            return orderProcessor;
        }
    }
}
