using ComputerInventory.Helpers.Utils;
using ComputerInventory.Models;
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
    public class RamViewModel : ComputeryBaseViewModel
    {
        public ObservableCollection<Ram> RamItems { get; set; }
        public ICommand GetRamsBySize { get; }
        public ICommand GetAllRams { get; }
        private Ram _ramSelected;

        public RamViewModel()
        {            
            RamItems = new ObservableCollection<Ram>();
            GetRamsBySize = new Command<int>(async (size) => await GetRamsBySizeCommand(size));
            GetAllRams = new Command(async () => await GetAllRamsCommand());
        }        

        public override async Task InitializeAsync(object navigationData)
        {
            Title = "RAM Memories";
            await LoadData(Constants.RamUrl);
        }

        protected override async Task LoadData(string url)
        {
            try
            {
                IsBusy = true;
                var response = await _service.Get<Ram>(url);
                if (!response.IsSuccess)
                {
                    await DialogService.ShowMessage(response.Message, "Error");
                    return;
                }
                ListToObservableCollection((List<Ram>)response.Result);
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

        private void ListToObservableCollection(List<Ram> rams)
        {
            RamItems.Clear();
            ObservableCollection<Ram> collection = new ObservableCollection<Ram>(rams);
            RamItems = collection;
        }

        //crear el servicio web
        private async Task GetRamsBySizeCommand(int value)
        {
            await LoadData(Constants.RamAbove8Url);
        }

        private async Task GetAllRamsCommand()
        {
            await LoadData(Constants.RamUrl);
        }

        public Ram RamSelected
        {
            get => _ramSelected;
            set {
                SetProperty(ref _ramSelected, value);
                if (_ramSelected != null)
                {
                    NavigationService.NavigateToAsync<RamDetailsViewModel>(_ramSelected);
                }
            }
        }
    }
}
