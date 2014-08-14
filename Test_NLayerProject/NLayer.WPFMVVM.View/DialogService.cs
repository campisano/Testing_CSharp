using NLayer.Common.MVVM;
using NLayer.Common.Pattern;
using System;
using System.Windows;

namespace NLayer.WPFMVVM.View
{
    public sealed class DialogService : I_DialogService
    {
        #region Constructors

        public DialogService()
        {
        }

        #endregion

        #region I_DialogService

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        public void ShowWindow(Type viewInterface, bool isModal = true)
        {
            try
            {
                var window = IODContainer.Instance.Resolve<Window>(viewInterface);

                if (isModal)
                {
                    window.ShowDialog();
                }
                else
                {
                    window.Show();
                }
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
            }
        }

        #endregion
    }
}
