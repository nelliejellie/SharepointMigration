using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class ExteriorandInteriorSelectionsService : SiteService<ExteriorandInteriorSelectionsModel>, IExteriorandInteriorSelectionsService
    {
        public ExteriorandInteriorSelectionsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:ExteriorandInteriorSelections:SiteId"];
            _listId = _configuration["SharePointList:ExteriorandInteriorSelections:ListId"];
            _keyField = ExteriorandInteriorSelections.Job;
        }

        protected override Dictionary<string, object> BuildDictionary(ExteriorandInteriorSelectionsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(ExteriorandInteriorSelections.Job, data.Job);
           // dict.Add(ExteriorandInteriorSelections.Community, data.Community);
            dict.Add(ExteriorandInteriorSelections.Address, data.Address);
            //dict.Add(ExteriorandInteriorSelections.PanelDate, data.PanelDate);
           // dict.Add(ExteriorandInteriorSelections.ExtPostDate, data.ExtPostDate);
            //dict.Add(ExteriorandInteriorSelections.ReleaseDate, data.ReleaseDate);
            dict.Add(ExteriorandInteriorSelections.ProjectNumber, data.ProjectNumber);
            dict.Add(ExteriorandInteriorSelections.Plan, data.Plan);
            dict.Add(ExteriorandInteriorSelections.Elevation, data.Elevation);
            //dict.Add(ExteriorandInteriorSelections.InputDate, data.InputDate);
            //dict.Add(ExteriorandInteriorSelections.JobPanelStatus, data.JobPanelStatus);
            //dict.Add(ExteriorandInteriorSelections.ReleaseCoordinator, data.ReleaseCoordinator);
            //dict.Add(ExteriorandInteriorSelections.SelectionType, data.SelectionType);
            //dict.Add(ExteriorandInteriorSelections.DeveloperSentDate, data.DeveloperSentDate);
            //dict.Add(ExteriorandInteriorSelections.ExtSelectionApprovedbyDeveloper, data.ExtSelectionApprovedbyDeveloper);
            //dict.Add(ExteriorandInteriorSelections.DeveloperApprovalDate, data.DeveloperApprovalDate);
            //dict.Add(ExteriorandInteriorSelections.DeveloperApprovalStatus, data.DeveloperApprovalStatus);
            //dict.Add(ExteriorandInteriorSelections.ExtSelectionPostedtoBuzzsaw, data.ExtSelectionPostedtoBuzzsaw);
            //dict.Add(ExteriorandInteriorSelections.ExtSelectionDelayed, data.ExtSelectionDelayed);
            //dict.Add(ExteriorandInteriorSelections.ReasonforDelay, data.ReasonforDelay);
            //dict.Add(ExteriorandInteriorSelections.AdditionalInformation, data.AdditionalInformation);
            dict.Add(ExteriorandInteriorSelections.DateSold, data.DateSold);
            //dict.Add(ExteriorandInteriorSelections.LateDuetoDeveloper, data.LateDuetoDeveloper);
            //dict.Add(ExteriorandInteriorSelections.TypeofExperiment, data.TypeofExperiment);
            //dict.Add(ExteriorandInteriorSelections.ExtSelectionsComments, data.ExtSelectionsComments);
            //dict.Add(ExteriorandInteriorSelections.ExtCoor, data.ExtCoor);
            //dict.Add(ExteriorandInteriorSelections.IntCoor, data.IntCoor);
            dict.Add(ExteriorandInteriorSelections.LotStatus, data.LotStatus);
            //dict.Add(ExteriorandInteriorSelections.IntSelectionDelayed, data.IntSelectionDelayed);
            //dict.Add(ExteriorandInteriorSelections.IntSelectionComments, data.IntSelectionComments);
            //dict.Add(ExteriorandInteriorSelections.SepecApprovedDate, data.SepecApprovedDate);
            //dict.Add(ExteriorandInteriorSelections.ExtSentToRC, data.ExtSentToRC);
            //dict.Add(ExteriorandInteriorSelections.IntSentToRC, data.IntSentToRC);
            //dict.Add(ExteriorandInteriorSelections.IntPostDate, data.IntPostDate);
            //dict.Add(ExteriorandInteriorSelections.ExtCoordinator, data.ExtCoordinator);
            //dict.Add(ExteriorandInteriorSelections.IntCoordinator, data.IntCoordinator);
            //dict.Add(ExteriorandInteriorSelections.DateNHSSentEmailToSelections, data.DateNHSSentEmailToSelections);
            //dict.Add(ExteriorandInteriorSelections.RCRequestSentToExt, data.RCRequestSentToExt);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredCompleted, data.TwoHundredCompleted);
            //dict.Add(ExteriorandInteriorSelections.TwoHunderedCompDate, data.TwoHunderedCompDate);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredDelayReason, data.TwoHundredDelayReason);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredTwentyCompleted, data.TwoHundredTwentyCompleted);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredTwentyCompDate, data.TwoHundredTwentyCompDate);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredTwentyDelayReason, data.TwoHundredTwentyDelayReason);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredThiryCompleted, data.TwoHundredThiryCompleted);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredThirtyCompDate, data.TwoHundredThirtyCompDate);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredThirtyDelayReason, data.TwoHundredThirtyDelayReason);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredFiftyCompleted, data.TwoHundredFiftyCompleted);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredFiftyCompDate, data.TwoHundredFiftyCompDate);
            //dict.Add(ExteriorandInteriorSelections.TwoHundredFiftyDelayReason, data.TwoHundredFiftyDelayReason);
            //dict.Add(ExteriorandInteriorSelections.Division, data.Division);
            dict.Add(ExteriorandInteriorSelections.City, data.City);
            //dict.Add(ExteriorandInteriorSelections.Estimator, data.Estimator);
            //dict.Add(ExteriorandInteriorSelections.POAmdministrator, data.POAmdministrator);
            //dict.Add(ExteriorandInteriorSelections.NotesPOA, data.NotesPOA);
            return dict;
        }

        protected override ExteriorandInteriorSelectionsModel ToSiteModel(ExteriorandInteriorSelectionsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.Job = data.ContainsKey(ExteriorandInteriorSelections.Job) ? data[ExteriorandInteriorSelections.Job].ToString() : null;
            //siteModel.Community = data.ContainsKey(ExteriorandInteriorSelections.Community) ? data[ExteriorandInteriorSelections.Community].ToString() : null;
            siteModel.Address = data.ContainsKey(ExteriorandInteriorSelections.Address) ? data[ExteriorandInteriorSelections.Address].ToString() : null;
           // siteModel.PanelDate = data.ContainsKey(ExteriorandInteriorSelections.PanelDate) ? data[ExteriorandInteriorSelections.PanelDate].ToString() : null;
           // siteModel.ExtPostDate = data.ContainsKey(ExteriorandInteriorSelections.ExtPostDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.ExtPostDate].ToString()) : null;
            //siteModel.ReleaseDate = data.ContainsKey(ExteriorandInteriorSelections.ReleaseDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.ReleaseDate].ToString()) : null;
            siteModel.ProjectNumber = data.ContainsKey(ExteriorandInteriorSelections.ProjectNumber) ? data[ExteriorandInteriorSelections.ProjectNumber].ToString() : null;
            siteModel.Plan = data.ContainsKey(ExteriorandInteriorSelections.Plan) ? data[ExteriorandInteriorSelections.Plan].ToString() : null;
            siteModel.Elevation = data.ContainsKey(ExteriorandInteriorSelections.Elevation) ? data[ExteriorandInteriorSelections.Elevation].ToString() : null;
            //siteModel.InputDate = data.ContainsKey(ExteriorandInteriorSelections.InputDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.InputDate].ToString()) : null;
           // siteModel.InputDate = data.ContainsKey(ExteriorandInteriorSelections.InputDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.InputDate].ToString()) : null;
          //  siteModel.JobPanelStatus = data.ContainsKey(ExteriorandInteriorSelections.JobPanelStatus) ? data[ExteriorandInteriorSelections.JobPanelStatus].ToString() : null;
           // siteModel.ReleaseCoordinator = data.ContainsKey(ExteriorandInteriorSelections.ReleaseCoordinator) ? data[ExteriorandInteriorSelections.ReleaseCoordinator].ToString() : null;
           // siteModel.SelectionType = data.ContainsKey(ExteriorandInteriorSelections.SelectionType) ? data[ExteriorandInteriorSelections.SelectionType].ToString() : null;
            //siteModel.DeveloperSentDate = data.ContainsKey(ExteriorandInteriorSelections.DeveloperSentDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.DeveloperSentDate].ToString()) : null;
            //siteModel.ExtSelectionApprovedbyDeveloper = data.ContainsKey(ExteriorandInteriorSelections.ExtSelectionApprovedbyDeveloper) ? data[ExteriorandInteriorSelections.ExtSelectionApprovedbyDeveloper].ToString() : null;
            //siteModel.DeveloperApprovalDate = data.ContainsKey(ExteriorandInteriorSelections.DeveloperApprovalDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.DeveloperApprovalDate].ToString()) : null;
            //siteModel.DeveloperApprovalStatus = data.ContainsKey(ExteriorandInteriorSelections.DeveloperApprovalStatus) ? data[ExteriorandInteriorSelections.DeveloperApprovalStatus].ToString() : null;
            //siteModel.ExtSelectionPostedtoBuzzsaw = data.ContainsKey(ExteriorandInteriorSelections.ExtSelectionPostedtoBuzzsaw) ? DateTime.Parse(data[ExteriorandInteriorSelections.ExtSelectionPostedtoBuzzsaw].ToString()) : null;
            //siteModel.ExtSelectionDelayed = data.ContainsKey(ExteriorandInteriorSelections.ExtSelectionDelayed) ? data[ExteriorandInteriorSelections.ExtSelectionDelayed].ToString() : null;
            //siteModel.ReasonforDelay = data.ContainsKey(ExteriorandInteriorSelections.ReasonforDelay) ? data[ExteriorandInteriorSelections.ReasonforDelay].ToString() : null;
            //siteModel.AdditionalInformation = data.ContainsKey(ExteriorandInteriorSelections.AdditionalInformation) ? data[ExteriorandInteriorSelections.AdditionalInformation].ToString() : null;
            siteModel.DateSold = data.ContainsKey(ExteriorandInteriorSelections.DateSold) ? data[ExteriorandInteriorSelections.DateSold].ToString() : null;
            //siteModel.LateDuetoDeveloper = data.ContainsKey(ExteriorandInteriorSelections.LateDuetoDeveloper) ? data[ExteriorandInteriorSelections.LateDuetoDeveloper].ToString() : null;
            //siteModel.TypeofExperiment = data.ContainsKey(ExteriorandInteriorSelections.TypeofExperiment) ? data[ExteriorandInteriorSelections.TypeofExperiment].ToString() : null;
            //siteModel.ExtSelectionsComments = data.ContainsKey(ExteriorandInteriorSelections.ExtSelectionsComments) ? data[ExteriorandInteriorSelections.ExtSelectionsComments].ToString() : null;
            //siteModel.ExtCoor = data.ContainsKey(ExteriorandInteriorSelections.ExtCoor) ? data[ExteriorandInteriorSelections.ExtCoor].ToString() : null;
            //siteModel.IntCoor = data.ContainsKey(ExteriorandInteriorSelections.IntCoor) ? data[ExteriorandInteriorSelections.IntCoor].ToString() : null;
            siteModel.LotStatus = data.ContainsKey(ExteriorandInteriorSelections.LotStatus) ? data[ExteriorandInteriorSelections.LotStatus].ToString() : null;
            //siteModel.IntSelectionDelayed = data.ContainsKey(ExteriorandInteriorSelections.IntSelectionDelayed) ? data[ExteriorandInteriorSelections.IntSelectionDelayed].ToString() : null;
            //siteModel.IntSelectionComments = data.ContainsKey(ExteriorandInteriorSelections.IntSelectionComments) ? data[ExteriorandInteriorSelections.IntSelectionComments].ToString() : null;
            //siteModel.SepecApprovedDate = data.ContainsKey(ExteriorandInteriorSelections.SepecApprovedDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.SepecApprovedDate].ToString()) : null;
            //siteModel.ExtSentToRC = data.ContainsKey(ExteriorandInteriorSelections.ExtSentToRC) ? DateTime.Parse(data[ExteriorandInteriorSelections.ExtSentToRC].ToString()) : null;
            //siteModel.IntSentToRC = data.ContainsKey(ExteriorandInteriorSelections.IntSentToRC) ? DateTime.Parse(data[ExteriorandInteriorSelections.IntSentToRC].ToString()) : null;
            //siteModel.IntPostDate = data.ContainsKey(ExteriorandInteriorSelections.IntPostDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.IntPostDate].ToString()) : null;
            //siteModel.ExtCoordinator = data.ContainsKey(ExteriorandInteriorSelections.ExtCoordinator) ? data[ExteriorandInteriorSelections.ExtCoordinator].ToString() : null;
            //siteModel.IntCoordinator = data.ContainsKey(ExteriorandInteriorSelections.IntCoordinator) ? data[ExteriorandInteriorSelections.IntCoordinator].ToString() : null;
            //siteModel.DateNHSSentEmailToSelections = data.ContainsKey(ExteriorandInteriorSelections.DateNHSSentEmailToSelections) ? DateTime.Parse(data[ExteriorandInteriorSelections.DateNHSSentEmailToSelections].ToString()) : null;
            //siteModel.RCRequestSentToExt = data.ContainsKey(ExteriorandInteriorSelections.RCRequestSentToExt) ? DateTime.Parse(data[ExteriorandInteriorSelections.RCRequestSentToExt].ToString()) : null;
            //siteModel.TwoHundredCompleted = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredCompleted) ? data[ExteriorandInteriorSelections.TwoHundredCompleted].ToString() : null;
            //siteModel.TwoHunderedCompDate = data.ContainsKey(ExteriorandInteriorSelections.TwoHunderedCompDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.TwoHunderedCompDate].ToString()) : null;
            //siteModel.TwoHundredDelayReason = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredDelayReason) ? data[ExteriorandInteriorSelections.TwoHundredDelayReason].ToString() : null;
            //siteModel.TwoHundredTwentyCompleted = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredTwentyCompleted) ? data[ExteriorandInteriorSelections.TwoHundredTwentyCompleted].ToString() : null;
            //siteModel.TwoHundredTwentyCompDate = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredTwentyCompDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.TwoHundredTwentyCompDate].ToString()) : null;
            //siteModel.TwoHundredTwentyDelayReason = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredTwentyDelayReason) ? data[ExteriorandInteriorSelections.TwoHundredTwentyDelayReason].ToString() : null;
            //siteModel.TwoHundredThiryCompleted = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredThiryCompleted) ? data[ExteriorandInteriorSelections.TwoHundredThiryCompleted].ToString() : null;
            //siteModel.TwoHundredThirtyCompDate = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredThirtyCompDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.TwoHundredThirtyCompDate].ToString()) : null;
            //siteModel.TwoHundredThirtyDelayReason = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredThirtyDelayReason) ? data[ExteriorandInteriorSelections.TwoHundredThirtyDelayReason].ToString() : null;
            //siteModel.TwoHundredFiftyCompleted = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredFiftyCompleted) ? data[ExteriorandInteriorSelections.TwoHundredFiftyCompleted].ToString() : null;
            //siteModel.TwoHundredFiftyCompDate = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredFiftyCompDate) ? DateTime.Parse(data[ExteriorandInteriorSelections.TwoHundredFiftyCompDate].ToString()) : null;
            //siteModel.TwoHundredFiftyDelayReason = data.ContainsKey(ExteriorandInteriorSelections.TwoHundredFiftyDelayReason) ? data[ExteriorandInteriorSelections.TwoHundredFiftyDelayReason].ToString() : null;
            //siteModel.Division = data.ContainsKey(ExteriorandInteriorSelections.Division) ? data[ExteriorandInteriorSelections.Division].ToString() : null;
            siteModel.City = data.ContainsKey(ExteriorandInteriorSelections.City) ? data[ExteriorandInteriorSelections.City].ToString() : null;
            //siteModel.Estimator = data.ContainsKey(ExteriorandInteriorSelections.Estimator) ? data[ExteriorandInteriorSelections.Estimator].ToString() : null;
            //siteModel.POAmdministrator = data.ContainsKey(ExteriorandInteriorSelections.POAmdministrator) ? data[ExteriorandInteriorSelections.POAmdministrator].ToString() : null;
            //siteModel.NotesPOA = data.ContainsKey(ExteriorandInteriorSelections.NotesPOA) ? data[ExteriorandInteriorSelections.NotesPOA].ToString() : null;
            return siteModel;
        }

    }
}