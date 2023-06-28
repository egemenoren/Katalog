using Katalog.Address.Entities;
using Katalog.Address.Repositories.Abstract;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json.Serialization;

namespace Katalog.Address.Services
{
    public class WriteDatasToDb
    {
        private readonly string _apiUrl = "https://turkiyeapi.cyclic.app";
        private readonly ICityRepository _cityRepository;
        private readonly ITownRepository _townRepository;
        public WriteDatasToDb(ICityRepository cityRepository, ITownRepository townRepository)
        {
            _cityRepository = cityRepository;
            _townRepository = townRepository;
        }
        private class TempData
        {
            public string status { get; set; }
            public List<Cities> data { get; set; }

        }
        private class Cities
        {
            public string name { get; set; }
            public List<District> districts { get; set; }
        }
        private class District
        {
            public string name { get; set; }
        }
        public async Task<T> Execute<T>()
        {
            var path = "/api/v1/provinces";
            var restClient = new RestClient(_apiUrl);
            var restRequest = new RestRequest(path, Method.Get);
            var result = await restClient.ExecuteAsync(restRequest);
            var provinces = JsonConvert.DeserializeObject<T>(result.Content);
            return provinces;
        }
        public async Task GetDatas()
        {
            var result = await Execute<TempData>();
            foreach (var item in result.data)
            {
                var city = await _cityRepository.GetByName(item.name);
                var cityId = string.Empty;
                if (city == null)
                {
                    await _cityRepository.Create(new City { Name = item.name });
                    city = await _cityRepository.GetByName(item.name);
                }
                cityId = city.Id;
                item.districts.ForEach(async x =>
                {
                    if (!await _townRepository.CheckTownExistsByCityId(cityId, x.name))
                        await _townRepository.Create(new Town { CityId = cityId, Name = x.name });
                });

            }
        }
    }
}
