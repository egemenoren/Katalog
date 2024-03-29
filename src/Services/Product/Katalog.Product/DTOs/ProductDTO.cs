﻿using Katalog.Product.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Katalog.Product.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string StockCode { get; set; }
        public decimal Price { get; set; }
        public decimal ListPrice { get; set; }
        public int Stock { get; set; }
        public decimal VatRate { get; set; }
        public string Description { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }

        [BsonIgnore]
        public Brand Brand { get; set; }
    }
}
