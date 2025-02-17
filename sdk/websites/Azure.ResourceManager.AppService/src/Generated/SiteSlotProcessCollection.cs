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
    /// <summary> A class representing collection of SiteSlotProcess and their operations over its parent. </summary>
    public partial class SiteSlotProcessCollection : ArmCollection, IEnumerable<SiteSlotProcess>, IAsyncEnumerable<SiteSlotProcess>
    {
        private readonly ClientDiagnostics _siteSlotProcessWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotProcessWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotProcessCollection"/> class for mocking. </summary>
        protected SiteSlotProcessCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotProcessCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteSlotProcessCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotProcessWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteSlotProcess.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(SiteSlotProcess.ResourceType, out string siteSlotProcessWebAppsApiVersion);
            _siteSlotProcessWebAppsRestClient = new WebAppsRestOperations(_siteSlotProcessWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotProcessWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteSlot.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SiteSlot.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Get process information by its ID for a specific scaled-out instance in a web site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}
        /// Operation Id: WebApps_GetProcessSlot
        /// </summary>
        /// <param name="processId"> PID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="processId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="processId"/> is null. </exception>
        public async virtual Task<Response<SiteSlotProcess>> GetAsync(string processId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(processId, nameof(processId));

            using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotProcessWebAppsRestClient.GetProcessSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, processId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteSlotProcessWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotProcess(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get process information by its ID for a specific scaled-out instance in a web site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}
        /// Operation Id: WebApps_GetProcessSlot
        /// </summary>
        /// <param name="processId"> PID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="processId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="processId"/> is null. </exception>
        public virtual Response<SiteSlotProcess> Get(string processId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(processId, nameof(processId));

            using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.Get");
            scope.Start();
            try
            {
                var response = _siteSlotProcessWebAppsRestClient.GetProcessSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, processId, cancellationToken);
                if (response.Value == null)
                    throw _siteSlotProcessWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotProcess(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get list of processes for a web site, or a deployment slot, or for a specific scaled-out instance in a web site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes
        /// Operation Id: WebApps_ListProcessesSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteSlotProcess" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteSlotProcess> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteSlotProcess>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotProcessWebAppsRestClient.ListProcessesSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotProcess(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteSlotProcess>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotProcessWebAppsRestClient.ListProcessesSlotNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotProcess(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Get list of processes for a web site, or a deployment slot, or for a specific scaled-out instance in a web site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes
        /// Operation Id: WebApps_ListProcessesSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteSlotProcess" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteSlotProcess> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteSlotProcess> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotProcessWebAppsRestClient.ListProcessesSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotProcess(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteSlotProcess> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotProcessWebAppsRestClient.ListProcessesSlotNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotProcess(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}
        /// Operation Id: WebApps_GetProcessSlot
        /// </summary>
        /// <param name="processId"> PID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="processId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="processId"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string processId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(processId, nameof(processId));

            using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(processId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}
        /// Operation Id: WebApps_GetProcessSlot
        /// </summary>
        /// <param name="processId"> PID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="processId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="processId"/> is null. </exception>
        public virtual Response<bool> Exists(string processId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(processId, nameof(processId));

            using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(processId, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}
        /// Operation Id: WebApps_GetProcessSlot
        /// </summary>
        /// <param name="processId"> PID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="processId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="processId"/> is null. </exception>
        public async virtual Task<Response<SiteSlotProcess>> GetIfExistsAsync(string processId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(processId, nameof(processId));

            using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteSlotProcessWebAppsRestClient.GetProcessSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, processId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotProcess>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotProcess(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/processes/{processId}
        /// Operation Id: WebApps_GetProcessSlot
        /// </summary>
        /// <param name="processId"> PID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="processId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="processId"/> is null. </exception>
        public virtual Response<SiteSlotProcess> GetIfExists(string processId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(processId, nameof(processId));

            using var scope = _siteSlotProcessWebAppsClientDiagnostics.CreateScope("SiteSlotProcessCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteSlotProcessWebAppsRestClient.GetProcessSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, processId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotProcess>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotProcess(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteSlotProcess> IEnumerable<SiteSlotProcess>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteSlotProcess> IAsyncEnumerable<SiteSlotProcess>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
