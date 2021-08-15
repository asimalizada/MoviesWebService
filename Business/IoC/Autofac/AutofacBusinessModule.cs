﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.MicrosoftMemoryCache;
using Core.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.IoC.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfMovieDal>().As<IMovieDal>().SingleInstance();
            builder.RegisterType<EfGenreDal>().As<IGenreDal>().SingleInstance();

            builder.RegisterType<MovieManager>().As<IMovieService>().SingleInstance();
            builder.RegisterType<GenreManager>().As<IGenreService>().SingleInstance();

            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
