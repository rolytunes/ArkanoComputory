using ComputerInventory.Services.Dialog;
using ComputerInventory.Services.NavigationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerInventory.ViewModels.Base
{
    public class ViewModelLocator
    {
        private static readonly TinyIoCContainer _container;

        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();
            //view models
            _container.Register<DashboardViewModel>();
            _container.Register<ComputerViewModel>();
            _container.Register<RamViewModel>();
            _container.Register<RamDetailsViewModel>();

            //services
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IDialogService, DialogService>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
