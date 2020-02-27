using ComputerInventory.Models;
using ComputerInventory.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInventory.ViewModels
{
    public class RamDetailsViewModel : ComputeryBaseViewModel
    {
        private Ram _ramItem;

        public override async Task InitializeAsync(object navigationData)
        {
            Title = "RAM Memories";
            RamItem = navigationData as Ram;
            await LoadData("");
        }

        public Ram RamItem
        {
            get => _ramItem;
            set
            {
                SetProperty(ref _ramItem, value);
            }
        }

        protected override async Task LoadData(string url)
        {
            try
            {
                IsBusy = true;                
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
    }
}
