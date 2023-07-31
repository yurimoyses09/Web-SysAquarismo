using Web.SysAquarismo.Services.CadastroUsuarioService;
using Web.SysAquarismo.Services.LoginService;
using Web.SysAquarismo.Services.PaginaPrincipalService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICadastroUsuarioService, CadastroUsuarioService>();
builder.Services.AddScoped<IPaginaPrincipalService, PaginaPrincipalService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Login}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Login}/{action=Index}");
    endpoints.MapControllerRoute(name: "/Principal", pattern: "{controller=Principal}/{action=Principal}");
    endpoints.MapControllerRoute(name: "/CadastroPeixe", pattern: "{controller=CadastroPeixe}/{action=Index}");
    endpoints.MapControllerRoute(name: "/Cadastro", pattern: "{controller=Cadastro}/{action=Index}");
});

app.Run();
