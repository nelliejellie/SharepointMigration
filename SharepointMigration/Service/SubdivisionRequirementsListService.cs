using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class SubdivisionRequirementsListService : SiteService<SubdivisionRequirementsListModel> , ISubdivisionRequirementsListService
    {
        public SubdivisionRequirementsListService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:SubdivisionRequirementsList:SiteId"];
            _listId = _configuration["SharePointList:SubdivisionRequirementsList:ListId"];
            _keyField = SubdivisionRequirementsList.ProjectNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(SubdivisionRequirementsListModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(SubdivisionRequirementsList.ProjectNumber, data.ProjectNumber);
            dict.Add(SubdivisionRequirementsList.ReleaseCoordinator, data.ReleaseCoordinator);
            dict.Add(SubdivisionRequirementsList.Region, data.Region);
            dict.Add(SubdivisionRequirementsList.Division, data.Division);
            dict.Add(SubdivisionRequirementsList.Community, data.Community);
            dict.Add(SubdivisionRequirementsList.Active, data.Active);
            //dict.Add(SubdivisionRequirementsList.SelectionType, data.SelectionType);
            //dict.Add(SubdivisionRequirementsList.PermittingJurisdiction, data.PermittingJurisdiction);
            dict.Add(SubdivisionRequirementsList.MainConstructionContact, data.MainConstructionContact);
            dict.Add(SubdivisionRequirementsList.DeveloperContactInformation, data.DeveloperContactInformation);
            dict.Add(SubdivisionRequirementsList.DeveloperSubmittalRequirements, data.DeveloperSubmittalRequirements);
            dict.Add(SubdivisionRequirementsList.SitePlanReviewFee, data.SitePlanReviewFee);
            dict.Add(SubdivisionRequirementsList.StiePlanReviewFeeCost, data.StiePlanReviewFeeCost);
            dict.Add(SubdivisionRequirementsList.MasterPlanReviewFee, data.MasterPlanReviewFee);
            dict.Add(SubdivisionRequirementsList.MasterPlanReviewCost, data.MasterPlanReviewCost);
            dict.Add(SubdivisionRequirementsList.PermitContactInformation, data.PermitContactInformation);
            dict.Add(SubdivisionRequirementsList.PermitsSubmittalRequirements, data.PermitsSubmittalRequirements);
            dict.Add(SubdivisionRequirementsList.Permit, data.Permit);
            dict.Add(SubdivisionRequirementsList.CountyPermitCost, data.CountyPermitCost);
            dict.Add(SubdivisionRequirementsList.DeveloperApproval, data.DeveloperApproval);
            dict.Add(SubdivisionRequirementsList.PermitExpiration, data.PermitExpiration);
            dict.Add(SubdivisionRequirementsList.FoundationNotes, data.FoundationNotes);
            //dict.Add(SubdivisionRequirementsList.EnergyPerformanceCheck, data.EnergyPerformanceCheck);
            dict.Add(SubdivisionRequirementsList.SitePlan, data.SitePlan);
            dict.Add(SubdivisionRequirementsList.ManualJ, data.ManualJ);
            dict.Add(SubdivisionRequirementsList.Foundation, data.Foundation);
            dict.Add(SubdivisionRequirementsList.Norex, data.Norex);
            dict.Add(SubdivisionRequirementsList.Landscape, data.Landscape);
            dict.Add(SubdivisionRequirementsList.OtherWights, data.OtherWights);
            dict.Add(SubdivisionRequirementsList.AdditionalInformation, data.AdditionalInformation);
            //dict.Add(SubdivisionRequirementsList.SubdivisionReviewedandApproved, data.SubdivisionReviewedandApproved);
            //dict.Add(SubdivisionRequirementsList.CommunityLotsDontNeedPurchased, data.CommunityLotsDontNeedPurchased);
            //dict.Add(SubdivisionRequirementsList.OpenCommunities, data.OpenCommunities);
            //dict.Add(SubdivisionRequirementsList.DeveloperApprovalRequiredforPermit, data.DeveloperApprovalRequiredforPermit);
            dict.Add(SubdivisionRequirementsList.ProjectManager, data.ProjectManager);
            dict.Add(SubdivisionRequirementsList.Clusters, data.Clusters);
            //dict.Add(SubdivisionRequirementsList.DeveloperSelections, data.DeveloperSelections);
            //dict.Add(SubdivisionRequirementsList.NeedsReview, data.NeedsReview);
            //dict.Add(SubdivisionRequirementsList.ReleaseWeightPoints, data.ReleaseWeightPoints);
            return dict;
        }

        protected override SubdivisionRequirementsListModel ToSiteModel(SubdivisionRequirementsListModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ProjectNumber = data.ContainsKey(SubdivisionRequirementsList.ProjectNumber) ? data[BPSProjectDifferential.ProjectNumber].ToString() : null;
            siteModel.ReleaseCoordinator = data.ContainsKey(SubdivisionRequirementsList.ReleaseCoordinator) ? data[SubdivisionRequirementsList.ReleaseCoordinator].ToString() : null;
            siteModel.Division = data.ContainsKey(SubdivisionRequirementsList.Division) ? data[SubdivisionRequirementsList.Division].ToString() : null;
            siteModel.Community = data.ContainsKey(SubdivisionRequirementsList.Community) ? data[SubdivisionRequirementsList.Community].ToString() : null;
            siteModel.Active = data.ContainsKey(SubdivisionRequirementsList.Active) ? data[SubdivisionRequirementsList.Active].ToString() : null;
            //siteModel.SelectionType = data.ContainsKey(SubdivisionRequirementsList.SelectionType) ? data[SubdivisionRequirementsList.SelectionType].ToString() : null;
            //siteModel.PermittingJurisdiction = data.ContainsKey(SubdivisionRequirementsList.PermittingJurisdiction) ? data[SubdivisionRequirementsList.PermittingJurisdiction].ToString() : null;
            siteModel.MainConstructionContact = data.ContainsKey(SubdivisionRequirementsList.MainConstructionContact) ? data[SubdivisionRequirementsList.MainConstructionContact].ToString() : null;
            siteModel.DeveloperContactInformation = data.ContainsKey(SubdivisionRequirementsList.DeveloperContactInformation) ? data[SubdivisionRequirementsList.DeveloperContactInformation].ToString() : null;
            siteModel.DeveloperSubmittalRequirements = data.ContainsKey(SubdivisionRequirementsList.DeveloperSubmittalRequirements) ? data[SubdivisionRequirementsList.DeveloperSubmittalRequirements].ToString() : null;
            siteModel.SitePlanReviewFee = data.ContainsKey(SubdivisionRequirementsList.SitePlanReviewFee) ? data[SubdivisionRequirementsList.SitePlanReviewFee].ToString() : null;
            siteModel.StiePlanReviewFeeCost = data.ContainsKey(SubdivisionRequirementsList.StiePlanReviewFeeCost) ? data[SubdivisionRequirementsList.StiePlanReviewFeeCost].ToString() : null;
            siteModel.MasterPlanReviewFee = data.ContainsKey(SubdivisionRequirementsList.MasterPlanReviewFee) ? data[SubdivisionRequirementsList.MasterPlanReviewFee].ToString() : null;
            siteModel.MasterPlanReviewCost = data.ContainsKey(SubdivisionRequirementsList.MasterPlanReviewCost) ? data[SubdivisionRequirementsList.MasterPlanReviewCost].ToString() : null;
            siteModel.PermitContactInformation = data.ContainsKey(SubdivisionRequirementsList.PermitContactInformation) ? data[SubdivisionRequirementsList.PermitContactInformation].ToString() : null;
            siteModel.PermitsSubmittalRequirements = data.ContainsKey(SubdivisionRequirementsList.PermitsSubmittalRequirements) ? data[SubdivisionRequirementsList.PermitsSubmittalRequirements].ToString() : null;
            siteModel.Permit = data.ContainsKey(SubdivisionRequirementsList.Permit) ? data[SubdivisionRequirementsList.Permit].ToString() : null;
            siteModel.CountyPermitCost = data.ContainsKey(SubdivisionRequirementsList.CountyPermitCost) ? data[SubdivisionRequirementsList.CountyPermitCost].ToString() : null;
            siteModel.DeveloperApproval = data.ContainsKey(SubdivisionRequirementsList.DeveloperApproval) ? data[SubdivisionRequirementsList.DeveloperApproval].ToString() : null;
            siteModel.PermitExpiration = data.ContainsKey(SubdivisionRequirementsList.PermitExpiration) ? data[SubdivisionRequirementsList.PermitExpiration].ToString() : null;
            siteModel.FoundationNotes = data.ContainsKey(SubdivisionRequirementsList.FoundationNotes) ? data[SubdivisionRequirementsList.FoundationNotes].ToString() : null;
            //siteModel.EnergyPerformanceCheck = data.ContainsKey(SubdivisionRequirementsList.EnergyPerformanceCheck) ? data[SubdivisionRequirementsList.EnergyPerformanceCheck].ToString() : null;
            siteModel.SitePlan = data.ContainsKey(SubdivisionRequirementsList.SitePlan) ? data[SubdivisionRequirementsList.SitePlan].ToString() : null;
            siteModel.ManualJ = data.ContainsKey(SubdivisionRequirementsList.ManualJ) ? data[SubdivisionRequirementsList.ManualJ].ToString() : null;
            siteModel.Foundation = data.ContainsKey(SubdivisionRequirementsList.Foundation) ? data[SubdivisionRequirementsList.Foundation].ToString() : null;
            siteModel.Norex = data.ContainsKey(SubdivisionRequirementsList.Norex) ? data[SubdivisionRequirementsList.Norex].ToString() : null;
            siteModel.Landscape = data.ContainsKey(SubdivisionRequirementsList.Landscape) ? data[SubdivisionRequirementsList.Landscape].ToString() : null;
            siteModel.OtherWights = data.ContainsKey(SubdivisionRequirementsList.OtherWights) ? data[SubdivisionRequirementsList.OtherWights].ToString() : null;
            siteModel.AdditionalInformation = data.ContainsKey(SubdivisionRequirementsList.AdditionalInformation) ? data[SubdivisionRequirementsList.AdditionalInformation].ToString() : null;
            //siteModel.SubdivisionReviewedandApproved = data.ContainsKey(SubdivisionRequirementsList.SubdivisionReviewedandApproved) ? data[SubdivisionRequirementsList.SubdivisionReviewedandApproved].ToString() : null;
            //siteModel.CommunityLotsDontNeedPurchased = data.ContainsKey(SubdivisionRequirementsList.CommunityLotsDontNeedPurchased) ? data[SubdivisionRequirementsList.CommunityLotsDontNeedPurchased].ToString() : null;
            //siteModel.OpenCommunities = data.ContainsKey(SubdivisionRequirementsList.OpenCommunities) ? data[SubdivisionRequirementsList.OpenCommunities].ToString() : null;
            //siteModel.DeveloperApprovalRequiredforPermit = data.ContainsKey(SubdivisionRequirementsList.DeveloperApprovalRequiredforPermit) ? data[SubdivisionRequirementsList.DeveloperApprovalRequiredforPermit].ToString() : null;
            siteModel.ProjectManager = data.ContainsKey(SubdivisionRequirementsList.ProjectManager) ? data[SubdivisionRequirementsList.ProjectManager].ToString() : null;
            siteModel.Clusters = data.ContainsKey(SubdivisionRequirementsList.Clusters) ? data[SubdivisionRequirementsList.Clusters].ToString() : null;
            //siteModel.DeveloperSelections = data.ContainsKey(SubdivisionRequirementsList.DeveloperSelections) ? data[SubdivisionRequirementsList.DeveloperSelections].ToString() : null;
            //siteModel.NeedsReview = data.ContainsKey(SubdivisionRequirementsList.NeedsReview) ? data[SubdivisionRequirementsList.NeedsReview].ToString() : null;
            //siteModel.ReleaseWeightPoints = data.ContainsKey(SubdivisionRequirementsList.ReleaseWeightPoints) ? data[SubdivisionRequirementsList.ReleaseWeightPoints].ToString() : null;
            return siteModel;
        }

    }
}