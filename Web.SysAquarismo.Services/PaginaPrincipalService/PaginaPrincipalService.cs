using Newtonsoft.Json;
using System.Text;

namespace Web.SysAquarismo.Services.PaginaPrincipalService;

public class PaginaPrincipalService : IPaginaPrincipalService
{
    public async Task<dynamic> BuscaDadosUsuario(string nome_usuario)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        string url = "https://localhost:5001/api/v1/usuario/login";

        try
		{
            var dados = new { nome_usuario = nome_usuario };

            using (var client = new HttpClient())
            {
                string jsonRequestData = JsonConvert.SerializeObject(dados);

                var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

                response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                    return true;

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
