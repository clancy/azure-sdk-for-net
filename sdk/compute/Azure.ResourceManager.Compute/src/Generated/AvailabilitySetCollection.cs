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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing collection of AvailabilitySet and their operations over its parent. </summary>
    public partial class AvailabilitySetCollection : ArmCollection, IEnumerable<AvailabilitySet>, IAsyncEnumerable<AvailabilitySet>
    {
        private readonly ClientDiagnostics _availabilitySetClientDiagnostics;
        private readonly AvailabilitySetsRestOperations _availabilitySetRestClient;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetCollection"/> class for mocking. </summary>
        protected AvailabilitySetCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AvailabilitySetCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _availabilitySetClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", AvailabilitySet.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(AvailabilitySet.ResourceType, out string availabilitySetApiVersion);
            _availabilitySetRestClient = new AvailabilitySetsRestOperations(_availabilitySetClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, availabilitySetApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<AvailabilitySet>> CreateOrUpdateAsync(bool waitForCompletion, string availabilitySetName, AvailabilitySetData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _availabilitySetRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation<AvailabilitySet>(Response.FromValue(new AvailabilitySet(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<AvailabilitySet> CreateOrUpdate(bool waitForCompletion, string availabilitySetName, AvailabilitySetData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _availabilitySetRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, parameters, cancellationToken);
                var operation = new ComputeArmOperation<AvailabilitySet>(Response.FromValue(new AvailabilitySet(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public async virtual Task<Response<AvailabilitySet>> GetAsync(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.Get");
            scope.Start();
            try
            {
                var response = await _availabilitySetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _availabilitySetClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new AvailabilitySet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual Response<AvailabilitySet> Get(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.Get");
            scope.Start();
            try
            {
                var response = _availabilitySetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, cancellationToken);
                if (response.Value == null)
                    throw _availabilitySetClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AvailabilitySet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all availability sets in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets
        /// Operation Id: AvailabilitySets_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySet" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySet> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AvailabilitySet>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _availabilitySetRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySet(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AvailabilitySet>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _availabilitySetRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySet(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all availability sets in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets
        /// Operation Id: AvailabilitySets_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySet" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySet> GetAll(CancellationToken cancellationToken = default)
        {
            Page<AvailabilitySet> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _availabilitySetRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySet(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AvailabilitySet> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _availabilitySetRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AvailabilitySet(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(availabilitySetName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual Response<bool> Exists(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(availabilitySetName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public async virtual Task<Response<AvailabilitySet>> GetIfExistsAsync(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _availabilitySetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<AvailabilitySet>(null, response.GetRawResponse());
                return Response.FromValue(new AvailabilitySet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
        /// Operation Id: AvailabilitySets_Get
        /// </summary>
        /// <param name="availabilitySetName"> The name of the availability set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetName"/> is null. </exception>
        public virtual Response<AvailabilitySet> GetIfExists(string availabilitySetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetName, nameof(availabilitySetName));

            using var scope = _availabilitySetClientDiagnostics.CreateScope("AvailabilitySetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _availabilitySetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, availabilitySetName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<AvailabilitySet>(null, response.GetRawResponse());
                return Response.FromValue(new AvailabilitySet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AvailabilitySet> IEnumerable<AvailabilitySet>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AvailabilitySet> IAsyncEnumerable<AvailabilitySet>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
