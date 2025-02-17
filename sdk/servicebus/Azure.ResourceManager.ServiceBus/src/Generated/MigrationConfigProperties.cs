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
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.ResourceManager.ServiceBus
{
    /// <summary> A Class representing a MigrationConfigProperties along with the instance operations that can be performed on it. </summary>
    public partial class MigrationConfigProperties : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="MigrationConfigProperties"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string configName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _migrationConfigPropertiesMigrationConfigsClientDiagnostics;
        private readonly MigrationConfigsRestOperations _migrationConfigPropertiesMigrationConfigsRestClient;
        private readonly MigrationConfigPropertiesData _data;

        /// <summary> Initializes a new instance of the <see cref="MigrationConfigProperties"/> class for mocking. </summary>
        protected MigrationConfigProperties()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "MigrationConfigProperties"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal MigrationConfigProperties(ArmClient client, MigrationConfigPropertiesData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="MigrationConfigProperties"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MigrationConfigProperties(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _migrationConfigPropertiesMigrationConfigsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ServiceBus", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string migrationConfigPropertiesMigrationConfigsApiVersion);
            _migrationConfigPropertiesMigrationConfigsRestClient = new MigrationConfigsRestOperations(_migrationConfigPropertiesMigrationConfigsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, migrationConfigPropertiesMigrationConfigsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.ServiceBus/namespaces/migrationConfigurations";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual MigrationConfigPropertiesData Data
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
        /// Retrieves Migration Config
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}
        /// Operation Id: MigrationConfigs_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<MigrationConfigProperties>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateScope("MigrationConfigProperties.Get");
            scope.Start();
            try
            {
                var response = await _migrationConfigPropertiesMigrationConfigsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new MigrationConfigProperties(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves Migration Config
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}
        /// Operation Id: MigrationConfigs_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MigrationConfigProperties> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateScope("MigrationConfigProperties.Get");
            scope.Start();
            try
            {
                var response = _migrationConfigPropertiesMigrationConfigsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MigrationConfigProperties(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a MigrationConfiguration
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}
        /// Operation Id: MigrationConfigs_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateScope("MigrationConfigProperties.Delete");
            scope.Start();
            try
            {
                var response = await _migrationConfigPropertiesMigrationConfigsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ServiceBusArmOperation(response);
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
        /// Deletes a MigrationConfiguration
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}
        /// Operation Id: MigrationConfigs_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateScope("MigrationConfigProperties.Delete");
            scope.Start();
            try
            {
                var response = _migrationConfigPropertiesMigrationConfigsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new ServiceBusArmOperation(response);
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

        /// <summary>
        /// This operation Completes Migration of entities by pointing the connection strings to Premium namespace and any entities created after the operation will be under Premium Namespace. CompleteMigration operation will fail when entity migration is in-progress.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}/upgrade
        /// Operation Id: MigrationConfigs_CompleteMigration
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response> CompleteMigrationAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateScope("MigrationConfigProperties.CompleteMigration");
            scope.Start();
            try
            {
                var response = await _migrationConfigPropertiesMigrationConfigsRestClient.CompleteMigrationAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation Completes Migration of entities by pointing the connection strings to Premium namespace and any entities created after the operation will be under Premium Namespace. CompleteMigration operation will fail when entity migration is in-progress.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}/upgrade
        /// Operation Id: MigrationConfigs_CompleteMigration
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CompleteMigration(CancellationToken cancellationToken = default)
        {
            using var scope = _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateScope("MigrationConfigProperties.CompleteMigration");
            scope.Start();
            try
            {
                var response = _migrationConfigPropertiesMigrationConfigsRestClient.CompleteMigration(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation reverts Migration
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}/revert
        /// Operation Id: MigrationConfigs_Revert
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response> RevertAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateScope("MigrationConfigProperties.Revert");
            scope.Start();
            try
            {
                var response = await _migrationConfigPropertiesMigrationConfigsRestClient.RevertAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation reverts Migration
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/migrationConfigurations/{configName}/revert
        /// Operation Id: MigrationConfigs_Revert
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Revert(CancellationToken cancellationToken = default)
        {
            using var scope = _migrationConfigPropertiesMigrationConfigsClientDiagnostics.CreateScope("MigrationConfigProperties.Revert");
            scope.Start();
            try
            {
                var response = _migrationConfigPropertiesMigrationConfigsRestClient.Revert(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
