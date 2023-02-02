using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class RealtorPresentationFormService : SiteService<RealtorPresentationFormModel> , IRealtorPresentationFormService
    {
        public RealtorPresentationFormService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:RealtorPresentationForm:SiteId"];
            _listId = _configuration["SharePointList:RealtorPresentationForm:ListId"];
            _keyField = RealtorPresentationForm.CommunityCode;
        }

        protected override Dictionary<string, object> BuildDictionary(RealtorPresentationFormModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(RealtorPresentationForm.FormDate, data.FormDate);
            dict.Add(RealtorPresentationForm.AgentEmail, data.AgentEmail);
            dict.Add(RealtorPresentationForm.Division, data.Division);
            dict.Add(RealtorPresentationForm.Market, data.Market);
            dict.Add(RealtorPresentationForm.Community, data.Community);
            dict.Add(RealtorPresentationForm.CommunityCode, data.CommunityCode);
            dict.Add(RealtorPresentationForm.PresenationDate, data.PresenationDate);
            dict.Add(RealtorPresentationForm.BrokerageName, data.BrokerageName);
            dict.Add(RealtorPresentationForm.BrokerageAddress, data.BrokerageAddress);
            dict.Add(RealtorPresentationForm.BrokerageContact, data.BrokerageContact);
            dict.Add(RealtorPresentationForm.NumberOfAgents, data.NumberOfAgents);
            dict.Add(RealtorPresentationForm.ZipCode, data.ZipCode);
            dict.Add(RealtorPresentationForm.PhoneNumber, data.PhoneNumber);
            dict.Add(RealtorPresentationForm.ResponderEmail, data.ResponderEmail);
            dict.Add(RealtorPresentationForm.ReceivedTime, data.ReceivedTime);
            dict.Add(RealtorPresentationForm.PresentationTime, data.PresentationTime);
            return dict;
        }

        protected override RealtorPresentationFormModel ToSiteModel(RealtorPresentationFormModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.FormDate = data.ContainsKey(RealtorPresentationForm.FormDate) ? (DateTime)data[RealtorPresentationForm.FormDate] : null;
            siteModel.AgentEmail = data.ContainsKey(RealtorPresentationForm.AgentEmail) ? data[RealtorPresentationForm.AgentEmail].ToString() : null;
            siteModel.Division = data.ContainsKey(RealtorPresentationForm.Division) ? data[RealtorPresentationForm.Division].ToString() : null;
            siteModel.Market = data.ContainsKey(RealtorPresentationForm.Market) ? data[RealtorPresentationForm.Market].ToString() : null;
            siteModel.Community = data.ContainsKey(RealtorPresentationForm.Community) ? data[RealtorPresentationForm.Community].ToString() : null;
            siteModel.CommunityCode = data.ContainsKey(RealtorPresentationForm.CommunityCode) ? data[RealtorPresentationForm.CommunityCode].ToString() : null;
            siteModel.PresenationDate = data.ContainsKey(RealtorPresentationForm.PresenationDate) ? (DateTime)data[RealtorPresentationForm.PresenationDate] : null;
            siteModel.BrokerageName = data.ContainsKey(RealtorPresentationForm.BrokerageName) ? data[RealtorPresentationForm.BrokerageName].ToString() : null;
            siteModel.BrokerageAddress = data.ContainsKey(RealtorPresentationForm.BrokerageAddress) ? data[RealtorPresentationForm.BrokerageAddress].ToString() : null;
            siteModel.BrokerageContact = data.ContainsKey(RealtorPresentationForm.BrokerageContact) ? data[RealtorPresentationForm.BrokerageContact].ToString() : null;
            siteModel.NumberOfAgents = data.ContainsKey(RealtorPresentationForm.NumberOfAgents) ? data[RealtorPresentationForm.NumberOfAgents].ToString() : null;
            siteModel.ZipCode = data.ContainsKey(RealtorPresentationForm.ZipCode) ? data[RealtorPresentationForm.ZipCode].ToString() : null;
            siteModel.PhoneNumber = data.ContainsKey(RealtorPresentationForm.PhoneNumber) ? data[RealtorPresentationForm.PhoneNumber].ToString() : null;
            siteModel.ResponderEmail = data.ContainsKey(RealtorPresentationForm.ResponderEmail) ? data[RealtorPresentationForm.ResponderEmail].ToString() : null;
            siteModel.ReceivedTime = data.ContainsKey(RealtorPresentationForm.ReceivedTime) ? (DateTime)data[RealtorPresentationForm.ReceivedTime] : null;
            siteModel.PresentationTime = data.ContainsKey(RealtorPresentationForm.PresentationTime) ? data[RealtorPresentationForm.PresentationTime].ToString() : null;
            
            return siteModel;
        }

    }
}