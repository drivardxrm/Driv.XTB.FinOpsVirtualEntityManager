using Driv.XTB.FinOpsVirtualEntityManager.Entities;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Driv.XTB.FinOpsVirtualEntityManager.Helper
{
    public static class CustomApiHelper
    {

        public static FinanceAndOperationsIntegrationDetails RetrieveFinanceAndOperationsIntegrationDetails(this IOrganizationService service)
        {

            var request = new OrganizationRequest("RetrieveFinanceAndOperationsIntegrationDetails");

            var response = service.Execute(request);

            return new FinanceAndOperationsIntegrationDetails()
            {
                Url = (string)response["Url"],
                IsUnifiedDatabase = (bool)response["IsUnifiedDatabase"],
                TenantId = (string)response["TenantId"],
                Id = (string)response["Id"],
            };

        }

    }

    public class FinanceAndOperationsIntegrationDetails 
    {
        // The Finance and Operations environment url property.
        public string Url { get; set; }

        // Specifies if the environment is running with Unified One Database
        public bool IsUnifiedDatabase { get; set; }

        // The Finance and Operations environment tenant id property
        public string TenantId { get; set; }

        //FinanceAndOperationsId : The Finance and Operations environment id property.
        public string Id { get; set; }

    }
}
