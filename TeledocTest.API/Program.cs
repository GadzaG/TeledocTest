using Microsoft.EntityFrameworkCore;
using TeledocTest.Application.Services;
using TeledocTest.DataAccess;
using TeledocTest.DataAccess.Repositories;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<TeledocDbContext>(
        options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TeledocDbContext)));
        });


    builder.Services.AddScoped<ClientService>();
    builder.Services.AddScoped<ClientRepository>();

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

    

}
catch (Exception e)
{
    Console.WriteLine(e.ToString());    
}

/*
 
[get]       http://localhost/client/get-all
[get]       http://localhost/client/client/get?id=*
[put]       http://localhost/client/client/client/update {body}
[delete]    
[post]      http://localhost/client/client/create {body}
 
*/