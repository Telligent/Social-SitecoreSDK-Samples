using System;

namespace Telligent.Social.SitecoreSDK.Samples.MVC.Models
{
    public class RateModel
    {
        public RateModel() { }

        public RateModel(string contentTypeId, string contentId, dynamic results)
        {
            ContentTypeId = contentTypeId;
            ContentId = contentId;
            Results = results;
        }

        public double Value
        {
            get
            {
                return Results != null && Results.Rating != null ? (double) Results.Rating.Value : 0;
            }
        }

        public string ContentTypeId { get; set; }
        public string ContentId { get; set; }
        public string Url { get; set; }
        public dynamic Results { get; set; }
    }
}