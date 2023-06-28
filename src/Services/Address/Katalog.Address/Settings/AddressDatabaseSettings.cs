namespace Katalog.Address.Settings
{
    public class AddressDatabaseSettings : IAddressDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        public string AddressCollectionName { get; set; }
        public string CitiesCollectionName { get; set; }
        public string TownsCollectionName { get; set; }
    }
}
