using Newtonsoft.Json;
using Web.SysAquarismo.Domain.Models;

namespace Web.SysAquarismo.Services.PaginaPrincipalService;

public class PaginaPrincipalService : IPaginaPrincipalService
{
    public async Task<dynamic> BuscaDadosUsuario(string nome_usuario)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        string url = $"https://localhost:5001/api/v1/usuario/{nome_usuario}";

        try
		{
            using (var client = new HttpClient())
            {
                response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode) 
                {
                    string retorno = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Usuario>(retorno);
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
