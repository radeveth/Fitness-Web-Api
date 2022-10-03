using FitnessWebApi.Data;
using FitnessWebApi.Services.Data.BodyPartsServices;
using FitnessWebApi.Services.Data.EquipmentsServices;
using FitnessWebApi.Services.Data.ExercisesServices;
using FitnessWebApi.Services.Data.TargetMusclesServices;
using FitnessWebApi.Services.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<FitnessWebApiDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<FitnessWebApiDbContext>();
        builder.Services.AddControllersWithViews();

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile<ExercisesProfile>();
            config.AddProfile<BodyPartsProfile>();
            config.AddProfile<EquipmentsProfile>();
            config.AddProfile<TargetMusclesProfile>();
        });

        builder.Services.AddTransient<IExerciseService, ExerciseService>();
        builder.Services.AddTransient<IBodyPartService, BodyPartService>();
        builder.Services.AddTransient<IEquipmentService, EquipmentService>();
        builder.Services.AddTransient<ITargetMuscleService, TargetMuscleService>();

        // Named Policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                name: "CORSPlolicy",
                builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("https://localhost:7000", "https://appname.azurewebsites.net");
                });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseCors("CorsPolicy");

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}