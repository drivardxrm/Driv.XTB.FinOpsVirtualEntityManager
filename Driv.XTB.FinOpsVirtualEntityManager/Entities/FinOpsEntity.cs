// *********************************************************************
// Created by : Latebound Constants Generator 1.2023.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://operations-bhvr-test.crm3.dynamics.com/
// Filename   : C:\Temp\AvailableFinanceandOperationsEntity.cs
// Created    : 2024-02-14 22:43:12
// *********************************************************************
namespace Driv.XTB.FinOpsVirtualEntityManager.Entities
{
    /// <summary>DisplayName: Available Finance and Operations Entity, OwnershipType: OrganizationOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class FinOpsEntity
    {
        public const string EntityName = "mserp_financeandoperationsentity";
        public const string EntityCollectionName = "mserp_financeandoperationsentities";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "mserp_financeandoperationsentityid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "mserp_physicalname";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string ChangeTracking = "mserp_changetrackingenabled";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string ChangeTrackingName = "mserp_changetrackingenabledname";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string VisibleName = "mserp_hasbeengeneratedname";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string RefreshName = "mserp_refreshname";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Refresh = "mserp_refresh";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Visible = "mserp_hasbeengenerated";

        #endregion Attributes
    }
}
