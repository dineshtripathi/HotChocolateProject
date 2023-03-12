using PropertyAccount.Api.ServiceCollectionExtension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHotchocolateServiceCollection(builder.Configuration);


var app = builder.Build();


app.MapGraphQL("");

app.Run();
