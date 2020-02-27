using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ComputerInventory.ViewModels;
using ComputerInventory.ViewModels.Base;
using Xamarin.Forms;

namespace ComputerInventory.Services.NavigationService
{
    public class NavigationService : INavigationService
    {
        
        public Task InitializeAsync()
        {
            return NavigateToAsync<DashboardViewModel>();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            if (Application.Current.MainPage is NavigationPage mainPage)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public async Task GoBack()
        {
            switch (Application.Current.MainPage)
            {
                case NavigationPage mainPage:
                    await mainPage.PopAsync();
                    break;

                case MasterDetailPage masterDetail:
                    await((NavigationPage)masterDetail.Detail).PopAsync();
                    break;
            }
        }


        public Task NavigateToAsync<TViewModel>() where TViewModel : ComputeryBaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }        

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ComputeryBaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }        

        public Task ChangeDetailsAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task ChangeDetailsAsync(Type viewModelType, bool parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);            

            switch (Application.Current.MainPage)
            {
                case NavigationPage navigationPage:
                    await navigationPage.PushAsync(page);
                    break;

                case MasterDetailPage masterDetailPage:
                    await ((NavigationPage)masterDetailPage.Detail).PushAsync(page);
                    masterDetailPage.IsPresented = false;
                    break;

                default:
                    Application.Current.MainPage = new NavigationPage(page);
                    break;
            }

            await (page.BindingContext as ComputeryBaseViewModel).InitializeAsync(parameter);
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;

            ComputeryBaseViewModel viewModel = ViewModelLocator.Resolve(viewModelType) as ComputeryBaseViewModel;
            page.BindingContext = viewModel;

            return page;
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }
    }
}
