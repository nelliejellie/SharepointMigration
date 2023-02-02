using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class DesignCenterAppointmentsService : SiteService<DesignCenterAppointmentsModel> , IDesignCenterAppoitnmentsService
    {
        public DesignCenterAppointmentsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:DesignCenterAppointments:SiteId"];
            _listId = _configuration["SharePointList:DesignCenterAppointments:ListId"];
            _keyField = DesignCenterAppointments.Homebuyer;
        }

        protected override Dictionary<string, object> BuildDictionary(DesignCenterAppointmentsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(DesignCenterAppointments.Homebuyer, data.Homebuyer);
            dict.Add(DesignCenterAppointments.JobNumber, data.JobNumber);
            dict.Add(DesignCenterAppointments.Community, data.Community);
            dict.Add(DesignCenterAppointments.Address, data.Address);
            dict.Add(DesignCenterAppointments.Plan, data.Plan);
            dict.Add(DesignCenterAppointments.SalesPerson, data.SalesPerson);
            dict.Add(DesignCenterAppointments.ContractDate, data.ContractDate);
            dict.Add(DesignCenterAppointments.ReceiptDate, data.ReceiptDate);
            dict.Add(DesignCenterAppointments.FirstAppt, data.FirstAppt);
            dict.Add(DesignCenterAppointments.SecondAppt, data.SecondAppt);
            dict.Add(DesignCenterAppointments.ThirdAppt, data.ThirdAppt);
            dict.Add(DesignCenterAppointments.HomeProAppt, data.HomeProAppt);
            dict.Add(DesignCenterAppointments.JobStatus, data.JobStatus);
            dict.Add(DesignCenterAppointments.ApptStatus, data.ApptStatus);
            dict.Add(DesignCenterAppointments.CompletionDate, data.CompletionDate);
            dict.Add(DesignCenterAppointments.HProComplete, data.HProComplete);
            dict.Add(DesignCenterAppointments.HProC, data.HProC);
            dict.Add(DesignCenterAppointments.HProStatus, data.HProStatus);
            dict.Add(DesignCenterAppointments.Days, data.Days);
            dict.Add(DesignCenterAppointments.Division, data.Division);
            dict.Add(DesignCenterAppointments.DivPres, data.DivPres);
            dict.Add(DesignCenterAppointments.CommentDate, data.CommentDate);
            dict.Add(DesignCenterAppointments.Comment, data.Comment);
            dict.Add(DesignCenterAppointments.MaxDate, data.MaxDate);
            dict.Add(DesignCenterAppointments.ApptStage, data.ApptStage);
            dict.Add(DesignCenterAppointments.HPDays, data.HPDays);
            return dict;
        }

        protected override DesignCenterAppointmentsModel ToSiteModel(DesignCenterAppointmentsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.Homebuyer = data.ContainsKey(DesignCenterAppointments.Homebuyer) ? data[DesignCenterAppointments.Homebuyer].ToString() : null;
            siteModel.JobNumber = data.ContainsKey(DesignCenterAppointments.JobNumber) ? data[DesignCenterAppointments.JobNumber].ToString() : null;
            siteModel.Community = data.ContainsKey(DesignCenterAppointments.Community) ? data[DesignCenterAppointments.Community].ToString() : null;
            siteModel.Address = data.ContainsKey(DesignCenterAppointments.Address) ? data[DesignCenterAppointments.Address].ToString() : null;
            siteModel.Plan = data.ContainsKey(DesignCenterAppointments.Plan) ? data[DesignCenterAppointments.Plan].ToString() : null;
            siteModel.SalesPerson = data.ContainsKey(DesignCenterAppointments.SalesPerson) ? data[DesignCenterAppointments.SalesPerson].ToString() : null;
            siteModel.ContractDate = data.ContainsKey(DesignCenterAppointments.ContractDate) ? (DateTime)data[DesignCenterAppointments.ContractDate] : null;
            siteModel.ReceiptDate = data.ContainsKey(DesignCenterAppointments.ReceiptDate) ? (DateTime)data[DesignCenterAppointments.ReceiptDate] : null;
            siteModel.FirstAppt = data.ContainsKey(DesignCenterAppointments.FirstAppt) ? (DateTime)data[DesignCenterAppointments.FirstAppt] : null;
            siteModel.SecondAppt = data.ContainsKey(DesignCenterAppointments.SecondAppt) ? (DateTime)data[DesignCenterAppointments.SecondAppt] : null;
            siteModel.ThirdAppt = data.ContainsKey(DesignCenterAppointments.ThirdAppt) ? (DateTime)data[DesignCenterAppointments.ThirdAppt] : null;
            siteModel.HomeProAppt = data.ContainsKey(DesignCenterAppointments.HomeProAppt) ? (DateTime)data[DesignCenterAppointments.HomeProAppt] : null;
            siteModel.JobStatus = data.ContainsKey(DesignCenterAppointments.JobStatus) ? data[DesignCenterAppointments.JobStatus].ToString() : null;
            siteModel.ApptStatus = data.ContainsKey(DesignCenterAppointments.ApptStatus) ? data[DesignCenterAppointments.ApptStatus].ToString() : null;
            siteModel.CompletionDate = data.ContainsKey(DesignCenterAppointments.CompletionDate) ? (DateTime)data[DesignCenterAppointments.CompletionDate] : null;
            siteModel.HProComplete = data.ContainsKey(DesignCenterAppointments.HProComplete) ? (DateTime)data[DesignCenterAppointments.HProComplete] : null;
            siteModel.HProC = data.ContainsKey(DesignCenterAppointments.HProC) ? data[DesignCenterAppointments.HProC].ToString() : null;
            siteModel.HProStatus = data.ContainsKey(DesignCenterAppointments.HProStatus) ? data[DesignCenterAppointments.HProStatus].ToString() : null;
            siteModel.Days = data.ContainsKey(DesignCenterAppointments.Days) ? data[DesignCenterAppointments.Days].ToString() : null;
            siteModel.Division = data.ContainsKey(DesignCenterAppointments.Division) ? data[DesignCenterAppointments.Division].ToString() : null;
            siteModel.DivPres = data.ContainsKey(DesignCenterAppointments.DivPres) ? data[DesignCenterAppointments.DivPres].ToString() : null;
            siteModel.CommentDate = data.ContainsKey(DesignCenterAppointments.CommentDate) ? (DateTime)data[DesignCenterAppointments.CommentDate] : null;
            siteModel.Comment = data.ContainsKey(DesignCenterAppointments.Comment) ? data[DesignCenterAppointments.Comment].ToString() : null;
            siteModel.MaxDate = data.ContainsKey(DesignCenterAppointments.MaxDate) ? (DateTime)data[DesignCenterAppointments.MaxDate] : null;
            siteModel.ApptStage = data.ContainsKey(DesignCenterAppointments.ApptStage) ? data[DesignCenterAppointments.ApptStage].ToString() : null;
            siteModel.HPDays = data.ContainsKey(DesignCenterAppointments.HPDays) ? data[DesignCenterAppointments.HPDays].ToString() : null;
            
            return siteModel;
        }

    }
}