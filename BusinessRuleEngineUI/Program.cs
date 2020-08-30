using System;
using BusinessRuleEngine.Order;

namespace BusinessRuleEngineUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the product type to proceed");
            Console.WriteLine("1. Physical Product\n" +
                              "2. Book\n" +
                              "3. Activation of Membership\n" +
                              "4. Upgrading the Existing membership\n" +
                              "5. \"Learning to Ski\" video");

            Console.WriteLine("Press 0 to exit.");

            string enteredValue = Console.ReadLine();

            while (enteredValue != "0")
            {
                if (int.TryParse(enteredValue, out int intResult))
                {
                    if (Enum.IsDefined(typeof(ProductType), intResult))
                    {
                        ProductType productType = (ProductType)intResult;

                        IOrderProcessorModel orderProcessorModel = null;
                        switch (productType)
                        {
                            case ProductType.Video:
                                orderProcessorModel = ModelBuilder.CreateVideoProcessorModel(Constants.LEARNING_TO_SKI);
                                break;
                            case ProductType.NewMembership:
                            case ProductType.ExistingMembership:
                                orderProcessorModel = ModelBuilder.CreateMembershipProcessorModel(productType);
                                break;
                        }

                        OrderHandler orderHandler = new OrderHandler(productType, orderProcessorModel);
                        bool isSuccess = orderHandler.HandleOrder();
                        
                        if (!isSuccess)
                        {
                            Console.WriteLine("Order couldn't be completed due to system issue.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entered value is not a valid product type.");
                    }
                }
                else
                {
                    Console.WriteLine("Entered value is not a number.");
                }
                enteredValue = Console.ReadLine();
            }
        }
    }
}
