using ComputerInventory.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInventory.Services.NavigationService
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task GoBack();

        Task NavigateToAsync<TViewModel>() where TViewModel : ComputeryBaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ComputeryBaseViewModel;

        Task ChangeDetailsAsync(Type listadoViewModel);

        Task ChangeDetailsAsync(Type listadoViewModel, bool parametro);

        Task RemoveLastFromBackStackAsync();
    }
}
