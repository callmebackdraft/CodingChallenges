using InnoTractor.Assignment.Api.InputFormatters;
using InnoTractor.Assignment3Logic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(opt =>
{
    opt.InputFormatters.Add(new PlainTextFormatter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterRunningTotalService();

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
