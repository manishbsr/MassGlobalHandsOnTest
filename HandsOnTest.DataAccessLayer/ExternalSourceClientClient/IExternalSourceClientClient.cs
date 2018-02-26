﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace HandsOnTest.DataAccessLayer.ExternalSourceClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    //using HandsOnTest.DataAccessLayer.Models;
	using HandsOnTest.DbModels;
    /// <summary>
    /// </summary>
    public partial interface IExternalSourceClientClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Subscription credentials which uniquely identify client
        /// subscription.
        /// </summary>
        ServiceClientCredentials Credentials { get; }


            /// <summary>
        /// Gets a list of employees with their data.
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<Employee>>> ApiEmployeesGetWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

    }
}
