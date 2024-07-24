using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Consultant_ATS.Models
{
    public class Submission
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("userId")]
        public string? UserId { get; set; }

        [BsonElement("clientName")]
        public string? ClientName { get; set; }

        [BsonElement("vendorName")]
        public string? VendorName { get; set; }

        [BsonElement("vendorCompany")]
        public string? VendorCompany { get; set; }

        [BsonElement("vendorEmail")]
        public string? VendorEmail { get; set; }

        [BsonElement("vendorPhone")]
        public string? VendorPhone { get; set; }

        [BsonElement("payRate")]
        public string? PayRate { get; set; }

        [BsonElement("notes")]
        public string? Notes { get; set; }

        [BsonElement("date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; } = DateTime.Now;

        [BsonElement("status")]
        public string Status { get; set; } = "Submitted";
    }

}
