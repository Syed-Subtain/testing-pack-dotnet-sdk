// <copyright file="APIController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using EnumAsTemplateParameterExampleAPI.Standard;
using EnumAsTemplateParameterExampleAPI.Standard.Exceptions;
using EnumAsTemplateParameterExampleAPI.Standard.Http.Client;
using EnumAsTemplateParameterExampleAPI.Standard.Utilities;
using Newtonsoft.Json.Converters;
using System.Net.Http;

namespace EnumAsTemplateParameterExampleAPI.Standard.Controllers
{
    /// <summary>
    /// APIController.
    /// </summary>
    public class APIController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIController"/> class.
        /// </summary>
        internal APIController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Retrieve a list of items based on their status.
        /// </summary>
        /// <param name="status">Required parameter: The status of the items to filter by..</param>
        /// <returns>Returns the List of Models.ItemsResponse response from the API call.</returns>
        public List<Models.ItemsResponse> GetItemsByStatus(
                Models.StatusEnum status)
            => CoreHelper.RunTask(GetItemsByStatusAsync(status));

        /// <summary>
        /// Retrieve a list of items based on their status.
        /// </summary>
        /// <param name="status">Required parameter: The status of the items to filter by..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.ItemsResponse response from the API call.</returns>
        public async Task<List<Models.ItemsResponse>> GetItemsByStatusAsync(
                Models.StatusEnum status,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<Models.ItemsResponse>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/items/{status}")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("status", ApiHelper.JsonSerialize(status).Trim('\"')))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad request, possibly due to an invalid status value.", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("No items found for the given status.", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}