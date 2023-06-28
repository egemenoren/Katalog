using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Katalog.Address.Entities.Abstract
{
    public interface IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }
}
