using Autofac.Extensions.DependencyInjection;
using Autofac;
using iTalentBootcamp_Blog.Web.Modules;
using iTalentBootcamp_Blog.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using iTalentBootcamp_Blog.Service.Mapping;
using iTalentBootcamp_Blog.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        //AppDbContext'in bulunduğu assembly alınıyor yani repository (tip güvenli olarak alındı)
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });

});

builder.Services.AddHttpClient<CategoryApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<PostApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});


//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
//    containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();