using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Repository.Interface;
//using ProjectRecipeBack.Repository.Repository;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;
//using ProjectRecipeBack.Domain.Enum;

using ProjectRecipe.Model;
using ProjectRecipe.Repository;
using ProjectRecipe.Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();


//********************************************** grupo autentuicacao
// Data Protection and PasswordHasher
builder.Services.AddDataProtection();
builder.Services.AddSingleton<IPasswordHasher<Users>, PasswordHasher<Users>>();

builder.Services.AddHttpContextAccessor();
//*****************************************


//  IOC   **********************************************
// Adicione IOC Category Repositorio e Servico
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
builder.Services.AddScoped<ICategories, CategoriesRepository>();

builder.Services.AddScoped<IDifficultiesServices, DifficultiesServices>();
builder.Services.AddScoped<IDifficulties, DifficultiesRepository>();

builder.Services.AddScoped<IEvaluationServices, EvaluationsServices>();
builder.Services.AddScoped<IEvaluations, EvaluationsRepository>();

builder.Services.AddScoped<IIngredientsServices, IngredientsServices>();
builder.Services.AddScoped<IIngredients, IngredientsRepository>();

builder.Services.AddScoped<ILoginServices, LoginService>();

builder.Services.AddScoped<IRecipesServices, RecipesServices>();
builder.Services.AddScoped<IRecipes, RecipesRepository>();

builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddScoped<IUsers, UsersRepository>();


//**********************************************


// autenticacao microsoft
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Login/LoginUser";
        options.LogoutPath = "/Login/LoginLogout";
        options.AccessDeniedPath = "/Login/LoginNotAutorizado";
    });



// politica de acesso
builder.Services.AddAuthorization(options =>
{
    // hieraqui e por nivel menor para maior
    options.AddPolicy("admin", pb =>
    {
        pb.RequireAuthenticatedUser()
            .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
            .RequireClaim("role", UserTypeEnum.admin.ToString());
    });

    options.AddPolicy("gestor", pb =>
    {
        pb.RequireAuthenticatedUser()
            .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
            .RequireClaim("role", UserTypeEnum.admin.ToString(), UserTypeEnum.gestor.ToString());
    });

    options.AddPolicy("user", pb =>
    {
        pb.RequireAuthenticatedUser()
            .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme)
            .RequireClaim("role", UserTypeEnum.user.ToString(), UserTypeEnum.gestor.ToString(), UserTypeEnum.admin.ToString());
    });

    // todos logados
    options.AddPolicy("LoggedIn", pb =>
    {
        pb.RequireAuthenticatedUser()
            .AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// autenticacao e autorizacao ********************************
app.UseAuthentication(); // Pessoa atenticada
app.UseAuthorization(); //  Autrizacao pagians

//***********************************************************

app.MapRazorPages();

app.Run();
