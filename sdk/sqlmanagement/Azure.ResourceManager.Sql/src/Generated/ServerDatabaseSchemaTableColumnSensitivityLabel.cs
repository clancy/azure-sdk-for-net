// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A Class representing a ServerDatabaseSchemaTableColumnSensitivityLabel along with the instance operations that can be performed on it. </summary>
    public partial class ServerDatabaseSchemaTableColumnSensitivityLabel : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ServerDatabaseSchemaTableColumnSensitivityLabel"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string schemaName, string tableName, string columnName, string sensitivityLabelSource)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics;
        private readonly SensitivityLabelsRestOperations _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsRestClient;
        private readonly SensitivityLabelData _data;

        /// <summary> Initializes a new instance of the <see cref="ServerDatabaseSchemaTableColumnSensitivityLabel"/> class for mocking. </summary>
        protected ServerDatabaseSchemaTableColumnSensitivityLabel()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ServerDatabaseSchemaTableColumnSensitivityLabel"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ServerDatabaseSchemaTableColumnSensitivityLabel(ArmClient client, SensitivityLabelData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ServerDatabaseSchemaTableColumnSensitivityLabel"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ServerDatabaseSchemaTableColumnSensitivityLabel(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsApiVersion);
            _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsRestClient = new SensitivityLabelsRestOperations(_serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/servers/databases/schemas/tables/columns/sensitivityLabels";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SensitivityLabelData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the sensitivity label of a given column
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}
        /// Operation Id: SensitivityLabels_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ServerDatabaseSchemaTableColumnSensitivityLabel>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("ServerDatabaseSchemaTableColumnSensitivityLabel.Get");
            scope.Start();
            try
            {
                var response = await _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name.ToSensitivityLabelSource(), cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ServerDatabaseSchemaTableColumnSensitivityLabel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the sensitivity label of a given column
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}
        /// Operation Id: SensitivityLabels_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ServerDatabaseSchemaTableColumnSensitivityLabel> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("ServerDatabaseSchemaTableColumnSensitivityLabel.Get");
            scope.Start();
            try
            {
                var response = _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name.ToSensitivityLabelSource(), cancellationToken);
                if (response.Value == null)
                    throw _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDatabaseSchemaTableColumnSensitivityLabel(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the sensitivity label of a given column
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/current
        /// Operation Id: SensitivityLabels_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("ServerDatabaseSchemaTableColumnSensitivityLabel.Delete");
            scope.Start();
            try
            {
                var response = await _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation(response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the sensitivity label of a given column
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/current
        /// Operation Id: SensitivityLabels_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsClientDiagnostics.CreateScope("ServerDatabaseSchemaTableColumnSensitivityLabel.Delete");
            scope.Start();
            try
            {
                var response = _serverDatabaseSchemaTableColumnSensitivityLabelSensitivityLabelsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken);
                var operation = new SqlArmOperation(response);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
