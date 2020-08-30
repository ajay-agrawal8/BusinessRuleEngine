using System;
using System.Collections.Generic;
using System.Text;
using BusinessRuleEngine.Order;

namespace BusinessRuleEngineUI
{
    public class OrderHandler
    {
        private ProductType _productType;
        private IOrderProcessorModel _orderProcessorModel;

        public OrderHandler(ProductType productType, IOrderProcessorModel orderProcessorModel)
        {
            _productType = productType;
            _orderProcessorModel = orderProcessorModel;
        }

        public bool HandleOrder()
        {
            bool isSuccess = false;
            try
            {
                IOrderProcessor orderProcessor = OrderProcessorFactory.CreateOrderProcessor(_productType, _orderProcessorModel);

                if (orderProcessor != null)
                {
                    orderProcessor.ProcessOrder();

                    if (orderProcessor is ICommission)
                    {
                        ICommission commission = (ICommission)orderProcessor;
                        commission.GenerateCommission();
                    }
                    if (orderProcessor is IEmailSender)
                    {
                        IEmailSender emailSender = (IEmailSender)orderProcessor;
                        emailSender.SendEmail();
                    }

                    isSuccess = true;
                }

                return isSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some exception occurred");
                throw ex;
            }
        }
    }
}
