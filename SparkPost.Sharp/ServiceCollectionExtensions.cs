using Microsoft.Extensions.DependencyInjection;
using SparkPost.Sharp.Data;
using SparkPost.Sharp.Data.Interfaces;

namespace SparkPost.Sharp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSparkPost(this IServiceCollection services, string apiKey, string host, string senderName, string senderAddress, string replyTo)
        {
            services.AddSingleton<ISparkPostConfiguration>(c => new SparkPostConfiguration(senderAddress, apiKey, host, senderName, replyTo));
            services.AddSparkPost();
            return services;
        }

        public static IServiceCollection AddSparkPost<TConfig>(this IServiceCollection services) where TConfig : class, ISparkPostConfiguration
        {
            services.AddSingleton(typeof(ISparkPostConfiguration), typeof(TConfig));
            services.AddSparkPost();
            return services;
        }

        private static IServiceCollection AddSparkPost(this IServiceCollection services)
        {
            return services;
        }
    }
}
