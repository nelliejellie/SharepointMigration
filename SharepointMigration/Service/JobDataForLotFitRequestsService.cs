using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class JobDataForLotFitRequestsService : SiteService<JobDataForLotFitRequestsServiceModel> , IJobDataForLotFitRequestsService
    {
        public JobDataForLotFitRequestsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:JobDataForLotFitRequestsService:SiteId"];
            _listId = _configuration["SharePointList:JobDataForLotFitRequestsService:ListId"];
            _keyField = JobDataForLotFitRequests.JobNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(JobDataForLotFitRequestsServiceModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(JobDataForLotFitRequests.Title, data.Title);
            dict.Add(JobDataForLotFitRequests.RegionCity, data.RegionCity);
            dict.Add(JobDataForLotFitRequests.Division, data.Division);
            dict.Add(JobDataForLotFitRequests.Community, data.Community);
            dict.Add(JobDataForLotFitRequests.Address, data.Address);
            dict.Add(JobDataForLotFitRequests.JobNumber, data.JobNumber);
            dict.Add(JobDataForLotFitRequests.Status, data.Status);
            dict.Add(JobDataForLotFitRequests.Block, data.Block);
            dict.Add(JobDataForLotFitRequests.Section, data.Section);
            dict.Add(JobDataForLotFitRequests.Lot, data.Lot);
            dict.Add(JobDataForLotFitRequests.Plan, data.Plan);
            dict.Add(JobDataForLotFitRequests.Elevation, data.Elevation);
            dict.Add(JobDataForLotFitRequests.Legal, data.Legal);
            dict.Add(JobDataForLotFitRequests.GarageSwing, data.GarageSwing);
            dict.Add(JobDataForLotFitRequests.LotStatus, data.LotStatus);
            
            return dict;
        }

        protected override JobDataForLotFitRequestsServiceModel ToSiteModel(JobDataForLotFitRequestsServiceModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.Title = data.ContainsKey(JobDataForLotFitRequests.Title) ? data[JobDataForLotFitRequests.Title].ToString() : null;
            siteModel.RegionCity = data.ContainsKey(JobDataForLotFitRequests.RegionCity) ? data[JobDataForLotFitRequests.RegionCity].ToString() : null;
            siteModel.Division = data.ContainsKey(JobDataForLotFitRequests.Division) ? data[JobDataForLotFitRequests.Division].ToString() : null;
            siteModel.Community = data.ContainsKey(JobDataForLotFitRequests.Community) ? data[JobDataForLotFitRequests.Community].ToString() : null;
            siteModel.Address = data.ContainsKey(JobDataForLotFitRequests.Address) ? data[JobDataForLotFitRequests.Address].ToString() : null;
            siteModel.JobNumber = data.ContainsKey(JobDataForLotFitRequests.JobNumber) ? data[JobDataForLotFitRequests.JobNumber].ToString() : null;
            siteModel.Status = data.ContainsKey(JobDataForLotFitRequests.Status) ? data[JobDataForLotFitRequests.Status].ToString() : null;
            siteModel.Block = data.ContainsKey(JobDataForLotFitRequests.Block) ? data[JobDataForLotFitRequests.Block].ToString() : null;
            siteModel.Section = data.ContainsKey(JobDataForLotFitRequests.Section) ? data[JobDataForLotFitRequests.Section].ToString() : null;
            siteModel.Lot = data.ContainsKey(JobDataForLotFitRequests.Lot) ? data[JobDataForLotFitRequests.Lot].ToString() : null;
            siteModel.Plan = data.ContainsKey(JobDataForLotFitRequests.Plan) ? data[JobDataForLotFitRequests.Plan].ToString() : null;
            siteModel.Elevation = data.ContainsKey(JobDataForLotFitRequests.Elevation) ? data[JobDataForLotFitRequests.Elevation].ToString() : null;
            siteModel.Legal = data.ContainsKey(JobDataForLotFitRequests.Legal) ? data[JobDataForLotFitRequests.Legal].ToString() : null;
            siteModel.GarageSwing = data.ContainsKey(JobDataForLotFitRequests.GarageSwing) ? data[JobDataForLotFitRequests.GarageSwing].ToString() : null;
            siteModel.LotStatus = data.ContainsKey(JobDataForLotFitRequests.LotStatus) ? data[JobDataForLotFitRequests.LotStatus].ToString() : null;
            return siteModel;
        }

    }
}