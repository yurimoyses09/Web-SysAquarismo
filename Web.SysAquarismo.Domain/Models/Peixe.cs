namespace Web.SysAquarismo.Domain.Models;

public class Peixe
{
    public int id_Peixe { get; set; }
    public int id_Usuario { get; set; }
    public string ds_Nome_Peixe { get; set; }
    public string ds_Nome_Especie { get; set; }
    public object ds_Descricao { get; set; }
    public object sexo { get; set; }
    public int vl_Peso { get; set; }
    public int vl_Tamanho { get; set; }
    public DateTime ds_Data_Morte { get; set; }
    public string ds_Imagem { get; set; }
    public object ds_status_Saude { get; set; }
    public string ds_doenca { get; set; }
    public DateTime ds_Data_Aquisicao { get; set; }
}
