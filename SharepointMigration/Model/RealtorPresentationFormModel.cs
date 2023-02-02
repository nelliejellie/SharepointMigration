using System;

namespace SharePointMigration.Model
{
    public class RealtorPresentationFormModel : ISiteModel
    {
        public string Id { get; set; }
        public DateTime? FormDate { get; set; }
        public string AgentEmail { get; set; }
        public string Division { get; set; }
        public string Market { get; set; }
        public string Community { get; set; }
        public string CommunityCode { get; set; }
        public DateTime? PresenationDate { get; set; }
        public string BrokerageName { get; set; }
        public string BrokerageAddress { get; set; }
        public string BrokerageContact { get; set; }
        public string NumberOfAgents { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ResponderEmail { get; set; }
        public DateTime? ReceivedTime { get; set; }
        public string PresentationTime { get; set; }
    }

    public static class RealtorPresentationForm
    {
        public const string Id = "Id";
        public const string FormDate = "FormDate";
        public const string AgentEmail = "Email";
        public const string Division = "Division";
        public const string Market = "Market";
        public const string Community = "Community";
        public const string CommunityCode = "CommunityCode";
        public const string PresenationDate = "PresentationDate";
        public const string BrokerageName = "BrokerageName";
        public const string BrokerageAddress = "BrokerageAddress";
        public const string BrokerageContact = "City";
        public const string NumberOfAgents = "No_x002e_ofAgent";
        public const string ZipCode = "ZIP";
        public const string PhoneNumber = "PhoneNumber";
        public const string ResponderEmail = "ResponderEmail";
        public const string ReceivedTime = "ReceivedTime";
        public const string PresentationTime = "PRESENTATION_x0020_TIME";
    }
}
