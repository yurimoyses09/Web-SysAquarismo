using Newtonsoft.Json;
using Web.SysAquarismo.Domain.Models;

namespace Web.SysAquarismo.Services.InfoPeixeService
{
    public class InfoPeixeService : IInfoPeixeService
    {
        public async Task<dynamic> GetDadosPeixe(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            string url = $"https://localhost:5001/api/v1/peixe/{id}";

            try
            {
                using (var client = new HttpClient())
                {
                    response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string retorno = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<Peixe>(retorno);
                    }

                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        return false;

                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
