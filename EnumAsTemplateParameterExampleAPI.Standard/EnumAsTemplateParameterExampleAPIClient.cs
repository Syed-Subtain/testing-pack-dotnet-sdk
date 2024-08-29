// <copyright file="EnumAsTemplateParameterExampleAPIClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using APIMatic.Core;
using APIMatic.Core.Types;
using EnumAsTemplateParameterExampleAPI.Standard.Controllers;
using EnumAsTemplateParameterExampleAPI.Standard.Http.Client;
using EnumAsTemplateParameterExampleAPI.Standard.Utilities;

namespace EnumAsTemplateParameterExampleAPI.Standard
{
    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class EnumAsTemplateParameterExampleAPIClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://{defaultHost}" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly Lazy<APIController> client;

        private EnumAsTemplateParameterExampleAPIClient(
            Environment environment,
            string defaultHost,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.DefaultHost = defaultHost;
            this.HttpClientConfiguration = httpClientConfiguration;

            globalConfiguration = new GlobalConfiguration.Builder()
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .Parameters(globalParameter => globalParameter
                    .Template(templateParameter => templateParameter.Setup("defaultHost", this.DefaultHost)))
                .UserAgent(userAgent)
                .Build();


            this.client = new Lazy<APIController>(
                () => new APIController(globalConfiguration));
        }

        /// <summary>
        /// Gets APIController controller.
        /// </summary>
        public APIController APIController => this.client.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets DefaultHost.
        /// DefaultHost value.
        /// </summary>
        public string DefaultHost { get; }


        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the EnumAsTemplateParameterExampleAPIClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .DefaultHost(this.DefaultHost)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"DefaultHost = {this.DefaultHost}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> EnumAsTemplateParameterExampleAPIClient.</returns>
        internal static EnumAsTemplateParameterExampleAPIClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("ENUM_AS_TEMPLATE_PARAMETER_EXAMPLE_API_STANDARD_ENVIRONMENT");
            string defaultHost = System.Environment.GetEnvironmentVariable("ENUM_AS_TEMPLATE_PARAMETER_EXAMPLE_API_STANDARD_DEFAULT_HOST");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (defaultHost != null)
            {
                builder.DefaultHost(defaultHost);
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = EnumAsTemplateParameterExampleAPI.Standard.Environment.Production;
            private string defaultHost = "www.example.com";
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets DefaultHost.
            /// </summary>
            /// <param name="defaultHost"> DefaultHost. </param>
            /// <returns> Builder. </returns>
            public Builder DefaultHost(string defaultHost)
            {
                this.defaultHost = defaultHost ?? throw new ArgumentNullException(nameof(defaultHost));
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }


           

            /// <summary>
            /// Creates an object of the EnumAsTemplateParameterExampleAPIClient using the values provided for the builder.
            /// </summary>
            /// <returns>EnumAsTemplateParameterExampleAPIClient.</returns>
            public EnumAsTemplateParameterExampleAPIClient Build()
            {
                return new EnumAsTemplateParameterExampleAPIClient(
                    environment,
                    defaultHost,
                    httpClientConfig.Build());
            }
        }
    }
}
