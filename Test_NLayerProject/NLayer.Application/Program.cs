using NLayer.Common.MVVM;
using NLayer.Common.Pattern;
using NLayer.Domain.Entity;
using NLayer.Domain.InMemoryRepository;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;
using NLayer.WPFMVVM.View;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace NLayer.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread otherWindowHostingThread = new Thread(new ThreadStart(OnStartup));
                otherWindowHostingThread.SetApartmentState(ApartmentState.STA);
                otherWindowHostingThread.Start();
                otherWindowHostingThread.Join();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Main Exception");
            }
        }

        private static void OnStartup()
        {
            try
            {
                List<Log> logs = new List<Log>();
                logs.Add(new Log("GRAY"));
                logs.Add(new Log("DTS"));
                logs.Add(new Log("Gsobr"));
                LogService.Instance.LogRepository = new InMemoryLogRepository(logs);
                LogService.Instance.LogApparenceRepository = new InMemoryLogApparenceRepository(logs);

                var container = IODContainer.Instance;

                container.RegisterType(typeof(I_DialogService), typeof(DialogService));

                container.RegisterType(typeof(I_MainWindowView), typeof(NLayer.WPFMVVM.View.MainWindow));
                //container.RegisterType(typeof(I_MainWindowView), typeof(NLayer.WPFMVP.MainWindow));

                container.RegisterType(typeof(I_LogSearchView), typeof(NLayer.WPFMVVM.View.LogSearchView));
                //container.RegisterType(typeof(I_LogSearchView), typeof(NLayer.WPFMVP.LogSearchView));

                //container.RegisterType(typeof(I_LogImportView), typeof(NLayer.WPFMVVM.View.LogImportView));
                container.RegisterType(typeof(I_LogImportView), typeof(NLayer.WPFMVP.LogImportView));

                //container.RegisterType(typeof(I_LogListView), typeof(NLayer.WPFMVVM.View.LogListView));
                container.RegisterType(typeof(I_LogListView), typeof(NLayer.WPFMVP.LogListView));

                //container.RegisterType(typeof(I_LogDrawView), typeof(NLayer.WPFMVVM.View.LogDrawView));
                container.RegisterType(typeof(I_LogDrawView), typeof(NLayer.WPFMVP.LogDrawView));

                var mainWindow = container.Resolve<Window>(typeof(I_MainWindowView));
                mainWindow.Show();
                mainWindow.Closed += (s, e) => System.Windows.Threading.Dispatcher.ExitAllFrames();

                System.Windows.Threading.Dispatcher.Run();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "OnStartup Exception");
            }
        }
    }
}
