namespace Web.SysAquarismo.Services.CadastroUsuarioService;

public interface ICadastroUsuarioService
{
    Task<bool> Cadastro(string nome, string idade_usuario, string email_usuario, string sexo_usuario, string pais_origem, string nome_login, string senha_usuario, string telefone_usuario);
}
