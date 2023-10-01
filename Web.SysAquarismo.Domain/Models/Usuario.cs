namespace Web.SysAquarismo.Domain.Models;


public class Usuario
{
    public Data data { get; set; }
}

public class Data
{
    public int id_usuario { get; set; }
    public object nome_usuario { get; set; }
    public int idade { get; set; }
    public object tefelone { get; set; }
    public object email { get; set; }
    public string nome_login { get; set; }
    public object senha_usuario { get; set; }
    public object sexo { get; set; }
    public object pais { get; set; }
    public List<Peixe> peixes { get; set; }
}


