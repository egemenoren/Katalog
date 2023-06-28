using Katalog.Address.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Katalog.Address.Entities
{
    public class Address : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string AddressAlias { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CityId { get; set; }
        public string CityName { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string TownId { get; set; }
        public string TownName { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public string AdditionalDirections { get; set; }
    }
}
