﻿using Core.Interfaces;
using Infrastructue.Data;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });


            //services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            //services.AddDbContext<StoreContext>(opt =>
            //{
            //    opt.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            //});
            //services.AddSingleton<IConnectionMultiplexer>(c =>
            //{
            //    var options = ConfigurationOptions.Parse(config.GetConnectionString("Redis"));
            //    return ConnectionMultiplexer.Connect(options);
            ////});
            //services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IPaymentService, PaymentService>();
            //services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.InvalidModelStateResponseFactory = actionContext =>
            //    {
            //        var errors = actionContext.ModelState
            //            .Where(e => e.Value.Errors.Count > 0)
            //            .SelectMany(x => x.Value.Errors)
            //            .Select(x => x.ErrorMessage).ToArray();

            //        var errorResponse = new ApiValidationErrorResponse
            //        {
            //            Errors = errors
            //        };

            //        return new BadRequestObjectResult(errorResponse);
            //    };
            //});

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });

            return services;
        }
    }
}
