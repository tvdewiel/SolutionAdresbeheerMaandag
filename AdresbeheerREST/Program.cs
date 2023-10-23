using AdresbeheerBL.Interfaces;
using AdresbeheerBL.Services;
using AdresbeheerDL.Repositories;
using System.Runtime.CompilerServices;

namespace AdresbeheerREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connString = "Data Source=NB21-6CDPYD3\\SQLEXPRESS;Initial Catalog=AdresbeheerMaandag;Integrated Security=True";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IGemeenteRepository>(r=>new GemeenteRepositoryADO(connString));
            builder.Services.AddSingleton<IStraatRepository>(r => new StraatRepositoryADO(connString));
            builder.Services.AddSingleton<StraatService>();
            builder.Services.AddSingleton<GemeenteService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}