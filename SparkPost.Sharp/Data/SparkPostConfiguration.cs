using SparkPost.Sharp.Data.Interfaces;

namespace SparkPost.Sharp.Data
{
    public class SparkPostConfiguration : ISparkPostConfiguration
    {
        private readonly string _senderAddress;
        private readonly string _apiKey;
        private readonly string _host;
        private readonly string _senderName;
        private readonly string _replyTo;

        public string SenderAddress => _senderAddress;
        public string ApiKey => _apiKey;
        public string Host => _host;
        public string SenderName => _senderName;
        public string ReplyTo => _replyTo;

        public SparkPostConfiguration(string senderAddress, string apiKey, string host, string senderName, string replyTo)
        {
            _senderAddress = senderAddress;
            _apiKey = apiKey;
            _host = host;
            _senderName = senderName;
            _replyTo = replyTo;
        }
    }
}
