using FashionApp_Business_Logic;
using FashionApp_Data_Logic;
using FashionAppAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddScoped<EmailService>(serviceProvider =>
{
    var config = builder.Configuration.GetSection("EmailSettings");
    return new EmailService(
        smtpHost: config["SmtpHost"],
        smtpPort: int.Parse(config["SmtpPort"]),
        smtpUsername: config["SmtpUsername"],
        smtpPassword: config["SmtpPassword"],
        fromEmail: config["FromEmail"],
        fromName: config["FromName"]
    );
});

builder.Services.AddSingleton<IOutfitRepository>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    return new JsonFileOutfitRepository("outfits.json");
});

builder.Services.AddScoped<OutfitService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();