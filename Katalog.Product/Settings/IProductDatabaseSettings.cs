namespace Katalog.Product.Settings
{
    public interface IProductDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        public string ProductsCollectionName { get; set; }
        public string CategoriesCollectionName { get; set; }
        public string BrandsCollectionName { get; set; }
    }
}
