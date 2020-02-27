using ComputerInventory.Services;
using ComputerInventory.Services.Dialog;
using ComputerInventory.Services.NavigationService;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInventory.ViewModels.Base
{ 
    public abstract class ComputeryBaseViewModel : BaseViewModel
    {
        public INavigationService NavigationService;
        protected ApiService _service;
        public IDialogService DialogService { get; set; }
        private bool _isEnabled;
        private bool _isRefreshing;
        public ComputeryBaseViewModel()
        {
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            DialogService = new DialogService();
            _service = new ApiService();
        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                SetProperty(ref _isEnabled, value);
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                SetProperty(ref _isRefreshing, value);
            }
        }

        protected virtual Task LoadData(string url)
        {
            return Task.FromResult(false);
        }
    }
}
