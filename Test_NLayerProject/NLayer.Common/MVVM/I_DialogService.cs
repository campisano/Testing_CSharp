using System;

namespace NLayer.Common.MVVM
{
    public interface I_DialogService
    {
        void ShowMessage(string msg);
        void ShowWindow(Type viewInterface, bool isModal = true);
    }
}
