using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayer.Domain.Entity;
using NLayer.Domain.InMemoryRepository;
using NLayer.Domain.Repository;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using NLayer.Test.Mock;
using System.Collections.Generic;
using System.Linq;

namespace NLayer.Test.Test
{
    [TestClass]
    public class ImportLogPresenterTest
    {
        [TestMethod]
        public void ShouldViewDoImportReturnConfirmation()
        {
            // Prepare
            List<Log> logs = new List<Log>();
            ILogRepository repository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = repository;

            IImportLogView view = new ImportLogViewMock();
            {
                ImportLogPresenter presenter = new ImportLogPresenter(view);
            }

            // Act
            view.InputFilePath = "Data/DTC.dat";
            view.LogName = "DTC";
            view.DoImport.Execute();

            // Test
            Assert.AreEqual(1, repository.GetAllLogs().Count());
            Assert.AreEqual("Log imported: " + repository.GetAllLogs().First().Values.Count + " points.", view.MessageResult);
        }
    }
}
