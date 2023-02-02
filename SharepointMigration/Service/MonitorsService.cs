using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class MonitorsService : SiteService<MonitorsModel> , IMonitorsService
    {
        public MonitorsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:Monitors:SiteId"];
            _listId = _configuration["SharePointList:Monitors:ListId"];
            _keyField = Monitors.JobNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(MonitorsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(Monitors.JobNumber, data.JobNumber);
            dict.Add(Monitors.DivisionName, data.DivisionName);
            dict.Add(Monitors.DivisionCityName, data.DivisionCityName);
            dict.Add(Monitors.ProjectID, data.ProjectID);
            dict.Add(Monitors.ProjectName, data.ProjectName);
            dict.Add(Monitors.Address, data.Address);
            dict.Add(Monitors.City, data.City);
            dict.Add(Monitors.StageOfConstruction, data.StageOfConstruction);
            dict.Add(Monitors.PlanID, data.PlanID);
            dict.Add(Monitors.Elevation, data.Elevation);
            dict.Add(Monitors.PanelDate, data.PanelDate);
            dict.Add(Monitors.EstimatedReleaseDate, data.EstimatedReleaseDate);
            dict.Add(Monitors.ReleaseDate, data.ReleaseDate);
            dict.Add(Monitors.LastReleaseDate, data.LastReleaseDate);
            dict.Add(Monitors.EstimatedCompletionDate, data.EstimatedCompletionDate);
            dict.Add(Monitors.PlanDate, data.PlanDate);
            //dict.Add(Monitors.MonitorOneDate, data.MonitorOneDate);
            //dict.Add(Monitors.MonitorOneLetterDate, data.MonitorOneLetterDate);
            //dict.Add(Monitors.MonitorOneLetterSignedDate, data.MonitorOneLetterSignedDate);
            //dict.Add(Monitors.MonitorTwoDate, data.MonitorTwoDate);
            //dict.Add(Monitors.MonitorTwoLetterDate, data.MonitorTwoLetterDate);
            //dict.Add(Monitors.MonitorTwoLetterSignedDate, data.MonitorTwoLetterSignedDate);
            dict.Add(Monitors.PMEmail, data.PMEmail);
            dict.Add(Monitors.DPEmail, data.DPEmail);
            dict.Add(Monitors.VPCEmail, data.VPCEmail);
            dict.Add(Monitors.Notes, data.Notes);
            //dict.Add(Monitors.MonitorOneReviewer, data.MonitorOneReviewer);
            dict.Add(Monitors.Skip, data.Skip);
            dict.Add(Monitors.SalesStatus, data.SalesStatus);
            dict.Add(Monitors.RMOne, data.RMOne);
            dict.Add(Monitors.RMTwo, data.RMTwo);
            dict.Add(Monitors.CPEmail, data.CPEmail);
            //dict.Add(Monitors.MonitorStage, data.MonitorStage);
            return dict;
        }

        protected override MonitorsModel ToSiteModel(MonitorsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.JobNumber = data.ContainsKey(Monitors.JobNumber) ? data[Monitors.JobNumber].ToString() : null;
            siteModel.DivisionName = data.ContainsKey(Monitors.DivisionName) ? data[Monitors.DivisionName].ToString() : null;
            siteModel.DivisionCityName = data.ContainsKey(Monitors.DivisionCityName) ? data[Monitors.DivisionCityName].ToString() : null;
            siteModel.ProjectID = data.ContainsKey(Monitors.ProjectID) ? data[Monitors.ProjectID].ToString() : null;
            siteModel.ProjectName = data.ContainsKey(Monitors.ProjectName) ? data[Monitors.ProjectName].ToString() : null;
            siteModel.Address = data.ContainsKey(Monitors.Address) ? data[Monitors.Address].ToString() : null;
            siteModel.City = data.ContainsKey(Monitors.City) ? data[Monitors.City].ToString() : null;
            siteModel.StageOfConstruction = data.ContainsKey(Monitors.StageOfConstruction) ? data[Monitors.StageOfConstruction].ToString() : null;
            siteModel.PlanID = data.ContainsKey(Monitors.PlanID) ? data[Monitors.PlanID].ToString() : null;
            siteModel.Elevation = data.ContainsKey(Monitors.Elevation) ? data[Monitors.Elevation].ToString() : null;
            siteModel.PanelDate = data.ContainsKey(Monitors.PanelDate) ? (DateTime)data[Monitors.PanelDate] : null;
            siteModel.EstimatedReleaseDate = data.ContainsKey(Monitors.EstimatedReleaseDate) ? (DateTime)data[Monitors.EstimatedReleaseDate] : null;
            siteModel.ReleaseDate = data.ContainsKey(Monitors.ReleaseDate) ? DateTime.Parse(data[Monitors.ReleaseDate].ToString()) : null;
            siteModel.LastReleaseDate = data.ContainsKey(Monitors.LastReleaseDate) ? (DateTime)data[Monitors.LastReleaseDate] : null;
            siteModel.EstimatedCompletionDate = data.ContainsKey(Monitors.EstimatedCompletionDate) ? (DateTime)data[Monitors.EstimatedCompletionDate] : null;
            siteModel.PlanDate = data.ContainsKey(Monitors.PlanDate) ? (DateTime)data[Monitors.PlanDate] : null;
            siteModel.MonitorOneDate = data.ContainsKey(Monitors.MonitorOneDate) ? (DateTime)data[Monitors.MonitorOneDate] : null;
            siteModel.MonitorOneLetterDate = data.ContainsKey(Monitors.MonitorOneLetterDate) ? (DateTime)data[Monitors.MonitorOneLetterDate] : null;
            siteModel.MonitorOneLetterSignedDate = data.ContainsKey(Monitors.MonitorOneLetterSignedDate) ? (DateTime)data[Monitors.MonitorOneLetterSignedDate] : null;
            siteModel.MonitorTwoDate = data.ContainsKey(Monitors.MonitorTwoDate) ? (DateTime)data[Monitors.MonitorTwoDate] : null;
            siteModel.MonitorTwoLetterDate = data.ContainsKey(Monitors.MonitorTwoLetterDate) ? (DateTime)data[Monitors.MonitorTwoLetterDate] : null;
            siteModel.MonitorTwoLetterSignedDate = data.ContainsKey(Monitors.MonitorTwoLetterSignedDate) ? (DateTime)data[Monitors.MonitorTwoLetterSignedDate] : null;
            siteModel.PMEmail = data.ContainsKey(Monitors.PMEmail) ? data[Monitors.PMEmail].ToString() : null;
            siteModel.DPEmail = data.ContainsKey(Monitors.DPEmail) ? data[Monitors.DPEmail].ToString() : null;
            siteModel.VPCEmail = data.ContainsKey(Monitors.VPCEmail) ? data[Monitors.VPCEmail].ToString() : null;
            siteModel.Notes = data.ContainsKey(Monitors.Notes) ? data[Monitors.Notes].ToString() : null;
            siteModel.MonitorOneReviewer = data.ContainsKey(Monitors.MonitorOneReviewer) ? data[Monitors.MonitorOneReviewer].ToString() : null;
            siteModel.Skip = data.ContainsKey(Monitors.Skip) ? data[Monitors.Skip].ToString() : null;
            siteModel.SalesStatus = data.ContainsKey(Monitors.SalesStatus) ? data[Monitors.SalesStatus].ToString() : null;
            siteModel.RMOne = data.ContainsKey(Monitors.RMOne) ? data[Monitors.RMOne].ToString() : null;
            siteModel.RMTwo = data.ContainsKey(Monitors.RMTwo) ? data[Monitors.RMTwo].ToString() : null;
            siteModel.CPEmail = data.ContainsKey(Monitors.CPEmail) ? data[Monitors.CPEmail].ToString() : null;
            siteModel.MonitorStage = data.ContainsKey(Monitors.MonitorStage) ? data[Monitors.MonitorStage].ToString() : null;
            
            return siteModel;
        }

    }
}