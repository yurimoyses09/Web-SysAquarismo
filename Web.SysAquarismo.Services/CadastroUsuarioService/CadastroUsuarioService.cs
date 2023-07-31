using Newtonsoft.Json;
using System.Text;

namespace Web.SysAquarismo.Services.CadastroUsuarioService;

public class CadastroUsuarioService : ICadastroUsuarioService
{
    public async Task<bool> Cadastro(string nome, string idade_usuario, string email_usuario, string sexo_usuario, string pais_origem, string nome_login, string senha_usuario, string telefone_usuario)
    {

        HttpResponseMessage response = new HttpResponseMessage();
        string url = "https://localhost:5001/api/v1/usuario/cadastra";

        try
        {
            var dados = new
            {
                nome_usuario = nome,
                idade = idade_usuario,
                telefone = telefone_usuario,
                email = email_usuario,
                sexo = sexo_usuario,
                pais = pais_origem,
                nome_usuario_login = nome_login,
                senha = senha_usuario
            };

            using (var client = new HttpClient())
            {
                string jsonRequestData = JsonConvert.SerializeObject(dados);

                var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

                response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                    return true;
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
