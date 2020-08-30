using System;
using Xunit;
using BusinessRuleEngineUI;
using BusinessRuleEngine.Order;

namespace BusinessRuleEngile.Tests
{
    public class OrderHandlerTest
    {
        [Fact]
        public void BookProcessorTest()
        {
            OrderHandler orderHandler = new OrderHandler(ProductType.Book, null);
            bool isSuccess = orderHandler.HandleOrder();

            Assert.True(isSuccess);
        }

        [Fact]
        public void PhysicalProductProcessorTest()
        {
            OrderHandler orderHandler = new OrderHandler(ProductType.PhysicalProduct, null);
            bool isSuccess = orderHandler.HandleOrder();

            Assert.True(isSuccess);
        }

        [Fact]
        public void ExistingMembershipProcessorTest()
        {
            OrderHandler orderHandler = new OrderHandler(ProductType.ExistingMembership,
                ModelBuilder.CreateMembershipProcessorModel(ProductType.ExistingMembership));

            bool isSuccess = orderHandler.HandleOrder();

            Assert.True(isSuccess);
        }

        [Fact]
        public void NewMembershipProcessorTest()
        {
            OrderHandler orderHandler = new OrderHandler(ProductType.NewMembership,
                ModelBuilder.CreateMembershipProcessorModel(ProductType.NewMembership));
            bool isSuccess = orderHandler.HandleOrder();

            Assert.True(isSuccess);
        }

        [Fact]
        public void VideoProcessorTestLearningToSki()
        {
            OrderHandler orderHandler = new OrderHandler(ProductType.Video,
                ModelBuilder.CreateVideoProcessorModel(Constants.LEARNING_TO_SKI));
            bool isSuccess = orderHandler.HandleOrder();

            Assert.True(isSuccess);
        }


        [Fact]
        public void VideoProcessorTestOthers()
        {
            OrderHandler orderHandler = new OrderHandler(ProductType.Video,
                ModelBuilder.CreateVideoProcessorModel("Others"));
            bool isSuccess = orderHandler.HandleOrder();

            Assert.True(isSuccess);
        }
    }
}
