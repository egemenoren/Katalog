using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Katalog.Product.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public bool HasSubCategory { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ParentId { get; set; }
    }
}
