using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Katalog.Address.Entities.Abstract;

namespace Katalog.Address.Entities
{
    public class City:IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
