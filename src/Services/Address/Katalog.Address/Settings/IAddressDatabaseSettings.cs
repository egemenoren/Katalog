namespace Katalog.Address.Settings
{
    public interface IAddressDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        public string AddressesCollectionName { get; set; }
        public string CitiesCollectionName { get; set; }
        public string TownsCollectionName { get; set; }
    }
}
