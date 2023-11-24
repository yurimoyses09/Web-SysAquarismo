namespace Web.SysAquarismo.Services.InfoPeixeService
{
    public interface IInfoPeixeService
    {
        Task<dynamic> GetDadosPeixe(int id);
    }
}
