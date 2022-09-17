using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Katalog.Product.Entities.Abstract
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
