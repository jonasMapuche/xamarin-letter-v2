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

            LetterService.ConnectionLetter = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionLetter"); ;
            LetterService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            LetterService.CollectionLetter = Configuration.GetValue<string>("ConnectionDevelopment:CollectionLetter");
            PronounService.ConnectionPronoun = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionPronoun");
            PronounService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            PronounService.CollectionPronoun = Configuration.GetValue<string>("ConnectionDevelopment:CollectionPronoun");
            ArticleService.ConnectionArticle = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionArticle");
            ArticleService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            ArticleService.CollectionArticle = Configuration.GetValue<string>("ConnectionDevelopment:CollectionArticle");
            PrepositionService.ConnectionPreposition = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionPreposition");
            PrepositionService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            PrepositionService.CollectionPreposition = Configuration.GetValue<string>("ConnectionDevelopment:CollectionPreposition");
            ConjunctionService.ConnectionConjunction = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionConjunction");
            ConjunctionService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            ConjunctionService.CollectionConjunction = Configuration.GetValue<string>("ConnectionDevelopment:CollectionConjunction");
            AdverbService.ConnectionAdverb = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionAdverb");
            AdverbService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            AdverbService.CollectionAdverb = Configuration.GetValue<string>("ConnectionDevelopment:CollectionAdverb");
            NumeralService.ConnectionNumeral = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionNumeral");
            NumeralService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            NumeralService.CollectionNumeral = Configuration.GetValue<string>("ConnectionDevelopment:CollectionNumeral");
            VerbService.ConnectionVerb = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionVerb");
            VerbService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            VerbService.CollectionVerb = Configuration.GetValue<string>("ConnectionDevelopment:CollectionVerb");
            AuxiliaryService.ConnectionAuxiliary = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionAuxiliary");
            AuxiliaryService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            AuxiliaryService.CollectionAuxiliary = Configuration.GetValue<string>("ConnectionDevelopment:CollectionAuxiliary");
            SentenceService.ConnectionSentence = Configuration.GetValue<string>("ConnectionDevelopment:ConnectionSentence");
            SentenceService.DatabaseName = Configuration.GetValue<string>("ConnectionDevelopment:DatabaseName");
            SentenceService.CollectionSentence = Configuration.GetValue<string>("ConnectionDevelopment:CollectionSentence");

            LetterService.ConnectionValence = Configuration.GetValue<string>("ConnectionTest:ConnectionLetter");
            LetterService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            LetterService.CollectionLetter = Configuration.GetValue<string>("ConnectionTest:CollectionLetter");
            PronounService.ConnectionArtless = Configuration.GetValue<string>("ConnectionTest:ConnectionPronoun");
            PronounService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            PronounService.CollectionPronoun = Configuration.GetValue<string>("ConnectionTest:CollectionPronoun");
            ArticleService.ConnectionNoten = Configuration.GetValue<string>("ConnectionTest:ConnectionArticle");
            ArticleService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            ArticleService.CollectionArticle = Configuration.GetValue<string>("ConnectionTest:CollectionArticle");
            PrepositionService.ConnectionArticle = Configuration.GetValue<string>("ConnectionTest:ConnectionPreposition");
            PrepositionService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            PrepositionService.CollectionPreposition = Configuration.GetValue<string>("ConnectionTest:CollectionPreposition");
            ConjunctionService.ConnectionPreposition = Configuration.GetValue<string>("ConnectionTest:ConnectionConjunction");
            ConjunctionService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            ConjunctionService.CollectionConjunction = Configuration.GetValue<string>("ConnectionTest:CollectionConjunction");
            AdverbService.ConnectionPeriodic = Configuration.GetValue<string>("ConnectionTest:ConnectionAdverb");
            AdverbService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            AdverbService.CollectionAdverb = Configuration.GetValue<string>("ConnectionTest:CollectionAdverb");
            NumeralService.ConnectionPeriodic = Configuration.GetValue<string>("ConnectionTest:ConnectionNumeral");
            NumeralService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            NumeralService.CollectionNumeral = Configuration.GetValue<string>("ConnectionTest:CollectionNumeral");
            VerbService.ConnectionConjunction = Configuration.GetValue<string>("ConnectionTest:ConnectionVerb");
            VerbService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            VerbService.CollectionVerb = Configuration.GetValue<string>("ConnectionTest:CollectionVerb");
            AuxiliaryService.ConnectionNumeral = Configuration.GetValue<string>("ConnectionTest:ConnectionAuxiliary");
            AuxiliaryService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            AuxiliaryService.CollectionAuxiliary = Configuration.GetValue<string>("ConnectionTest:CollectionAuxiliary");
            SentenceService.ConnectionVerb = Configuration.GetValue<string>("ConnectionTest:ConnectionSentence");
            SentenceService.DatabaseName = Configuration.GetValue<string>("ConnectionTest:DatabaseName");
            SentenceService.CollectionSentence = Configuration.GetValue<string>("ConnectionTest:CollectionSentence");

            LetterService.ConnectionChord = Configuration.GetValue<string>("ConnectionProduction:ConnectionLetter");
            LetterService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            LetterService.CollectionLetter = Configuration.GetValue<string>("ConnectionProduction:CollectionLetter");
            PronounService.ConnectionPeriodic = Configuration.GetValue<string>("ConnectionProduction:ConnectionPronoun");
            PronounService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            PronounService.CollectionPronoun = Configuration.GetValue<string>("ConnectionProduction:CollectionPronoun");
            ArticleService.ConnectionMalware = Configuration.GetValue<string>("ConnectionProduction:ConnectionArticle");
            ArticleService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            ArticleService.CollectionArticle = Configuration.GetValue<string>("ConnectionProduction:CollectionArticle");
            PrepositionService.ConnectionPronoun = Configuration.GetValue<string>("ConnectionProduction:ConnectionPreposition");
            PrepositionService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            PrepositionService.CollectionPreposition = Configuration.GetValue<string>("ConnectionProduction:CollectionPreposition");
            ConjunctionService.ConnectionValence = Configuration.GetValue<string>("ConnectionProduction:ConnectionConjunction");
            ConjunctionService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            ConjunctionService.CollectionConjunction = Configuration.GetValue<string>("ConnectionProduction:CollectionConjunction");
            AdverbService.ConnectionActivity = Configuration.GetValue<string>("ConnectionProduction:ConnectionAdverb");
            AdverbService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            AdverbService.CollectionAdverb = Configuration.GetValue<string>("ConnectionProduction:CollectionAdverb");
            NumeralService.ConnectionActivity = Configuration.GetValue<string>("ConnectionProduction:ConnectionNumeral");
            NumeralService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            NumeralService.CollectionNumeral = Configuration.GetValue<string>("ConnectionProduction:CollectionNumeral");
            VerbService.ConnectionValence = Configuration.GetValue<string>("ConnectionProduction:ConnectionVerb");
            VerbService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            VerbService.CollectionVerb = Configuration.GetValue<string>("ConnectionProduction:CollectionVerb");
            AuxiliaryService.ConnectionPronoun = Configuration.GetValue<string>("ConnectionProduction:ConnectionAuxiliary");
            AuxiliaryService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            AuxiliaryService.CollectionAuxiliary = Configuration.GetValue<string>("ConnectionProduction:CollectionAuxiliary");
            SentenceService.ConnectionChord = Configuration.GetValue<string>("ConnectionProduction:ConnectionSentence");
            SentenceService.DatabaseName = Configuration.GetValue<string>("ConnectionProduction:DatabaseName");
            SentenceService.CollectionSentence = Configuration.GetValue<string>("ConnectionProduction:CollectionSentence");

            /*
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
            PrepositionService.ConnectionPreposition = Configuration.GetConnectionString("ConnectionPreposition");
            PrepositionService.ConnectionArticle = Configuration.GetConnectionString("ConnectionArticle");
            PrepositionService.ConnectionPronoun = Configuration.GetConnectionString("ConnectionPronoun");
            PrepositionService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            PrepositionService.CollectionPreposition = Configuration.GetConnectionString("CollectionPreposition");
            ConjunctionService.ConnectionConjunction = Configuration.GetConnectionString("ConnectionConjunction");
            ConjunctionService.ConnectionPreposition = Configuration.GetConnectionString("ConnectionPreposition");
            ConjunctionService.ConnectionValence = Configuration.GetConnectionString("ConnectionValence");
            ConjunctionService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            ConjunctionService.CollectionConjunction = Configuration.GetConnectionString("CollectionConjunction");
            AdverbService.ConnectionAdverb = Configuration.GetConnectionString("ConnectionAdverb");
            AdverbService.ConnectionPeriodic = Configuration.GetConnectionString("ConnectionPeriodic");
            AdverbService.ConnectionActivity = Configuration.GetConnectionString("ConnectionActivity");
            AdverbService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            AdverbService.CollectionAdverb = Configuration.GetConnectionString("CollectionAdverb");
            NumeralService.ConnectionNumeral = Configuration.GetConnectionString("ConnectionNumeral");
            NumeralService.ConnectionPeriodic = Configuration.GetConnectionString("ConnectionPeriodic");
            NumeralService.ConnectionActivity = Configuration.GetConnectionString("ConnectionActivity");
            NumeralService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            NumeralService.CollectionNumeral = Configuration.GetConnectionString("CollectionNumeral");
            VerbService.ConnectionVerb = Configuration.GetConnectionString("ConnectionVerb");
            VerbService.ConnectionConjunction = Configuration.GetConnectionString("ConnectionConjunction");
            VerbService.ConnectionValence = Configuration.GetConnectionString("ConnectionValence");
            VerbService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            VerbService.CollectionVerb = Configuration.GetConnectionString("CollectionVerb");
            AuxiliaryService.ConnectionAuxiliary = Configuration.GetConnectionString("ConnectionAuxiliary");
            AuxiliaryService.ConnectionNumeral = Configuration.GetConnectionString("ConnectionNumeral");
            AuxiliaryService.ConnectionPronoun = Configuration.GetConnectionString("ConnectionPronoun");
            AuxiliaryService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            AuxiliaryService.CollectionAuxiliary = Configuration.GetConnectionString("CollectionAuxiliary");
            SentenceService.ConnectionSentence = Configuration.GetConnectionString("ConnectionSentence");
            SentenceService.ConnectionVerb = Configuration.GetConnectionString("ConnectionVerb");
            SentenceService.ConnectionChord = Configuration.GetConnectionString("ConnectionChord");
            SentenceService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            SentenceService.CollectionSentence = Configuration.GetConnectionString("CollectionSentence");
            */

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
