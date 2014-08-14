using NLayer.Common.MVVM;
using NLayer.Common.Pattern;
using NLayer.Domain.Entity;
using NLayer.Domain.InMemoryRepository;
using NLayer.Domain.Repository;
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
                List<string> customers = new List<string>();
                customers.Add("Agremis");
                customers.Add("Bruno");
                customers.Add("Riccardo");
                customers.Add("Robert");
                customers.Add("Rodrigo");
                customers.Add("Michel");
                ICustomerRepository custRepository = new InMemoryCustomerRepository(customers);
                CustomerService.Instance.Repository = custRepository;

                List<Log> logs = new List<Log>();
                logs.Add(new Log("GRAY"));
                logs.Add(new Log("DTS"));
                LogService.Instance.LogRepository = new InMemoryLogRepository(logs);
                LogService.Instance.LogApparenceRepository = new InMemoryLogApparenceRepository(logs);

                var container = IODContainer.Instance;

                container.RegisterType(typeof(IDialogService), typeof(DialogService));

                //container.RegisterType(typeof(IMainWindowView), typeof(NLayer.WPFMVVM.View.MainWindow));
                container.RegisterType(typeof(IMainWindowView), typeof(NLayer.WPF.MainWindow));

                //container.RegisterType(typeof(ICustomerSearchView), typeof(NLayer.WPFMVVM.View.CustomerSearchView));
                container.RegisterType(typeof(ICustomerSearchView), typeof(NLayer.WPF.CustomerSearchView));

                //container.RegisterType(typeof(IImportLogView), typeof(NLayer.WPFMVVM.View.ImportLogView));
                container.RegisterType(typeof(IImportLogView), typeof(NLayer.WPF.ImportLogView));

                //container.RegisterType(typeof(IImportLogView), typeof(NLayer.WPFMVVM.View.ImportLogView));
                container.RegisterType(typeof(ILogListView), typeof(NLayer.WPF.LogListView));

                var mainWindow = container.Resolve<Window>(typeof(IMainWindowView));
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
