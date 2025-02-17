// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of SiteWebJob and their operations over its parent. </summary>
    public partial class SiteWebJobCollection : ArmCollection, IEnumerable<SiteWebJob>, IAsyncEnumerable<SiteWebJob>
    {
        private readonly ClientDiagnostics _siteWebJobWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteWebJobWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteWebJobCollection"/> class for mocking. </summary>
        protected SiteWebJobCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteWebJobCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteWebJobCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteWebJobWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteWebJob.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SiteWebJob.ResourceType, out string siteWebJobWebAppsApiVersion);
            _siteWebJobWebAppsRestClient = new WebAppsRestOperations(_siteWebJobWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteWebJobWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != WebSite.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, WebSite.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Get webjob information for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}
        /// Operation Id: WebApps_GetWebJob
        /// </summary>
        /// <param name="webJobName"> Name of the web job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public async virtual Task<Response<SiteWebJob>> GetAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteWebJobWebAppsRestClient.GetWebJobAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, webJobName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteWebJobWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteWebJob(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get webjob information for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}
        /// Operation Id: WebApps_GetWebJob
        /// </summary>
        /// <param name="webJobName"> Name of the web job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<SiteWebJob> Get(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.Get");
            scope.Start();
            try
            {
                var response = _siteWebJobWebAppsRestClient.GetWebJob(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, webJobName, cancellationToken);
                if (response.Value == null)
                    throw _siteWebJobWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteWebJob(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for List webjobs for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs
        /// Operation Id: WebApps_ListWebJobs
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteWebJob" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteWebJob> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteWebJob>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteWebJobWebAppsRestClient.ListWebJobsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteWebJob(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteWebJob>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteWebJobWebAppsRestClient.ListWebJobsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteWebJob(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for List webjobs for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs
        /// Operation Id: WebApps_ListWebJobs
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteWebJob" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteWebJob> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteWebJob> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteWebJobWebAppsRestClient.ListWebJobs(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteWebJob(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteWebJob> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteWebJobWebAppsRestClient.ListWebJobsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteWebJob(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}
        /// Operation Id: WebApps_GetWebJob
        /// </summary>
        /// <param name="webJobName"> Name of the web job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(webJobName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}
        /// Operation Id: WebApps_GetWebJob
        /// </summary>
        /// <param name="webJobName"> Name of the web job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<bool> Exists(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(webJobName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}
        /// Operation Id: WebApps_GetWebJob
        /// </summary>
        /// <param name="webJobName"> Name of the web job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public async virtual Task<Response<SiteWebJob>> GetIfExistsAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteWebJobWebAppsRestClient.GetWebJobAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, webJobName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteWebJob>(null, response.GetRawResponse());
                return Response.FromValue(new SiteWebJob(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}
        /// Operation Id: WebApps_GetWebJob
        /// </summary>
        /// <param name="webJobName"> Name of the web job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<SiteWebJob> GetIfExists(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteWebJobWebAppsClientDiagnostics.CreateScope("SiteWebJobCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteWebJobWebAppsRestClient.GetWebJob(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, webJobName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteWebJob>(null, response.GetRawResponse());
                return Response.FromValue(new SiteWebJob(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteWebJob> IEnumerable<SiteWebJob>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteWebJob> IAsyncEnumerable<SiteWebJob>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
