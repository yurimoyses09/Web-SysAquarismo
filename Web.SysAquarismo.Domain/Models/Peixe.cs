namespace Web.SysAquarismo.Domain.Models;

public class Peixe
{
    public int id_peixe { get; set; }
    public int id_usuario { get; set; }
    public string nome_peixe { get; set; }
    public string nome_especie { get; set; }
    public object descricao { get; set; }
    public object sexo { get; set; }
    public int peso { get; set; }
    public int tamenho { get; set; }
    public DateTime dt_morte { get; set; }
    public string ds_imagem { get; set; }
    public object ds_saude { get; set; }
    public string ds_doenca { get; set; }
    public DateTime dt_aquisicao { get; set; }
    public string id_saude { get; set; }
}
