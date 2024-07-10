using SparkPost.Sharp.Data.Interfaces;
using SparkPost.Sharp.Models;
using SparkPost.Sharp.Services.Abstract;

namespace SparkPost.Sharp.Services
{
    public class SparkPostTransmissionService : SparkPostService
    {
        public SparkPostTransmissionService(ISparkPostConfiguration configuration) : base(configuration)
        {
        }

        public async Task SendMails(TransmissionRequest transmissionRequest) => await Post("/api/v1/transmissions", transmissionRequest);

        public async Task SendMails(string subject, string content, IEnumerable<TransmissionRecipient> recipients, Dictionary<string, object>? metadata = null)
        {
            TransmissionRequest request = new TransmissionRequest()
            {
                Content = new TransmissionContent()
                {
                    From = new TransmissionContentFrom()
                    {
                        Name = SenderName,
                        Email = SenderAddress
                    },
                    Html = content,
                    ReplyTo = ReplyTo,
                    Subject = subject,
                },
                Recipients = recipients.ToList(),
                Metadata = metadata ?? new Dictionary<string, object>(),
            };

            await SendMails(request);
        }
    }
}
