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
    public class LogListPresenterTest
    {
        [TestMethod]
        public void ShouldViewOpenReturnAllLogs()
        {
            // Arrange
            List<Log> logs = new List<Log>();
            logs.Add(new Log("GRAY"));
            logs.Add(new Log("DTS"));
            logs.Add(new Log("Gsobr"));
            I_LogRepository repository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = repository;

            // Act
            I_LogListView view = new LogListViewMock();
            LogListPresenter presenter = new LogListPresenter(view);

            // Assert
            Assert.AreEqual(logs.Count, view.Logs.Count);
            CollectionAssert.AreEquivalent(logs.Select(l => l.Name).ToList(), view.Logs.ToList());
        }
    }
}
