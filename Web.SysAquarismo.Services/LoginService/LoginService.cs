using Newtonsoft.Json;
using System.Text;

namespace Web.SysAquarismo.Services.LoginService;

public class LoginService : ILoginService
{
    public async Task<bool> Login(string username, string password)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        string url = "https://localhost:5001/api/v1/usuario/login";

        try
        {
            var dados = new
            {
                nome_usuario = username,
                senha = password
            };

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
        catch (Exception ex)
        {
            throw;
        }
    }
}
