using ABC.TODOAPP.BUSİNESS.Interfaces;
using ABC.TODOAPP.BUSİNESS.Mapping.AutoMapper;
using ABC.TODOAPP.BUSİNESS.Services;
using ABC.TODOAPP.BUSİNESS.ValidationRules;
using ABC.TODOAPP.DATAACCESS;
using ABC.TODOAPP.DATAACCESS.Interfaces;
using ABC.TODOAPP.DATAACCESS.Repositories;
using ABC.TODOAPP.DATAACCESS.UnitOfWork;
using ABC.TODOAPP.DTOs.WorkDTOs;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.BUSİNESS.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services,string ConnectionString )
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer(ConnectionString, opt =>
                {
                    opt.MigrationsAssembly(Assembly.GetAssembly(typeof(TodoContext)).GetName().Name);
                });
            });
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });
            var Mapper = configuration.CreateMapper();
            services.AddSingleton(Mapper);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDTos>, WorkUpdateDtoValidator>();


        }
    }
}
