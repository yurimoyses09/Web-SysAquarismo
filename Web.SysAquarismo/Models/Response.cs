namespace Web.SysAquarismo.Models;

public class Response
{
    public string Mensagem { get; set; }
    public bool Status { get; set; }
    public string Status_code { get; set; }

    public Response() { }

    public Response(string mensagem, bool status, string status_code)
    {
        Mensagem = mensagem;
        Status = status;
        Status_code = status_code;
    }
}
