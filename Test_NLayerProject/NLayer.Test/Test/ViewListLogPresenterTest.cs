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
    public class ViewListLogPresenterTest
    {
        [TestMethod]
        public void ShouldViewOpenReturnAllLogs()
        {
            // Prepare
            List<Log> logs = new List<Log>();
            logs.Add(new Log("DTC"));
            logs.Add(new Log("GRAY"));
            logs.Add(new Log("DTS"));
            ILogRepository repository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = repository;

            ILogListView view = new LogListViewMock();
            {
                LogListPresenter presenter = new LogListPresenter(view);
            }

            // Act

            // Test
            Assert.AreEqual(logs.Count, view.Logs.Count);
            CollectionAssert.AreEquivalent(logs.Select(l => l.Name).ToList(), view.Logs.ToList());
        }
    }
}
