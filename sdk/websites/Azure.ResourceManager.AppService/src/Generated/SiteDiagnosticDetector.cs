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
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A Class representing a SiteDiagnosticDetector along with the instance operations that can be performed on it. </summary>
    public partial class SiteDiagnosticDetector : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteDiagnosticDetector"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string diagnosticCategory, string detectorName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteDiagnosticDetectorDiagnosticsClientDiagnostics;
        private readonly DiagnosticsRestOperations _siteDiagnosticDetectorDiagnosticsRestClient;
        private readonly DetectorDefinitionAutoGeneratedData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteDiagnosticDetector"/> class for mocking. </summary>
        protected SiteDiagnosticDetector()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteDiagnosticDetector"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteDiagnosticDetector(ArmClient client, DetectorDefinitionAutoGeneratedData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteDiagnosticDetector"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteDiagnosticDetector(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteDiagnosticDetectorDiagnosticsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string siteDiagnosticDetectorDiagnosticsApiVersion);
            _siteDiagnosticDetectorDiagnosticsRestClient = new DiagnosticsRestOperations(_siteDiagnosticDetectorDiagnosticsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteDiagnosticDetectorDiagnosticsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/diagnostics/detectors";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DetectorDefinitionAutoGeneratedData Data
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
        /// Description for Get Detector
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetector
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SiteDiagnosticDetector>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetector.Get");
            scope.Start();
            try
            {
                var response = await _siteDiagnosticDetectorDiagnosticsRestClient.GetSiteDetectorAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteDiagnosticDetector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get Detector
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetSiteDetector
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteDiagnosticDetector> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetector.Get");
            scope.Start();
            try
            {
                var response = _siteDiagnosticDetectorDiagnosticsRestClient.GetSiteDetector(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteDiagnosticDetector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Execute Detector
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}/execute
        /// Operation Id: Diagnostics_ExecuteSiteDetector
        /// </summary>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<DiagnosticDetectorResponse>> ExecuteAsync(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetector.Execute");
            scope.Start();
            try
            {
                var response = await _siteDiagnosticDetectorDiagnosticsRestClient.ExecuteSiteDetectorAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, timeGrain, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Execute Detector
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}/execute
        /// Operation Id: Diagnostics_ExecuteSiteDetector
        /// </summary>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DiagnosticDetectorResponse> Execute(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetector.Execute");
            scope.Start();
            try
            {
                var response = _siteDiagnosticDetectorDiagnosticsRestClient.ExecuteSiteDetector(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, timeGrain, cancellationToken);
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
