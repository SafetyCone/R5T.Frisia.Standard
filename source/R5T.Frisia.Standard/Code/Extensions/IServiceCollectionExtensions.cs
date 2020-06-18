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
        /// Adds the <see cref="IAwsEc2ServerSecretsProvider"/> service.
        /// </summary>
        public static IServiceCollection AddAwsEc2ServerSecretsProvider(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            services.AddSuebiaAwsEc2ServerSecretsProvider(
                services.AddHardCodedAwsEc2ServerSecretsFileNameProviderAction(),
                services.AddSecretsDirectoryFilePathProviderAction(),
                services.AddJsonFileSerializationOperatorAction(),
                addAwsEc2ServerHostFriendlyNameProvider);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IAwsEc2ServerSecretsProvider"/> service.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerSecretsProvider> AddAwsEc2ServerSecretsProviderAction(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerSecretsProvider>(() => services.AddAwsEc2ServerSecretsProvider(addAwsEc2ServerHostFriendlyNameProvider));
            return serviceAction;
        }
    }
}
