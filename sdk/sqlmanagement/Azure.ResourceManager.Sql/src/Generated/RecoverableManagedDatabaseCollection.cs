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

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of RecoverableManagedDatabase and their operations over its parent. </summary>
    public partial class RecoverableManagedDatabaseCollection : ArmCollection, IEnumerable<RecoverableManagedDatabase>, IAsyncEnumerable<RecoverableManagedDatabase>
    {
        private readonly ClientDiagnostics _recoverableManagedDatabaseClientDiagnostics;
        private readonly RecoverableManagedDatabasesRestOperations _recoverableManagedDatabaseRestClient;

        /// <summary> Initializes a new instance of the <see cref="RecoverableManagedDatabaseCollection"/> class for mocking. </summary>
        protected RecoverableManagedDatabaseCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="RecoverableManagedDatabaseCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal RecoverableManagedDatabaseCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _recoverableManagedDatabaseClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", RecoverableManagedDatabase.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(RecoverableManagedDatabase.ResourceType, out string recoverableManagedDatabaseApiVersion);
            _recoverableManagedDatabaseRestClient = new RecoverableManagedDatabasesRestOperations(_recoverableManagedDatabaseClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, recoverableManagedDatabaseApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagedInstance.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagedInstance.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a recoverable managed database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/recoverableDatabases/{recoverableDatabaseName}
        /// Operation Id: RecoverableManagedDatabases_Get
        /// </summary>
        /// <param name="recoverableDatabaseName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recoverableDatabaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recoverableDatabaseName"/> is null. </exception>
        public async virtual Task<Response<RecoverableManagedDatabase>> GetAsync(string recoverableDatabaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoverableDatabaseName, nameof(recoverableDatabaseName));

            using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.Get");
            scope.Start();
            try
            {
                var response = await _recoverableManagedDatabaseRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, recoverableDatabaseName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _recoverableManagedDatabaseClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new RecoverableManagedDatabase(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a recoverable managed database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/recoverableDatabases/{recoverableDatabaseName}
        /// Operation Id: RecoverableManagedDatabases_Get
        /// </summary>
        /// <param name="recoverableDatabaseName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recoverableDatabaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recoverableDatabaseName"/> is null. </exception>
        public virtual Response<RecoverableManagedDatabase> Get(string recoverableDatabaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoverableDatabaseName, nameof(recoverableDatabaseName));

            using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.Get");
            scope.Start();
            try
            {
                var response = _recoverableManagedDatabaseRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, recoverableDatabaseName, cancellationToken);
                if (response.Value == null)
                    throw _recoverableManagedDatabaseClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RecoverableManagedDatabase(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of recoverable managed databases.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/recoverableDatabases
        /// Operation Id: RecoverableManagedDatabases_ListByInstance
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RecoverableManagedDatabase" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RecoverableManagedDatabase> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<RecoverableManagedDatabase>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _recoverableManagedDatabaseRestClient.ListByInstanceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RecoverableManagedDatabase(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<RecoverableManagedDatabase>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _recoverableManagedDatabaseRestClient.ListByInstanceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RecoverableManagedDatabase(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of recoverable managed databases.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/recoverableDatabases
        /// Operation Id: RecoverableManagedDatabases_ListByInstance
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RecoverableManagedDatabase" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RecoverableManagedDatabase> GetAll(CancellationToken cancellationToken = default)
        {
            Page<RecoverableManagedDatabase> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _recoverableManagedDatabaseRestClient.ListByInstance(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RecoverableManagedDatabase(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<RecoverableManagedDatabase> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _recoverableManagedDatabaseRestClient.ListByInstanceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RecoverableManagedDatabase(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/recoverableDatabases/{recoverableDatabaseName}
        /// Operation Id: RecoverableManagedDatabases_Get
        /// </summary>
        /// <param name="recoverableDatabaseName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recoverableDatabaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recoverableDatabaseName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string recoverableDatabaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoverableDatabaseName, nameof(recoverableDatabaseName));

            using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(recoverableDatabaseName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/recoverableDatabases/{recoverableDatabaseName}
        /// Operation Id: RecoverableManagedDatabases_Get
        /// </summary>
        /// <param name="recoverableDatabaseName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recoverableDatabaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recoverableDatabaseName"/> is null. </exception>
        public virtual Response<bool> Exists(string recoverableDatabaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoverableDatabaseName, nameof(recoverableDatabaseName));

            using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(recoverableDatabaseName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/recoverableDatabases/{recoverableDatabaseName}
        /// Operation Id: RecoverableManagedDatabases_Get
        /// </summary>
        /// <param name="recoverableDatabaseName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recoverableDatabaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recoverableDatabaseName"/> is null. </exception>
        public async virtual Task<Response<RecoverableManagedDatabase>> GetIfExistsAsync(string recoverableDatabaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoverableDatabaseName, nameof(recoverableDatabaseName));

            using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _recoverableManagedDatabaseRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, recoverableDatabaseName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<RecoverableManagedDatabase>(null, response.GetRawResponse());
                return Response.FromValue(new RecoverableManagedDatabase(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/recoverableDatabases/{recoverableDatabaseName}
        /// Operation Id: RecoverableManagedDatabases_Get
        /// </summary>
        /// <param name="recoverableDatabaseName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="recoverableDatabaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="recoverableDatabaseName"/> is null. </exception>
        public virtual Response<RecoverableManagedDatabase> GetIfExists(string recoverableDatabaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(recoverableDatabaseName, nameof(recoverableDatabaseName));

            using var scope = _recoverableManagedDatabaseClientDiagnostics.CreateScope("RecoverableManagedDatabaseCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _recoverableManagedDatabaseRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, recoverableDatabaseName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<RecoverableManagedDatabase>(null, response.GetRawResponse());
                return Response.FromValue(new RecoverableManagedDatabase(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<RecoverableManagedDatabase> IEnumerable<RecoverableManagedDatabase>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<RecoverableManagedDatabase> IAsyncEnumerable<RecoverableManagedDatabase>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
