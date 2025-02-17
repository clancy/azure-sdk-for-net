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

namespace Azure.ResourceManager.Cdn
{
    /// <summary> A class representing collection of AfdRuleSet and their operations over its parent. </summary>
    public partial class AfdRuleSetCollection : ArmCollection, IEnumerable<AfdRuleSet>, IAsyncEnumerable<AfdRuleSet>
    {
        private readonly ClientDiagnostics _afdRuleSetClientDiagnostics;
        private readonly AfdRuleSetsRestOperations _afdRuleSetRestClient;

        /// <summary> Initializes a new instance of the <see cref="AfdRuleSetCollection"/> class for mocking. </summary>
        protected AfdRuleSetCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AfdRuleSetCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AfdRuleSetCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _afdRuleSetClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Cdn", AfdRuleSet.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(AfdRuleSet.ResourceType, out string afdRuleSetApiVersion);
            _afdRuleSetRestClient = new AfdRuleSetsRestOperations(_afdRuleSetClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, afdRuleSetApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Profile.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Profile.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new rule set within the specified profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Create
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        public async virtual Task<ArmOperation<AfdRuleSet>> CreateOrUpdateAsync(bool waitForCompletion, string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _afdRuleSetRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleSetName, cancellationToken).ConfigureAwait(false);
                var operation = new CdnArmOperation<AfdRuleSet>(new AfdRuleSetOperationSource(Client), _afdRuleSetClientDiagnostics, Pipeline, _afdRuleSetRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleSetName).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates a new rule set within the specified profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Create
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        public virtual ArmOperation<AfdRuleSet> CreateOrUpdate(bool waitForCompletion, string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _afdRuleSetRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleSetName, cancellationToken);
                var operation = new CdnArmOperation<AfdRuleSet>(new AfdRuleSetOperationSource(Client), _afdRuleSetClientDiagnostics, Pipeline, _afdRuleSetRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleSetName).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Get
        /// </summary>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        public async virtual Task<Response<AfdRuleSet>> GetAsync(string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.Get");
            scope.Start();
            try
            {
                var response = await _afdRuleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleSetName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _afdRuleSetClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new AfdRuleSet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Get
        /// </summary>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        public virtual Response<AfdRuleSet> Get(string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.Get");
            scope.Start();
            try
            {
                var response = _afdRuleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleSetName, cancellationToken);
                if (response.Value == null)
                    throw _afdRuleSetClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AfdRuleSet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists existing AzureFrontDoor rule sets within a profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets
        /// Operation Id: AfdRuleSets_ListByProfile
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AfdRuleSet" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AfdRuleSet> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AfdRuleSet>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _afdRuleSetRestClient.ListByProfileAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AfdRuleSet(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AfdRuleSet>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _afdRuleSetRestClient.ListByProfileNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AfdRuleSet(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists existing AzureFrontDoor rule sets within a profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets
        /// Operation Id: AfdRuleSets_ListByProfile
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AfdRuleSet" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AfdRuleSet> GetAll(CancellationToken cancellationToken = default)
        {
            Page<AfdRuleSet> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _afdRuleSetRestClient.ListByProfile(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AfdRuleSet(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AfdRuleSet> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _afdRuleSetRestClient.ListByProfileNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AfdRuleSet(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Get
        /// </summary>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(ruleSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Get
        /// </summary>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        public virtual Response<bool> Exists(string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(ruleSetName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Get
        /// </summary>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        public async virtual Task<Response<AfdRuleSet>> GetIfExistsAsync(string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _afdRuleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<AfdRuleSet>(null, response.GetRawResponse());
                return Response.FromValue(new AfdRuleSet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}
        /// Operation Id: AfdRuleSets_Get
        /// </summary>
        /// <param name="ruleSetName"> Name of the rule set under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleSetName"/> is null. </exception>
        public virtual Response<AfdRuleSet> GetIfExists(string ruleSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleSetName, nameof(ruleSetName));

            using var scope = _afdRuleSetClientDiagnostics.CreateScope("AfdRuleSetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _afdRuleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleSetName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<AfdRuleSet>(null, response.GetRawResponse());
                return Response.FromValue(new AfdRuleSet(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AfdRuleSet> IEnumerable<AfdRuleSet>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AfdRuleSet> IAsyncEnumerable<AfdRuleSet>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
