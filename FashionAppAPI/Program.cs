using FashionApp_Business_Logic;
using FashionApp_Data_Logic;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSingleton<IOutfitRepository>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    return new JsonFileOutfitRepository("outfits.json");
});


// Register OutfitService
builder.Services.AddScoped<OutfitService>(); 

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
