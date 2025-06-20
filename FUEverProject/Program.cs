﻿using BusinessLogicLayer.Extensions;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using FueverProject.Extensions;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddPresentationLayer();
builder.Services.AddBusinessLogicLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);

//builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
//	.AddEntityFrameworkStores<FueverDbContext>()
//	.AddDefaultTokenProviders();

builder.Services.AddDbContext<FueverDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowAnyHeader() 
              .AllowAnyMethod(); 
    });
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigins");

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
