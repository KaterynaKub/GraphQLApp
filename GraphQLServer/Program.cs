using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQLServer.Repositories;
using GraphQLServer.Schemas;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// add notes schema
builder.Services.AddSingleton<ISchema, PatientModelSchema>(services => new PatientModelSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddSingleton<PatientRepository>();
// register graphQL
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true;
}).AddSystemTextJson();

// default setup
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseGraphQLAltair();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// make sure all our schemas registered to route
app.UseGraphQL<ISchema>();

app.Run();