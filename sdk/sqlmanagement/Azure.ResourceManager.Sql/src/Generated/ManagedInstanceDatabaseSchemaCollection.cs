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
    /// <summary> A class representing collection of ManagedInstanceDatabaseSchema and their operations over its parent. </summary>
    public partial class ManagedInstanceDatabaseSchemaCollection : ArmCollection, IEnumerable<ManagedInstanceDatabaseSchema>, IAsyncEnumerable<ManagedInstanceDatabaseSchema>
    {
        private readonly ClientDiagnostics _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics;
        private readonly ManagedDatabaseSchemasRestOperations _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceDatabaseSchemaCollection"/> class for mocking. </summary>
        protected ManagedInstanceDatabaseSchemaCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceDatabaseSchemaCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagedInstanceDatabaseSchemaCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ManagedInstanceDatabaseSchema.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ManagedInstanceDatabaseSchema.ResourceType, out string managedInstanceDatabaseSchemaManagedDatabaseSchemasApiVersion);
            _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient = new ManagedDatabaseSchemasRestOperations(_managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedInstanceDatabaseSchemaManagedDatabaseSchemasApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagedDatabase.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagedDatabase.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get managed database schema
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: ManagedDatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public async virtual Task<Response<ManagedInstanceDatabaseSchema>> GetAsync(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.Get");
            scope.Start();
            try
            {
                var response = await _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schemaName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ManagedInstanceDatabaseSchema(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get managed database schema
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: ManagedDatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual Response<ManagedInstanceDatabaseSchema> Get(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.Get");
            scope.Start();
            try
            {
                var response = _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schemaName, cancellationToken);
                if (response.Value == null)
                    throw _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceDatabaseSchema(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List managed database schemas
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas
        /// Operation Id: ManagedDatabaseSchemas_ListByDatabase
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedInstanceDatabaseSchema" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedInstanceDatabaseSchema> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedInstanceDatabaseSchema>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceDatabaseSchema(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedInstanceDatabaseSchema>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceDatabaseSchema(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List managed database schemas
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas
        /// Operation Id: ManagedDatabaseSchemas_ListByDatabase
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedInstanceDatabaseSchema" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedInstanceDatabaseSchema> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedInstanceDatabaseSchema> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceDatabaseSchema(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedInstanceDatabaseSchema> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceDatabaseSchema(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: ManagedDatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(schemaName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: ManagedDatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual Response<bool> Exists(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(schemaName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: ManagedDatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public async virtual Task<Response<ManagedInstanceDatabaseSchema>> GetIfExistsAsync(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schemaName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ManagedInstanceDatabaseSchema>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceDatabaseSchema(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: ManagedDatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual Response<ManagedInstanceDatabaseSchema> GetIfExists(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _managedInstanceDatabaseSchemaManagedDatabaseSchemasClientDiagnostics.CreateScope("ManagedInstanceDatabaseSchemaCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managedInstanceDatabaseSchemaManagedDatabaseSchemasRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schemaName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ManagedInstanceDatabaseSchema>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceDatabaseSchema(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagedInstanceDatabaseSchema> IEnumerable<ManagedInstanceDatabaseSchema>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagedInstanceDatabaseSchema> IAsyncEnumerable<ManagedInstanceDatabaseSchema>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
