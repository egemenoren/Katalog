using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Katalog.Product.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
