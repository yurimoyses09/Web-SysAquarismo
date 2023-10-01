using Newtonsoft.Json;
using System.Text;

namespace Web.SysAquarismo.Services.CadastroPeixeService
{
    public class CadastroPeixeService : ICadastroPeixeService
    {
        public async Task<bool> CadastraPeixe(string nome_peixe, string especie, string descricao_peixe, string sexo, string peso, string tamanho, string st_saude, string dt_morte, string ds_doenca, string dt_aquisao, byte[] img_peixe, string id_usuario)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            string url = "https://localhost:5001/api/v1/peixe/cadastra";

            try
            {
                var dados = new
                {
                    nome_peixe = nome_peixe,
                    nome_especie = String.IsNullOrEmpty(especie) ? string.Empty : especie,
                    descricao = String.IsNullOrEmpty(descricao_peixe) ? string.Empty : descricao_peixe,
                    sexo = sexo,
                    peso = Convert.ToDecimal(peso),
                    tamanho = Convert.ToDecimal(tamanho),
                    status_saude = String.IsNullOrEmpty(st_saude) ? string.Empty : st_saude,
                    dt_morte = Convert.ToDateTime(dt_morte),
                    ds_doenca = String.IsNullOrEmpty(ds_doenca) ? string.Empty : ds_doenca,
                    dt_aquisicao = Convert.ToDateTime(dt_aquisao),
                    ds_imagem = string.Empty,
                    id_usuario = Convert.ToInt16(id_usuario)
                };

                using (var client = new HttpClient())
                {
                    string jsonRequestData = JsonConvert.SerializeObject(dados);

                    var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

                    response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
