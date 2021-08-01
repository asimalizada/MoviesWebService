using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.IoC.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfMovieDal>().As<IMovieDal>();
            builder.RegisterType<EfGenreDal>().As<IGenreDal>();

            builder.RegisterType<MovieManager>().As<IMovieService>();
            builder.RegisterType<GenreManager>().As<IGenreService>();
        }
    }
}
