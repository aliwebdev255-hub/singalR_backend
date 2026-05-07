using singalR_project.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// SignalR
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); 


app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();


app.MapHub<NotificationHub>("/notificationHub");

app.Run();