using Katalog.Product.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Katalog.Product.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string StockCode { get; set; }
        public decimal Price { get; set; }
        public decimal ListPrice { get; set; }
        public ProductStatus Status { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public decimal VatRate { get; set; }
        public string Description { get; set; }
    }
}
