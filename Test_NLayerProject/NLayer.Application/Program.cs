using NLayer.Domain.InMemoryRepository;
using NLayer.Domain.Repository;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;
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
                ICustomerRepository repository = new InMemoryCustomerRepository(customers);
                CustomerService.Instance.Repository = repository;

                var container = new IODContainer();

                //container.RegisterType(typeof(ICustomerSearchView), typeof(NLayer.WPF.CustomerSearchView));
                container.RegisterType(typeof(ICustomerSearchView), typeof(NLayer.WPFMVVM.View.CustomerSearchView));

                var mainWindow = container.Resolve<Window>(typeof(ICustomerSearchView));
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
