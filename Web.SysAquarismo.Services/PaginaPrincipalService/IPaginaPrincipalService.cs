namespace Web.SysAquarismo.Services.PaginaPrincipalService;

public interface IPaginaPrincipalService
{
    Task<dynamic> BuscaDadosUsuario(string nome_usuario);
}
