using CRUD.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD", Version = "v1" });
            });

            LetterService.ConnectionLetter = Configuration.GetConnectionString("ConnectionLetter");
            LetterService.ConnectionValence = Configuration.GetConnectionString("ConnectionValence");
            LetterService.ConnectionChord = Configuration.GetConnectionString("ConnectionChord");
            LetterService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            LetterService.CollectionLetter = Configuration.GetConnectionString("CollectionLetter");
            LetterService.JsonFile = Configuration.GetConnectionString("JsonFile");
            PronounService.ConnectionPronoun = Configuration.GetConnectionString("ConnectionPronoun");
            PronounService.ConnectionArtless = Configuration.GetConnectionString("ConnectionArtless");
            PronounService.ConnectionPeriodic = Configuration.GetConnectionString("ConnectionPeriodic");
            PronounService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            PronounService.CollectionPronoun = Configuration.GetConnectionString("CollectionPronoun");
            ArticleService.ConnectionArticle = Configuration.GetConnectionString("ConnectionArticle");
            ArticleService.ConnectionNoten = Configuration.GetConnectionString("ConnectionNoten");
            ArticleService.ConnectionMalware = Configuration.GetConnectionString("ConnectionMalware");
            ArticleService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            ArticleService.CollectionArticle = Configuration.GetConnectionString("CollectionArticle");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
