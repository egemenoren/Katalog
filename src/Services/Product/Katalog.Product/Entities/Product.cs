using Katalog.Product.Entities.Abstract;
using Katalog.Product.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Katalog.Product.Entities
{
    public class Product : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string StockCode { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ListPrice { get; set; }

        public ProductStatus Status { get; set; }
        public int Stock { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string BrandId { get; set; }

        public decimal VatRate { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateTime { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdateTime { get; set; }


    }
}
