using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class HoustonMLSDetailsService : SiteService<HoustonMLSDetailsModel> , IHoustonMLSDetailsService
    {
        public HoustonMLSDetailsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:HoustonMLSDetails:SiteId"];
            _listId = _configuration["SharePointList:HoustonMLSDetails:ListId"];
            _keyField = HoustonMLSDetails.JobNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(HoustonMLSDetailsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(HoustonMLSDetails.ItemsReceivedTwo, data.ItemsReceivedTwo);
            dict.Add(HoustonMLSDetails.Division, data.Division);
            dict.Add(HoustonMLSDetails.Status, data.Status);
            dict.Add(HoustonMLSDetails.Community, data.Community);
            dict.Add(HoustonMLSDetails.StreetAddress, data.StreetAddress);
            dict.Add(HoustonMLSDetails.JobNumber, data.JobNumber);
            dict.Add(HoustonMLSDetails.MLSTeamMember, data.MLSTeamMember);
            dict.Add(HoustonMLSDetails.MLSNumber, data.MLSNumber);
            dict.Add(HoustonMLSDetails.MLSNumberDate, data.MLSNumberDate);
            dict.Add(HoustonMLSDetails.Photo, data.Photo);
            dict.Add(HoustonMLSDetails.DatePosted, data.DatePosted);
            dict.Add(HoustonMLSDetails.DateReleased, data.DateReleased);
            dict.Add(HoustonMLSDetails.GeoCode, data.GeoCode);
            dict.Add(HoustonMLSDetails.StageConstruction, data.StageConstruction);
            dict.Add(HoustonMLSDetails.RealtorBonus, data.RealtorBonus);
            dict.Add(HoustonMLSDetails.SalesStaus, data.SalesStatus);
            dict.Add(HoustonMLSDetails.SalesRatifiedDate, data.SalesRatifiedDate);
            dict.Add(HoustonMLSDetails.ContractPrice, data.ContractPrice);
            dict.Add(HoustonMLSDetails.DateFormReceived, data.DateFormReceived);
           
            return dict;
        }

        protected override HoustonMLSDetailsModel ToSiteModel(HoustonMLSDetailsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ItemsReceivedTwo = data.ContainsKey(HoustonMLSDetails.ItemsReceivedTwo) ? data[HoustonMLSDetails.ItemsReceivedTwo].ToString() : null;
            siteModel.Division = data.ContainsKey(HoustonMLSDetails.Division) ? data[HoustonMLSDetails.Division].ToString() : null;
            siteModel.Status = data.ContainsKey(HoustonMLSDetails.Status) ? data[HoustonMLSDetails.Status].ToString() : null;
            siteModel.Community = data.ContainsKey(HoustonMLSDetails.Community) ? data[HoustonMLSDetails.Community].ToString() : null;
            siteModel.StreetAddress = data.ContainsKey(HoustonMLSDetails.StreetAddress) ? data[HoustonMLSDetails.StreetAddress].ToString() : null;
            siteModel.JobNumber = data.ContainsKey(HoustonMLSDetails.JobNumber) ? data[HoustonMLSDetails.JobNumber].ToString() : null;
            siteModel.MLSTeamMember = data.ContainsKey(HoustonMLSDetails.MLSTeamMember) ? data[HoustonMLSDetails.MLSTeamMember].ToString() : null;
            siteModel.MLSNumber = data.ContainsKey(HoustonMLSDetails.MLSNumber) ? data[HoustonMLSDetails.MLSNumber].ToString() : null;
            siteModel.MLSNumberDate = data.ContainsKey(HoustonMLSDetails.MLSNumberDate) ? (DateTime)data[HoustonMLSDetails.MLSNumberDate] : null;
            siteModel.Photo = data.ContainsKey(HoustonMLSDetails.Photo) ? data[HoustonMLSDetails.Photo].ToString() : null;
            siteModel.DatePosted = data.ContainsKey(HoustonMLSDetails.DatePosted) ? (DateTime)data[HoustonMLSDetails.DatePosted] : null;
            siteModel.DateReleased = data.ContainsKey(HoustonMLSDetails.DateReleased) ? DateTime.Parse(data[HoustonMLSDetails.DateReleased].ToString()) : null;
            siteModel.GeoCode = data.ContainsKey(HoustonMLSDetails.GeoCode) ? data[HoustonMLSDetails.GeoCode].ToString() : null;
            siteModel.StageConstruction = data.ContainsKey(HoustonMLSDetails.StageConstruction) ? data[HoustonMLSDetails.StageConstruction].ToString() : null;
            siteModel.RealtorBonus = data.ContainsKey(HoustonMLSDetails.RealtorBonus) ? data[HoustonMLSDetails.RealtorBonus].ToString() : null;
            siteModel.SalesStatus = data.ContainsKey(HoustonMLSDetails.SalesStaus) ? data[HoustonMLSDetails.SalesStaus].ToString() : null;
            siteModel.SalesRatifiedDate = data.ContainsKey(HoustonMLSDetails.SalesRatifiedDate) ? data[HoustonMLSDetails.SalesRatifiedDate].ToString() : null;
            siteModel.ContractPrice = data.ContainsKey(HoustonMLSDetails.ContractPrice) ? data[HoustonMLSDetails.ContractPrice].ToString() : null;
            siteModel.DateFormReceived = data.ContainsKey(HoustonMLSDetails.DateFormReceived) ? (DateTime)data[HoustonMLSDetails.DateFormReceived] : null;
            return siteModel;
        }

    }
}