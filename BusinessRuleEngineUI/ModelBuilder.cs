using System;
using System.Collections.Generic;
using System.Text;
using BusinessRuleEngine.Order;

namespace BusinessRuleEngineUI
{
    public class ModelBuilder
    {
        public static IOrderProcessorModel CreateVideoProcessorModel(string videoName)
        {
            return new VideoProcessorModel
            {
                VideoName = videoName
            };
        }

        public static IOrderProcessorModel CreateMembershipProcessorModel(ProductType productType)
        {
            MembershipType membershipType = (productType == ProductType.NewMembership ? MembershipType.New : MembershipType.Existing);
            return new MembershipProcessorModel
            {
                MembershipType = membershipType
            };
        }
    }
}
