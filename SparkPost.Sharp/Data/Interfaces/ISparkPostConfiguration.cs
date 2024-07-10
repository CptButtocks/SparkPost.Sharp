namespace SparkPost.Sharp.Data.Interfaces
{
    public interface ISparkPostConfiguration
    {
        string ApiKey { get; }
        string Host { get; }
        string ReplyTo { get; }
        string SenderAddress { get; }
        string SenderName { get; }
    }
}