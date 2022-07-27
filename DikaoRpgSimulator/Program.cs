using DikaoRpgSimulator;
using DikaoRpgSimulator.Data.Repository;
using DikaoRpgSimulator.Domain;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<DikaoRpgSimulator_DbContext>(builder.Configuration["ConnectionString:DikaoRpgSimulator"]);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IBattleRepository, BattleRepository>();
builder.Services.AddScoped<IHeroFactory, HeroFactory>();
builder.Services.AddScoped<ISimulator, Simulator>();
builder.Services.AddScoped<IBattleCreator, BattleCreator>();
builder.Services.AddScoped<IEngine, Engine>();
builder.Services.AddTransient<IMonsterFactory, MonsterFactory>();



var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost(Post.Route, Post.Action);
app.MapPut(Put.Route, Put.Action);
app.MapDelete(Delete.Route, Delete.Action);
app.MapGet(GetAll.Route, GetAll.Action);
app.MapGet(GetId.Route, GetId.Action);
app.MapGet(GetStronger.Route, GetStronger.Action);
app.MapGet(GetLast.Route, GetLast.Action);
app.MapPost(PostNew.Route, PostNew.Action);

//app.UseExceptionHandler("/error");
//app.Map("/error", (HttpContext http) =>
// {
//     var error = http.Features?.Get<IExceptionHandlerFeature>()?.Error;
//     if(error != null)
//     {
//         if (error is SqlException)
//                 return Results.Problem(title: "Database Out", statusCode: 500);

//     }
//     return Results.Problem(title: "An error ocurred", statusCode: 500);
// });

app.Run();
