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
    public static class VirtualEntityMetadataHelper
    {



        // NOTE : LIMIT of 5000, should be ok
        public static Entity GetVirtualEntityMetadataFor(this IOrganizationService service, string externalname)
        {
            var fetchXml = $@"<fetch>
                                <entity name='entity'>
                                <attribute name='entityid' />
                                <attribute name='logicalname' />
                                <attribute name='externalname' />
                                <attribute name='originallocalizedname' />
                                <attribute name='reportviewname' />
                                <filter>
                                    <condition attribute='externalname' operator='eq' value='{externalname}' />
                                </filter>
                                </entity>
                            </fetch>";


            var fetch = new FetchExpression(fetchXml);
            var results = service.RetrieveMultiple(fetch);
            return results?.Entities?.FirstOrDefault();
        }

       

        

    }
}
