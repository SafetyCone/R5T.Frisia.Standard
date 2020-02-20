using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Jutland.Standard;
using R5T.Suebia.Standard;

using R5T.Frisia.Suebia;


namespace R5T.Frisia.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddAwsEc2ServerHostFriendlyNameProvider(this IServiceCollection services, string hostFriendlyName)
        {
            services.AddInstanceAwsEc2ServerHostFriendlyNameProvider(hostFriendlyName);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IAwsEc2ServerHostFriendlyNameProvider> AddAwsEc2ServerHostFriendlyNameProviderAction(this IServiceCollection services, string hostFriendlyName)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerHostFriendlyNameProvider>(() => services.AddAwsEc2ServerHostFriendlyNameProvider(hostFriendlyName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsProvider"/> service.
        /// </summary>
        public static IServiceCollection AddAwsEc2ServerSecretsProvider(this IServiceCollection services, string hostFriendlyName)
        {
            services.AddSuebiaAwsEc2ServerSecretsProvider(
                services.AddHardCodedAwsEc2ServerSecretsFileNameProviderAction(),
                services.AddSecretsFilePathProviderAction(),
                services.AddJsonFileSerializationOperatorAction(),
                services.AddAwsEc2ServerHostFriendlyNameProviderAction(hostFriendlyName));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsProvider"/> service.
        /// </summary>
        public static ServiceAction<IAwsEc2ServerSecretsProvider> AddAwsEc2ServerSecretsProviderAction(this IServiceCollection services, string hostFriendlyName)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerSecretsProvider>(() => services.AddAwsEc2ServerSecretsProvider(hostFriendlyName));
            return serviceAction;
        }
    }
}
