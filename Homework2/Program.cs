using Homework2.Data;
using Homework2.Models;
using Homework2.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

//builder.services.adddbcontext<applicationdbcontext>(options =>
//options.usemysql(connectionstring,serverversion.autodetect(connectionstring)));    


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => {
    options.SignIn.RequireConfirmedAccount = true;      
    //options.SignIn.RequireConfirmedEmail = true;    
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;

})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IClassroomRepository, SQLClassroomRepository>();
builder.Services.AddScoped<IClassroomUserRepository, SQLClassroomUserRepository>();
builder.Services.AddScoped<IBlackBoardRepository, SQLBlackBoardRepository>();
builder.Services.AddScoped<IInviteRepository, SQLInviteRepository>();
builder.Services.AddScoped<IAssignmentRepository, SQLAssignmentRepository>();
builder.Services.AddScoped<ISubmittedAssignmentRepository, SQLSubmittedAssignmentRepository>();
builder.Services.AddScoped<ICommentRepository, SQLCommentRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
