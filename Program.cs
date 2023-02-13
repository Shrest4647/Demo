using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddDbContext<MyDBContext>(options => options.UseSqlite("Data Source=publication_database.db"));
builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<MyDBContext>()
    .AddQueryType<Query>()
    // .AddTypeExtension()
    // .AddMutationType<Mutation>()
    .AddMutationType<MutationType>();
var app = builder.Build();

app.MapGraphQL();

app.Run();
