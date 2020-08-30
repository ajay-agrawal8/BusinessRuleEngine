using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Order
{
    public class VideoProcessor : IOrderProcessor
    {
        VideoProcessorModel _videoProcessorModel;

        public VideoProcessor(IOrderProcessorModel orderProcessorModel)
        {
            _videoProcessorModel = (VideoProcessorModel)orderProcessorModel;

        }

        public void ProcessOrder()
        {
            if (_videoProcessorModel.VideoName == "Learning to Ski")
            {
                Console.WriteLine("Your free video \"First Aid\" has been added in packing slip and it has been generated.");
            }
            else
            {
                Console.WriteLine("Packing slip has been generated.");
            }
        }
    }
}
