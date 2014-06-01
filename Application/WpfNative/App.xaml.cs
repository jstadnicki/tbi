using System.Windows;

namespace WpfNative
{
    using Microsoft.Practices.Unity;

    using ToBeImplemented.Business.Implementations;
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Implementations;
    using ToBeImplemented.Service.Interfaces;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ITbiContext, TbiContext>();
            container.RegisterType<IConceptRepository, ConceptRepository>();
            container.RegisterType<ITagRepository, TagRepository>();
            container.RegisterType<IConceptService, ConceptService>();
            container.RegisterType<IConceptLogic, ConceptLogic>();
            container.RegisterType<MainWindow>();

            TbiMapper.Initialize();


            var mainwindow = container.Resolve<MainWindow>();
            mainwindow.Show();


        }
    }
}
