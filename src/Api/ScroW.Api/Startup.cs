using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.SystemTextJson;
using ScroW.Api.GraphQL.Net;

using HotChocolate.AspNetCore;

using ScroW.Application;
using ScroW.Infrastructure;
using ScroW.Api.Filters;
using System.Text.Json.Serialization;



namespace ScroW.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<HttpResponseExceptionFilter>();
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Converters.Add(new InputsJsonConverter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("ScroWCors", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddInfrastructureServices();
            services.AddApplicationServices();

            services.AddGraphQL(builder => builder
                .AddSelfActivatingSchema<ScroWSchema>()
                .AddClrTypeMappings()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(ScroWSchema).Assembly)
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
            );
            services.AddHttpContextAccessor();

            services.AddGraphQLServer()
                .AddQueryType<HotChocolate.Query>()
                .AddMutationType<HotChocolate.Mutation>()
                .ModifyRequestOptions(opt =>
                {
                    opt.IncludeExceptionDetails = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScroW v1"));
            }

            app.UseCors("ScroWCors");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL()
                    .WithOptions(new GraphQLServerOptions
                    {
                        EnableGetRequests = false
                    });
            });
        }
    }
}