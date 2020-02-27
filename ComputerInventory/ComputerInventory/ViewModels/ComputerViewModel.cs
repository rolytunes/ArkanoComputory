using ComputerInventory.Helpers.Utils;
using ComputerInventory.Models;
using ComputerInventory.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInventory.ViewModels
{
    public class ComputerViewModel : ComputeryBaseViewModel
    {
        public ObservableCollection<Computer> Items { get; set; }

        public ComputerViewModel()
        {
            Items = new ObservableCollection<Computer>();
        }
        public override async Task InitializeAsync(object navigationData)
        {
            Title = "Computers";
            await LoadData(Constants.ComputerUrl);
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
    }
}
