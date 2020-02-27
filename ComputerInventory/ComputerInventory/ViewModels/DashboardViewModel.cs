using ComputerInventory.Helpers.Utils;
using ComputerInventory.Models;
using ComputerInventory.Services;
using ComputerInventory.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ComputerInventory.ViewModels
{
    public class DashboardViewModel : ComputeryBaseViewModel
    {
        public ObservableCollection<Computer> Items { get; set; }
        public ICommand GoToRamPage { get; }
        public ICommand GoToCompuPage { get; }

        public DashboardViewModel()
        {            
            Items = new ObservableCollection<Computer>();
            GoToRamPage = new Command(async () => await GoToRamPageCommand());
            GoToCompuPage = new Command(async () => await GoToCompuPageCommand());            
        }

        public override async Task InitializeAsync(object navigationData)
        {
            Title = "Computery";
            Subtitle = "Dashboard";            
            await LoadData(Constants.ComputerUrlLimit);
        }

        protected override async Task LoadData(string url)
        {
            try
            {
                IsBusy = true;
                var response = await _service.Get<Computer>(url);
                if (!response.IsSuccess)
                {
                    await DialogService.ShowMessage(response.Message, "Error");
                    return;
                }
                ListToObservableCollection((List<Computer>)response.Result);
            }
            catch (Exception ex)
            {
                await DialogService.ShowMessage(ex.Message, "Error");
            }
            finally
            {
                IsBusy = false;
            }            
        }

        private void ListToObservableCollection(List<Computer> computers)
        {
            Items.Clear();
            ObservableCollection<Computer> collection = new ObservableCollection<Computer>(computers);
            Items = collection;
        }

        private async Task GoToCompuPageCommand()
        {
            await NavigationService.NavigateToAsync<ComputerViewModel>();
        }

        private async Task GoToRamPageCommand()
        {
            await NavigationService.NavigateToAsync<RamViewModel>();
        }
    }
}
