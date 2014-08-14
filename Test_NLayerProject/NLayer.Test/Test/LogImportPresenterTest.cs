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
    public class LogImportPresenterTest
    {
        [TestMethod]
        public void ShouldViewDoImportReturnConfirmation()
        {
            // Arrange
            List<Log> logs = new List<Log>();
            I_LogRepository repository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = repository;

            // Act
            I_LogImportView view = new LogImportViewMock();
            LogImportPresenter presenter = new LogImportPresenter(view);

            view.InputFilePath = "Data/DTC.dat";
            view.LogName = "DTC";
            view.DoImport.Execute();

            // Assert
            Assert.AreEqual(1, repository.GetAllLogs().Count());
            Assert.AreEqual("Log imported: " + repository.GetAllLogs().First().Values.Count + " points.", view.MessageResult);
        }
    }
}
