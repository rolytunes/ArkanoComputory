using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ComputerInventory.Services.Dialog
{
    public class DialogService : IDialogService
    {
        private static DialogService _dialogService;

        public static DialogService GetDialogService()
        {
            if (_dialogService == null)
            {
                _dialogService = new DialogService();
            }
            return _dialogService;
        }

        public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                buttonText);

            //afterHideCallback?.Invoke();
            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                error.Message,
                buttonText);

            //afterHideCallback?.Invoke();
            afterHideCallback?.Invoke();
        }

        public async Task ShowMessage(string message, string title)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                "Accept");
        }

        public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }

        public async Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            var result = await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                buttonConfirmText,
                buttonCancelText);
            
            afterHideCallback?.Invoke(result);
            return result;
        }

        public async Task ShowMessageBox(string message, string title)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                "Accept");
        }
    }
}
