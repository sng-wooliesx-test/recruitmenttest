using Autofac;
using Microsoft.Extensions.Configuration;
using WooliesXChallenge.Client;
using WooliesXChallenge.Services;
using WooliesXChallenge.Settings;

namespace WooliesXChallenge
{
    public class ApiModule : Module
    {
        private readonly IConfigurationRoot _configuration;

        public ApiModule(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SortService>().As<ISortService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<TrolleyService>().As<ITrolleyService>();
            builder.RegisterType<RecruitmentClient>().As<IRecruitmentClient>();

            builder.Register(c => _configuration.GetSection("RecruitmentClientSettings").Get<RecruitmentClientSettings>()).SingleInstance();
        }// https://wooliesxchallenge20210210203645.azurewebsites.net/
    }
}
