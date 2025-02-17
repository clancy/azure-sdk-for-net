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

namespace Azure.ResourceManager.Network
{
    /// <summary> A Class representing a VpnGatewayNatRule along with the instance operations that can be performed on it. </summary>
    public partial class VpnGatewayNatRule : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VpnGatewayNatRule"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string gatewayName, string natRuleName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnGateways/{gatewayName}/natRules/{natRuleName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _vpnGatewayNatRuleNatRulesClientDiagnostics;
        private readonly NatRulesRestOperations _vpnGatewayNatRuleNatRulesRestClient;
        private readonly VpnGatewayNatRuleData _data;

        /// <summary> Initializes a new instance of the <see cref="VpnGatewayNatRule"/> class for mocking. </summary>
        protected VpnGatewayNatRule()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VpnGatewayNatRule"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal VpnGatewayNatRule(ArmClient client, VpnGatewayNatRuleData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="VpnGatewayNatRule"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VpnGatewayNatRule(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _vpnGatewayNatRuleNatRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string vpnGatewayNatRuleNatRulesApiVersion);
            _vpnGatewayNatRuleNatRulesRestClient = new NatRulesRestOperations(_vpnGatewayNatRuleNatRulesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, vpnGatewayNatRuleNatRulesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/vpnGateways/natRules";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual VpnGatewayNatRuleData Data
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
        /// Retrieves the details of a nat ruleGet.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnGateways/{gatewayName}/natRules/{natRuleName}
        /// Operation Id: NatRules_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<VpnGatewayNatRule>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _vpnGatewayNatRuleNatRulesClientDiagnostics.CreateScope("VpnGatewayNatRule.Get");
            scope.Start();
            try
            {
                var response = await _vpnGatewayNatRuleNatRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _vpnGatewayNatRuleNatRulesClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VpnGatewayNatRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the details of a nat ruleGet.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnGateways/{gatewayName}/natRules/{natRuleName}
        /// Operation Id: NatRules_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VpnGatewayNatRule> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _vpnGatewayNatRuleNatRulesClientDiagnostics.CreateScope("VpnGatewayNatRule.Get");
            scope.Start();
            try
            {
                var response = _vpnGatewayNatRuleNatRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _vpnGatewayNatRuleNatRulesClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VpnGatewayNatRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a nat rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnGateways/{gatewayName}/natRules/{natRuleName}
        /// Operation Id: NatRules_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _vpnGatewayNatRuleNatRulesClientDiagnostics.CreateScope("VpnGatewayNatRule.Delete");
            scope.Start();
            try
            {
                var response = await _vpnGatewayNatRuleNatRulesRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation(_vpnGatewayNatRuleNatRulesClientDiagnostics, Pipeline, _vpnGatewayNatRuleNatRulesRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Deletes a nat rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnGateways/{gatewayName}/natRules/{natRuleName}
        /// Operation Id: NatRules_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _vpnGatewayNatRuleNatRulesClientDiagnostics.CreateScope("VpnGatewayNatRule.Delete");
            scope.Start();
            try
            {
                var response = _vpnGatewayNatRuleNatRulesRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new NetworkArmOperation(_vpnGatewayNatRuleNatRulesClientDiagnostics, Pipeline, _vpnGatewayNatRuleNatRulesRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
