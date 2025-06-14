using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserLedgerSimulation.MiddleWare
{
    public static class Startup
    {
        public static void AddDatabaseContext(this WebApplicationBuilder builder) => builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
        public static void AddControllers(this WebApplicationBuilder builder) => builder.Services.AddControllers(options =>
        {
            options.ReturnHttpNotAcceptable = true;
            options.Filters.Add(new ProducesAttribute("application/json", "text/plain"));
        });
        public static void AddAutoMapper(this WebApplicationBuilder builder) => builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
