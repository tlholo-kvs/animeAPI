using animeAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container 
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SimpleAnimeListContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("simple-anime-list")));

var app = builder.Build();

public partial class Program
{

     
    public static void Main(string[] args) { 
        
    }
}
