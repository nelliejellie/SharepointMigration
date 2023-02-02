using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class CompletedRequestsService : SiteService<CompletedRequestsModel> , ICompletedRequestsService
    {
        public CompletedRequestsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:CompletedRequests:SiteId"];
            _listId = _configuration["SharePointList:CompletedRequests:ListId"];
            _keyField = CompletedRequests.JobNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(CompletedRequestsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(CompletedRequests.Address, data.Address);
            dict.Add(CompletedRequests.ApproveRejectComments, data.ApproveRejectComments);
            dict.Add(CompletedRequests.AudienceTargeting, data.AudienceTargeting);
            dict.Add(CompletedRequests.Buyer, data.Buyer);
            dict.Add(CompletedRequests.Category, data.Category);
            dict.Add(CompletedRequests.BuyerID, data.BuyerID);
            dict.Add(CompletedRequests.Community, data.Community);
            dict.Add(CompletedRequests.DateRequested, data.DateRequested);
            dict.Add(CompletedRequests.Description, data.Description);
            dict.Add(CompletedRequests.DesignAssignedTo, data.DesignAssignedTo);
            dict.Add(CompletedRequests.DesignCompletionDate, data.DesignCompletionDate);
            dict.Add(CompletedRequests.DesignFinishDate, data.DesignFinishDate);
            dict.Add(CompletedRequests.Division, data.Division);
            dict.Add(CompletedRequests.DivisionPresident, data.DivisionPresident);
            dict.Add(CompletedRequests.DP, data.DP);
            dict.Add(CompletedRequests.DPApprovalDate, data.DPApprovalDate);
            dict.Add(CompletedRequests.DPApprovalStatus, data.DPApprovalStatus);
            dict.Add(CompletedRequests.DPApprovalStatusBefore, data.DPApprovalStatusBefore);
            dict.Add(CompletedRequests.DPApprovedDate, data.DPApprovedDate);
            dict.Add(CompletedRequests.DPComments, data.DPComments);
            dict.Add(CompletedRequests.EditItem, data.EditItem);
            dict.Add(CompletedRequests.ItemID, data.ItemID);
            dict.Add(CompletedRequests.JobNumber, data.JobNumber);
            dict.Add(CompletedRequests.OptionsComments, data.OptionsComments);
            dict.Add(CompletedRequests.PlanElevation, data.PlanElevation);
            dict.Add(CompletedRequests.PlanRevision, data.PlanRevision);
            dict.Add(CompletedRequests.PlanRevisionBefore, data.PlanRevisionBefore);
            dict.Add(CompletedRequests.PlanRevisionType, data.PlanRevisionType);
            dict.Add(CompletedRequests.PricingAssignedTo, data.PricingAssignedTo);
            dict.Add(CompletedRequests.PricingCompleteStatusBefore, data.PricingCompleteStatusBefore);
            dict.Add(CompletedRequests.PricingCompleted, data.PricingCompleted);
            dict.Add(CompletedRequests.PricingCompletionDate, data.PricingCompletionDate);
            dict.Add(CompletedRequests.PricingDocument, data.PricingDocument);
            dict.Add(CompletedRequests.PricingFinishDate, data.PricingFinishDate);
            dict.Add(CompletedRequests.PricingNeeded, data.PricingNeeded);
            dict.Add(CompletedRequests.RequestAssignedTo, data.RequestAssignedTo);
            dict.Add(CompletedRequests.RequestAssignedToBefore, data.RequestAssignedToBefore);
            dict.Add(CompletedRequests.RequestDate, data.RequestDate);
            dict.Add(CompletedRequests.RequestStatus, data.RequestStatus);
            dict.Add(CompletedRequests.RequestStatusBefore, data.RequestStatusBefore);
            dict.Add(CompletedRequests.SalesPrice, data.SalesPrice);
            dict.Add(CompletedRequests.SentEmail, data.SentEmail);
            dict.Add(CompletedRequests.SketchCompleteValueBefore, data.SketchCompleteValueBefore);
            dict.Add(CompletedRequests.SketchesCompleted, data.SketchesCompleted);
            dict.Add(CompletedRequests.SketchesNeeded, data.SketchesNeeded);
            dict.Add(CompletedRequests.StageOfContruction, data.StageOfContruction);
            dict.Add(CompletedRequests.Status, data.Status);
            dict.Add(CompletedRequests.StausBefore, data.StausBefore);
            dict.Add(CompletedRequests.StatusComplete, data.StatusComplete);
            dict.Add(CompletedRequests.TargetAudiences, data.TargetAudiences);
            dict.Add(CompletedRequests.Title, data.Title);
            dict.Add(CompletedRequests.VPC, data.VPC);
            dict.Add(CompletedRequests.VPCComments, data.VPCComments);
            dict.Add(CompletedRequests.VPCPerson, data.VPCPerson);
            return dict;
        }

        protected override CompletedRequestsModel ToSiteModel(CompletedRequestsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.Address = data.ContainsKey(CompletedRequests.Address) ? data[CompletedRequests.Address].ToString() : null;
            siteModel.ApproveRejectComments = data.ContainsKey(CompletedRequests.ApproveRejectComments) ? data[CompletedRequests.ApproveRejectComments].ToString() : null;
            siteModel.AudienceTargeting = data.ContainsKey(CompletedRequests.AudienceTargeting) ? data[CompletedRequests.AudienceTargeting].ToString() : null;
            siteModel.Buyer = data.ContainsKey(CompletedRequests.Buyer) ? data[CompletedRequests.Buyer].ToString() : null;
            siteModel.Category = data.ContainsKey(CompletedRequests.Category) ? data[CompletedRequests.Category].ToString() : null;
            siteModel.BuyerID = data.ContainsKey(CompletedRequests.BuyerID) ? data[CompletedRequests.BuyerID].ToString() : null;
            siteModel.Community = data.ContainsKey(CompletedRequests.Community) ? data[CompletedRequests.Community].ToString() : null;
            siteModel.DateRequested = data.ContainsKey(CompletedRequests.DateRequested) ? data[CompletedRequests.DateRequested].ToString() : null;
            siteModel.Description = data.ContainsKey(CompletedRequests.Description) ? data[CompletedRequests.Description].ToString() : null;
            siteModel.DesignAssignedTo = data.ContainsKey(CompletedRequests.DesignAssignedTo) ? data[CompletedRequests.DesignAssignedTo].ToString() : null;
            siteModel.DesignCompletionDate = data.ContainsKey(CompletedRequests.DesignCompletionDate) ? data[CompletedRequests.DesignCompletionDate].ToString() : null;
            siteModel.DesignFinishDate = data.ContainsKey(CompletedRequests.DesignFinishDate) ? data[CompletedRequests.DesignFinishDate].ToString() : null;
            siteModel.Division = data.ContainsKey(CompletedRequests.Division) ? data[CompletedRequests.Division].ToString() : null;
            siteModel.DivisionPresident = data.ContainsKey(CompletedRequests.DivisionPresident) ? data[CompletedRequests.DivisionPresident].ToString() : null;
            siteModel.DP = data.ContainsKey(CompletedRequests.DP) ? data[CompletedRequests.DP].ToString() : null;
            siteModel.DPApprovalDate = data.ContainsKey(CompletedRequests.DPApprovalDate) ? data[CompletedRequests.DPApprovalDate].ToString() : null;
            siteModel.DPApprovalStatus = data.ContainsKey(CompletedRequests.DPApprovalStatus) ? data[CompletedRequests.DPApprovalStatus].ToString() : null;
            siteModel.DPApprovalStatusBefore = data.ContainsKey(CompletedRequests.DPApprovalStatusBefore) ? data[CompletedRequests.DPApprovalStatusBefore].ToString() : null;
            siteModel.DPApprovedDate = data.ContainsKey(CompletedRequests.DPApprovedDate) ? (DateTime)data[CompletedRequests.DPApprovedDate] : null;
            siteModel.DPApprovalStatus = data.ContainsKey(CompletedRequests.DPApprovalStatus) ? data[CompletedRequests.DPApprovalStatus].ToString() : null;
            siteModel.DPApprovalStatusBefore = data.ContainsKey(CompletedRequests.DPApprovalStatusBefore) ? data[CompletedRequests.DPApprovalStatusBefore].ToString() : null;
            siteModel.DPComments = data.ContainsKey(CompletedRequests.DPComments) ? data[CompletedRequests.DPComments].ToString() : null;
            siteModel.EditItem = data.ContainsKey(CompletedRequests.EditItem) ? data[CompletedRequests.EditItem].ToString() : null;
            siteModel.ItemID = data.ContainsKey(CompletedRequests.ItemID) ? data[CompletedRequests.ItemID].ToString() : null;
            siteModel.JobNumber = data.ContainsKey(CompletedRequests.JobNumber) ? data[CompletedRequests.JobNumber].ToString() : null;
            siteModel.OptionsComments = data.ContainsKey(CompletedRequests.OptionsComments) ? data[CompletedRequests.OptionsComments].ToString() : null;
            siteModel.PlanElevation = data.ContainsKey(CompletedRequests.PlanElevation) ? data[CompletedRequests.PlanElevation].ToString() : null;
            siteModel.PlanRevision = data.ContainsKey(CompletedRequests.PlanRevision) ? data[CompletedRequests.PlanRevision].ToString() : null;
            siteModel.PlanRevisionBefore = data.ContainsKey(CompletedRequests.PlanRevisionBefore) ? data[CompletedRequests.PlanRevisionBefore].ToString() : null;
            siteModel.PlanRevisionType = data.ContainsKey(CompletedRequests.PlanRevisionType) ? data[CompletedRequests.PlanRevisionType].ToString() : null;
            siteModel.PricingAssignedTo = data.ContainsKey(CompletedRequests.PricingAssignedTo) ? data[CompletedRequests.PricingAssignedTo].ToString() : null;
            siteModel.PricingCompleteStatusBefore = data.ContainsKey(CompletedRequests.PricingCompleteStatusBefore) ? data[CompletedRequests.PricingCompleteStatusBefore].ToString() : null;
            siteModel.PricingCompletionDate = data.ContainsKey(CompletedRequests.PricingCompletionDate) ? data[CompletedRequests.PricingCompleted].ToString() : null;
            siteModel.PricingDocument = data.ContainsKey(CompletedRequests.PricingDocument) ? data[CompletedRequests.PricingDocument].ToString() : null;
            siteModel.PricingFinishDate = data.ContainsKey(CompletedRequests.PricingFinishDate) ? (DateTime)data[CompletedRequests.PricingFinishDate] : null;
            siteModel.PricingNeeded = data.ContainsKey(CompletedRequests.PricingNeeded) ? data[CompletedRequests.PricingNeeded].ToString() : null;
            siteModel.RequestAssignedTo = data.ContainsKey(CompletedRequests.RequestAssignedTo) ? data[CompletedRequests.RequestAssignedTo].ToString() : null;
            siteModel.RequestAssignedToBefore = data.ContainsKey(CompletedRequests.RequestAssignedToBefore) ? data[CompletedRequests.RequestAssignedToBefore].ToString() : null;
            siteModel.RequestDate = data.ContainsKey(CompletedRequests.RequestDate) ? (DateTime)data[CompletedRequests.RequestDate]: null;
            siteModel.RequestStatusBefore = data.ContainsKey(CompletedRequests.RequestStatusBefore) ? data[CompletedRequests.RequestStatusBefore].ToString() : null;
            siteModel.SalesPrice = data.ContainsKey(CompletedRequests.SalesPrice) ? data[CompletedRequests.SalesPrice].ToString() : null;
            siteModel.SentEmail = data.ContainsKey(CompletedRequests.SentEmail) ? data[CompletedRequests.SentEmail].ToString() : null;
            siteModel.SketchCompleteValueBefore = data.ContainsKey(CompletedRequests.SketchCompleteValueBefore) ? data[CompletedRequests.SketchCompleteValueBefore].ToString() : null;
            siteModel.SketchesCompleted = data.ContainsKey(CompletedRequests.SketchesCompleted) ? data[CompletedRequests.SketchesCompleted].ToString() : null;
            siteModel.SketchesNeeded = data.ContainsKey(CompletedRequests.SketchesNeeded) ? data[CompletedRequests.SketchesNeeded].ToString() : null;
            siteModel.StageOfContruction = data.ContainsKey(CompletedRequests.StageOfContruction) ? data[CompletedRequests.StageOfContruction].ToString() : null;
            siteModel.Status = data.ContainsKey(CompletedRequests.Status) ? data[CompletedRequests.Status].ToString() : null;
            siteModel.StausBefore = data.ContainsKey(CompletedRequests.StausBefore) ? data[CompletedRequests.StausBefore].ToString() : null;
            siteModel.StatusComplete = data.ContainsKey(CompletedRequests.StatusComplete) ? data[CompletedRequests.StatusComplete].ToString() : null;
            siteModel.TargetAudiences = data.ContainsKey(CompletedRequests.TargetAudiences) ? data[CompletedRequests.TargetAudiences].ToString() : null;
            siteModel.Title = data.ContainsKey(CompletedRequests.Title) ? data[CompletedRequests.Title].ToString() : null;
            siteModel.VPC = data.ContainsKey(CompletedRequests.VPC) ? data[CompletedRequests.VPC].ToString() : null;
            siteModel.VPCComments = data.ContainsKey(CompletedRequests.VPCComments) ? data[CompletedRequests.VPCComments].ToString() : null;
            siteModel.VPCPerson = data.ContainsKey(CompletedRequests.VPCPerson) ? data[CompletedRequests.VPCPerson].ToString() : null;
            return siteModel;
        }

    }
}