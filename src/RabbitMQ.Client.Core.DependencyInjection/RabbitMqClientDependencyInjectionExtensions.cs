﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Core.DependencyInjection.Configuration;
using RabbitMQ.Client.Core.DependencyInjection.Models;

namespace RabbitMQ.Client.Core.DependencyInjection
{
    /// <summary>
    /// DI extensions for RabbitMQ client (RabbitMQ connection).
    /// </summary>
    public static class RabbitMqClientDependencyInjectionExtensions
    {
        /// <summary>
        /// Add RabbitMQ client and required service infrastructure.
        /// </summary>
        /// <remarks>
        /// QueueService will be added in the singleton mode.
        /// </remarks>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">RabbitMq configuration section.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddRabbitMqClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var configurationInstance = GetRabbitMqClientOptionsInstance(configuration);
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqConnectionOptions(guid, configurationInstance);
            services.ResolveSingletonQueueService(guid);
            return services;
        }

        /// <summary>
        /// Add RabbitMQ client and required service infrastructure.
        /// </summary>
        /// <remarks>
        /// QueueService will be added in the singleton mode.
        /// </remarks>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">RabbitMq configuration <see cref="RabbitMqClientOptions"/>.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddRabbitMqClient(this IServiceCollection services, RabbitMqClientOptions configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqConnectionOptions(guid, configuration);
            services.ResolveSingletonQueueService(guid);
            return services;
        }

        /// <summary>
        /// Add RabbitMQ client and required service infrastructure.
        /// </summary>
        /// <remarks>
        /// QueueService will be added in the transient mode.
        /// </remarks>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">RabbitMq configuration section.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddRabbitMqClientTransient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var configurationInstance = GetRabbitMqClientOptionsInstance(configuration);
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqConnectionOptions(guid, configurationInstance);
            services.ResolveTransientQueueService(guid);
            return services;
        }

        /// <summary>
        /// Add RabbitMQ client and required service infrastructure.
        /// </summary>
        /// <remarks>
        /// QueueService will be added in the transient mode.
        /// </remarks>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">RabbitMq configuration <see cref="RabbitMqClientOptions"/>.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddRabbitMqClientTransient(this IServiceCollection services, RabbitMqClientOptions configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqConnectionOptions(guid, configuration);
            services.ResolveTransientQueueService(guid);
            return services;
        }
        
        public static IServiceCollection AddRabbitMqProducingClientSingleton(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var configurationInstance = GetRabbitMqClientOptionsInstance(configuration);
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqProducingClientOptions(guid, configurationInstance);
            services.ResolveSingletonProducingService(guid);
            return services;
        }
        
        public static IServiceCollection AddRabbitMqProducingClientSingleton(this IServiceCollection services, RabbitMqClientOptions configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqProducingClientOptions(guid, configuration);
            services.ResolveSingletonProducingService(guid);
            return services;
        }
        
        public static IServiceCollection AddRabbitMqProducingClientTransient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var configurationInstance = GetRabbitMqClientOptionsInstance(configuration);
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqProducingClientOptions(guid, configurationInstance);
            services.ResolveTransientProducingService(guid);
            return services;
        }
        
        public static IServiceCollection AddRabbitMqProducingClientTransient(this IServiceCollection services, RabbitMqClientOptions configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqProducingClientOptions(guid, configuration);
            services.ResolveTransientProducingService(guid);
            return services;
        }
        
        public static IServiceCollection AddRabbitMqConsumingClientSingleton(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var configurationInstance = GetRabbitMqClientOptionsInstance(configuration);
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqConsumingClientOptions(guid, configurationInstance);
            services.ResolveSingletonConsumingService(guid);
            return services;
        }
        
        public static IServiceCollection AddRabbitMqConsumingClientSingleton(this IServiceCollection services, RabbitMqClientOptions configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqConsumingClientOptions(guid, configuration);
            services.ResolveSingletonConsumingService(guid);
            return services;
        }
        
        public static IServiceCollection AddRabbitMqConsumingClientTransient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var configurationInstance = GetRabbitMqClientOptionsInstance(configuration);
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqConsumingClientOptions(guid, configurationInstance);
            services.ResolveTransientConsumingService(guid);
            return services;
        }
        
        public static IServiceCollection AddRabbitMqConsumingClientTransient(this IServiceCollection services, RabbitMqClientOptions configuration)
        {
            services.AddRabbitMqClientInfrastructure();
            var guid = Guid.NewGuid();
            services.ConfigureRabbitMqConsumingClientOptions(guid, configuration);
            services.ResolveTransientConsumingService(guid);
            return services;
        }

        static IServiceCollection AddRabbitMqClientInfrastructure(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging(options => options.AddConsole());
            services.TryAddSingleton<IMessageHandlerContainerBuilder, MessageHandlerContainerBuilder>();
            services.TryAddSingleton<IMessageHandlingService, MessageHandlingService>();
            return services;
        }

        static RabbitMqClientOptions GetRabbitMqClientOptionsInstance(IConfiguration configuration)
        {
            var options = new RabbitMqClientOptions();
            configuration.Bind(options);
            return options;
        }

        static IServiceCollection ConfigureRabbitMqProducingClientOptions(this IServiceCollection services, Guid guid, RabbitMqClientOptions options)
        {
            // TODO: Check if it already exists .
            var container = new RabbitMqConnectionOptionsContainer
            {
                Guid = guid,
                Options = new RabbitMqConnectionOptions { ProducerOptions = options }
            };
            return services.AddRabbitMqConnectionOptionsContainer(container);
        }
        
        static IServiceCollection ConfigureRabbitMqConsumingClientOptions(this IServiceCollection services, Guid guid, RabbitMqClientOptions options)
        {
            // TODO: Check if it already exists .
            var container = new RabbitMqConnectionOptionsContainer
            {
                Guid = guid,
                Options = new RabbitMqConnectionOptions { ConsumerOptions = options }
            };
            return services.AddRabbitMqConnectionOptionsContainer(container);
        }

        static IServiceCollection ConfigureRabbitMqConnectionOptions(this IServiceCollection services, Guid guid, RabbitMqClientOptions options)
        {
            // TODO: Check if it already exists .
            var container = new RabbitMqConnectionOptionsContainer
            {
                Guid = guid,
                Options = new RabbitMqConnectionOptions
                {
                    ProducerOptions = options,
                    ConsumerOptions = options
                }
            };
            return services.AddRabbitMqConnectionOptionsContainer(container);
        }

        static IServiceCollection AddRabbitMqConnectionOptionsContainer(this IServiceCollection services, RabbitMqConnectionOptionsContainer container)
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(RabbitMqConnectionOptionsContainer), container);
            services.Add(serviceDescriptor);
            return services;
        }

        static IServiceCollection ResolveSingletonQueueService(this IServiceCollection services, Guid guid)
        {
            services.TryAddSingleton<IQueueService>(provider => new QueueService(
                guid,
                provider.GetServices<RabbitMqConnectionOptionsContainer>(),
                provider.GetService<IMessageHandlingService>(),
                provider.GetServices<RabbitMqExchange>(),
                provider.GetService<ILogger<QueueService> >()));
            return services;
        }
        
        static IServiceCollection ResolveTransientQueueService(this IServiceCollection services, Guid guid)
        {
            services.TryAddTransient<IQueueService>(provider => new QueueService(
                guid,
                provider.GetServices<RabbitMqConnectionOptionsContainer>(),
                provider.GetService<IMessageHandlingService>(),
                provider.GetServices<RabbitMqExchange>(),
                provider.GetService<ILogger<QueueService> >()));
            return services;
        }
        
        static IServiceCollection ResolveSingletonProducingService(this IServiceCollection services, Guid guid)
        {
            services.TryAddSingleton<IProducingService>(provider => new QueueService(
                guid,
                provider.GetServices<RabbitMqConnectionOptionsContainer>(),
                provider.GetService<IMessageHandlingService>(),
                provider.GetServices<RabbitMqExchange>(),
                provider.GetService<ILogger<QueueService> >()));
            return services;
        }
        
        static IServiceCollection ResolveTransientProducingService(this IServiceCollection services, Guid guid)
        {
            services.TryAddTransient<IProducingService>(provider => new QueueService(
                guid,
                provider.GetServices<RabbitMqConnectionOptionsContainer>(),
                provider.GetService<IMessageHandlingService>(),
                provider.GetServices<RabbitMqExchange>(),
                provider.GetService<ILogger<QueueService> >()));
            return services;
        }
        
        static IServiceCollection ResolveSingletonConsumingService(this IServiceCollection services, Guid guid)
        {
            services.TryAddSingleton<IConsumingService>(provider => new QueueService(
                guid,
                provider.GetServices<RabbitMqConnectionOptionsContainer>(),
                provider.GetService<IMessageHandlingService>(),
                provider.GetServices<RabbitMqExchange>(),
                provider.GetService<ILogger<QueueService> >()));
            return services;
        }
        
        static IServiceCollection ResolveTransientConsumingService(this IServiceCollection services, Guid guid)
        {
            services.TryAddTransient<IConsumingService>(provider => new QueueService(
                guid,
                provider.GetServices<RabbitMqConnectionOptionsContainer>(),
                provider.GetService<IMessageHandlingService>(),
                provider.GetServices<RabbitMqExchange>(),
                provider.GetService<ILogger<QueueService> >()));
            return services;
        }
    }
}