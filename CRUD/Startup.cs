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

            ArticleService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionArticle");
            ArticleService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            ArticleService.CollectionArticle = Configuration.GetValue<string>("ConnectionDevelopment:CollectionArticle");
            AdverbService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionAdverb");
            AdverbService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            AdverbService.CollectionAdverb = Configuration.GetValue<string>("ConnectionDevelopment:CollectionAdverb");
            AuxiliaryService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionAuxiliary");
            AuxiliaryService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            AuxiliaryService.CollectionAuxiliary = Configuration.GetValue<string>("ConnectionDevelopment:CollectionAuxiliary");
            ConjunctionService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionConjunction");
            ConjunctionService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            ConjunctionService.CollectionConjunction = Configuration.GetValue<string>("ConnectionDevelopment:CollectionConjunction");
            LetterService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionLetter"); ;
            LetterService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            LetterService.CollectionLetter = Configuration.GetValue<string>("ConnectionDevelopment:CollectionLetter");
            NumeralService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionNumeral");
            NumeralService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            NumeralService.CollectionNumeral = Configuration.GetValue<string>("ConnectionDevelopment:CollectionNumeral");
            PrepositionService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionPreposition");
            PrepositionService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            PrepositionService.CollectionPreposition = Configuration.GetValue<string>("ConnectionDevelopment:CollectionPreposition");
            PronounService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionPronoun");
            PronounService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            PronounService.CollectionPronoun = Configuration.GetValue<string>("ConnectionDevelopment:CollectionPronoun");
            SentenceService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionSentence");
            SentenceService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            SentenceService.CollectionSentence = Configuration.GetValue<string>("ConnectionDevelopment:CollectionSentence");
            VerbService.ConnectionDevelopment = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionVerb");
            VerbService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            VerbService.CollectionVerb = Configuration.GetValue<string>("ConnectionDevelopment:CollectionVerb");

            AdverbService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionAdverb");
            ArticleService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionArticle");
            AuxiliaryService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionAuxiliary");
            ConjunctionService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionConjunction");
            LetterService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionLetter");
            NumeralService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionNumeral");
            PrepositionService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionPreposition");
            PronounService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionPronoun");
            SentenceService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionSentence");
            VerbService.ConnectionTest = Configuration.GetValue<string>("ConnectionTest:ConnectionVerb");

            AdverbService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionAdverb");
            ArticleService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionArticle");
            AuxiliaryService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionAuxiliary");
            ConjunctionService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionConjunction");
            LetterService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionLetter");
            NumeralService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionNumeral");
            PrepositionService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionPreposition");
            PronounService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionPronoun");
            SentenceService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionSentence");
            VerbService.ConnectionProduction = Configuration.GetValue<string>("ConnectionProduction:ConnectionVerb");
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
