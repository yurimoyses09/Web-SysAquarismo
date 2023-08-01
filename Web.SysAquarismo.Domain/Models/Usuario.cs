namespace Web.SysAquarismo.Domain.Models;


public class Usuario
{
    public List<Data> data { get; set; }
}

public class Data
{
    public int id_Usuario { get; set; }
    public object nome_Usuario { get; set; }
    public int idade { get; set; }
    public object ds_Telefone { get; set; }
    public object ds_Email { get; set; }
    public string ds_Nome_Usuario_Login { get; set; }
    public object ds_Senha { get; set; }
    public object sexo { get; set; }
    public object ds_Pais { get; set; }
    public List<Peixe> peixes { get; set; }
}


