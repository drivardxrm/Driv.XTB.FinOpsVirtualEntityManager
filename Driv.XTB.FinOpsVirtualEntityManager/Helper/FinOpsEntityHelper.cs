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
    public static class FinOpsEntityHelper
    {

        public static Entity GetFinOpsEntity(this IOrganizationService service, Guid finOpsEntityId)
            => finOpsEntityId == Guid.Empty ? null : service.Retrieve(FinOpsEntity.EntityName, finOpsEntityId, new ColumnSet() { AllColumns = true });


        // NOTE : LIMIT of 5000, should be ok
        public static EntityCollection GetFinOpsEntities(this IOrganizationService service)
        {

            try
            {
                var fetchXml = $@"<?xml version='1.0' encoding='utf-16'?>
                                <fetch>
                                  <entity name='mserp_financeandoperationsentity'>
                                    <attribute name='mserp_changetrackingenabled' />
                                    <attribute name='mserp_financeandoperationsentityid' />
                                    <attribute name='mserp_hasbeengenerated' />
                                    <attribute name='mserp_physicalname' />
                                    <attribute name='mserp_refresh' />
                                    <order attribute='mserp_physicalname' />
                                  </entity>
                                </fetch>";


                var fetch = new FetchExpression(fetchXml);
                return service.RetrieveMultiple(fetch);

            }
            // will crash if FinOps not enabled on the environment
            // Works for now, but try to find a more elegant way and mot supress other errors
            catch (Exception)
            {

                return null;
            }
            
        }

       

        

    }
}
