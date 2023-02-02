using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class NonHoustonMLSDetailsService : SiteService<NonHoustonMLSDetailsModel> , INonHoustonMLSDetailsService
    {
        public NonHoustonMLSDetailsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:NonHoustonMLSDetailse:SiteId"];
            _listId = _configuration["SharePointList:NonHoustonMLSDetails:ListId"];
            _keyField = NonHoustonMLSDetails.JobNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(NonHoustonMLSDetailsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(NonHoustonMLSDetails.Status, data.Status);
            dict.Add(NonHoustonMLSDetails.Division, data.Division);
            dict.Add(NonHoustonMLSDetails.Community, data.Community);
            dict.Add(NonHoustonMLSDetails.JobNumber, data.JobNumber);
            dict.Add(NonHoustonMLSDetails.StreetAddress, data.StreetAddress);
            dict.Add(NonHoustonMLSDetails.MLSNumber, data.MLSNumber);
            dict.Add(NonHoustonMLSDetails.TXMLSNumber, data.TXMLSNumber);
            dict.Add(NonHoustonMLSDetails.Photo, data.Photo);
            dict.Add(NonHoustonMLSDetails.ListedPrice, data.ListedPrice);
            dict.Add(NonHoustonMLSDetails.RealtorBonus, data.RealtorBonus);
            dict.Add(NonHoustonMLSDetails.DatePosted, data.DatePosted);
            dict.Add(NonHoustonMLSDetails.Longitude, data.Longitude);
            dict.Add(NonHoustonMLSDetails.Latitude, data.Latitude);
            dict.Add(NonHoustonMLSDetails.DateReleased, data.DateReleased);
            dict.Add(NonHoustonMLSDetails.SalesStatus, data.SalesStatus);
            dict.Add(NonHoustonMLSDetails.SalesRatifiedDate, data.SalesRatifiedDate);
            dict.Add(NonHoustonMLSDetails.DateClosed, data.DateClosed);
            dict.Add(NonHoustonMLSDetails.ContractPrice, data.ContractPrice);
            
            return dict;
        }

        protected override NonHoustonMLSDetailsModel ToSiteModel(NonHoustonMLSDetailsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.Status = data.ContainsKey(NonHoustonMLSDetails.Status) ? data[NonHoustonMLSDetails.Status].ToString() : null;
            siteModel.Division = data.ContainsKey(NonHoustonMLSDetails.Division) ? data[NonHoustonMLSDetails.Division].ToString() : null;
            siteModel.Community = data.ContainsKey(NonHoustonMLSDetails.Community) ? data[NonHoustonMLSDetails.Community].ToString() : null;
            siteModel.JobNumber = data.ContainsKey(NonHoustonMLSDetails.JobNumber) ? data[NonHoustonMLSDetails.JobNumber].ToString() : null;
            siteModel.StreetAddress = data.ContainsKey(NonHoustonMLSDetails.StreetAddress) ? data[NonHoustonMLSDetails.StreetAddress].ToString() : null;
            siteModel.MLSNumber = data.ContainsKey(NonHoustonMLSDetails.MLSNumber) ? data[NonHoustonMLSDetails.MLSNumber].ToString() : null;
            siteModel.TXMLSNumber = data.ContainsKey(NonHoustonMLSDetails.TXMLSNumber) ? data[NonHoustonMLSDetails.TXMLSNumber].ToString() : null;
            siteModel.Photo = data.ContainsKey(NonHoustonMLSDetails.Photo) ? data[NonHoustonMLSDetails.Photo].ToString() : null;
            siteModel.ListedPrice = data.ContainsKey(NonHoustonMLSDetails.ListedPrice) ? data[NonHoustonMLSDetails.ListedPrice].ToString() : null;
            siteModel.RealtorBonus = data.ContainsKey(NonHoustonMLSDetails.RealtorBonus) ? data[NonHoustonMLSDetails.RealtorBonus].ToString() : null;
            siteModel.DatePosted = data.ContainsKey(NonHoustonMLSDetails.DatePosted) ? (DateTime)data[NonHoustonMLSDetails.DatePosted] : null;
            siteModel.Longitude = data.ContainsKey(NonHoustonMLSDetails.Longitude) ? data[NonHoustonMLSDetails.Longitude].ToString() : null;
            siteModel.Latitude = data.ContainsKey(NonHoustonMLSDetails.Latitude) ? data[NonHoustonMLSDetails.Latitude].ToString() : null;
            siteModel.DateReleased = data.ContainsKey(NonHoustonMLSDetails.DateReleased) ? DateTime.Parse(data[NonHoustonMLSDetails.DateReleased].ToString()) : null;
            siteModel.SalesStatus = data.ContainsKey(NonHoustonMLSDetails.SalesStatus) ? data[NonHoustonMLSDetails.SalesStatus].ToString() : null;
            siteModel.SalesRatifiedDate = data.ContainsKey(NonHoustonMLSDetails.SalesRatifiedDate) ? (DateTime)data[NonHoustonMLSDetails.SalesRatifiedDate] : null;
            siteModel.DateClosed = data.ContainsKey(NonHoustonMLSDetails.DateClosed) ? (DateTime)data[NonHoustonMLSDetails.DateClosed] : null;
            siteModel.ContractPrice = data.ContainsKey(NonHoustonMLSDetails.ContractPrice) ? data[NonHoustonMLSDetails.ContractPrice].ToString() : null;
            return siteModel;
        }

    }
}