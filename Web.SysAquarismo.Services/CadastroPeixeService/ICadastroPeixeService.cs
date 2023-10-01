namespace Web.SysAquarismo.Services.CadastroPeixeService;

public interface ICadastroPeixeService
{
    Task<bool> CadastraPeixe(string nome_peixe, string especie, string descricao_peixe, string sexo, string peso, string tamanho, string st_saude, string dt_morte, string ds_doenca, string dt_aquisao, byte[] img_peixe, string id_usuario);
}
