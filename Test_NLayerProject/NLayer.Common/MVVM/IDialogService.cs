using System;

namespace NLayer.Common.MVVM
{
    public interface IDialogService
    {
        void ShowMessage(string msg);
        void ShowWindow(Type viewInterface, bool isModal = true);
    }
}
