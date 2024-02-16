using Driv.XTB.FinOpsVirtualEntityManager.Entities;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driv.XTB.FinOpsVirtualEntityManager.Proxy
{
    public class FinOpsEntityProxy
    {
        public Entity FinOpsEntityRow;
        public FinOpsEntityProxy(Entity availableEntity)
        {
            FinOpsEntityRow = availableEntity;
        }

        public bool IsVisible => FinOpsEntityRow.Attributes.Contains(FinOpsEntity.Visible) &&
                                    (bool)FinOpsEntityRow[FinOpsEntity.Visible];

        public bool ChangeTrackingEnabled => FinOpsEntityRow.Attributes.Contains(FinOpsEntity.ChangeTracking) &&
                                    (bool)FinOpsEntityRow[FinOpsEntity.ChangeTracking];

        public bool Refresh => FinOpsEntityRow.Attributes.Contains(FinOpsEntity.Refresh) &&
                                    (bool)FinOpsEntityRow[FinOpsEntity.Refresh];

    }
}
