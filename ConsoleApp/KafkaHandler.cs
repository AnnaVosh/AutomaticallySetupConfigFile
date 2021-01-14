using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CustomerHub.SubscriberCDP
{
    public class KafkaHandler
    {
        private readonly IConfiguration _configuration;
        private readonly string _eventMainTopic;
        private readonly string _eventDelayTopic;
        private readonly string _eventRejectTopic;

        public KafkaHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _eventMainTopic = _configuration.GetSection("Kafka").GetValue<string>("EventMainTopicTitle");
            _eventDelayTopic = _configuration.GetSection("Kafka").GetValue<string>("EventDelayTopicTitle");
            _eventRejectTopic = _configuration.GetSection("Kafka").GetValue<string>("EventRejectTopicTitle");
        }
        public Task Start()
        {
            SetupConsumer();           
            return Task.CompletedTask;
        }

        private void SetupConsumer()
        {
            Console.WriteLine($"Main topic: {_eventMainTopic}");
            Console.WriteLine($"Delay topic: {_eventDelayTopic}");
            Console.WriteLine($"Reject topic: {_eventRejectTopic}");
        }
    }
}
