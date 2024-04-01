
using System.Reflection;
using Tochka.JsonRpc.Server.Extensions;
using Tochka.JsonRpc.Swagger;

namespace JsonRPCServiceExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            builder.Services.AddJsonRpcServer();
            builder.Services.AddSwaggerWithJsonRpc(Assembly.GetExecutingAssembly());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI(c => c.JsonRpcSwaggerEndpoints(app.Services));  
            }

            app.UseJsonRpc();

            app.UseAuthorization();

            app.UseRouting();
            
            app.MapControllers();
            app.MapSwagger();

            app.Run();
        }
    }
}
