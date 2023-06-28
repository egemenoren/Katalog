using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Katalog.Address.Entities.Abstract;

namespace Katalog.Address.Entities
{
    public class Town:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CityId { get; set; }
        public string Name { get; set; }
    }
}
