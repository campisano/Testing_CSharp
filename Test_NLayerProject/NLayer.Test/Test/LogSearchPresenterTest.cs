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
    //from http://msdn.microsoft.com/en-us/magazine/cc188690.aspx

    [TestClass]
    public class LogSearchPresenterTest
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
            I_LogSearchView view = new LogSearchViewMock();
            LogSearchPresenter presenter = new LogSearchPresenter(view);

            // Assert
            Assert.AreEqual(logs.Count, view.SearchResults.Count);
            CollectionAssert.AreEquivalent(logs.Select(l => l.Name).ToList(), (List<string>)view.SearchResults);
        }

        [TestMethod]
        public void ShouldViewDoSearchEmptyReturnAllLogs()
        {
            // Arrange
            List<Log> logs = new List<Log>();
            logs.Add(new Log("GRAY"));
            logs.Add(new Log("DTS"));
            logs.Add(new Log("Gsobr"));
            I_LogRepository repository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = repository;

            // Act
            I_LogSearchView view = new LogSearchViewMock();
            LogSearchPresenter presenter = new LogSearchPresenter(view);

            view.SearchQuery = string.Empty;
            view.DoSearch.Execute();

            // Assert
            Assert.AreEqual(logs.Count, view.SearchResults.Count);
            CollectionAssert.AreEquivalent(logs.Select(l => l.Name).ToList(), (List<string>)view.SearchResults);
        }

        [TestMethod]
        public void ShouldViewDoSearchAgremisReturnAgremis()
        {
            // Arrange
            List<Log> logs = new List<Log>();
            logs.Add(new Log("GRAY"));
            logs.Add(new Log("DTS"));
            logs.Add(new Log("Gsobr"));
            I_LogRepository repository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = repository;

            // Act
            I_LogSearchView view = new LogSearchViewMock();
            LogSearchPresenter presenter = new LogSearchPresenter(view);

            view.SearchQuery = "Gsobr";
            view.DoSearch.Execute();

            // Assert
            Assert.AreEqual(1, view.SearchResults.Count);
            Assert.AreEqual("Gsobr", view.SearchResults[0]);
        }

        [TestMethod]
        public void ShouldViewResetAfterDoSearchReturnAllLogs()
        {
            // Arrange
            List<Log> logs = new List<Log>();
            logs.Add(new Log("GRAY"));
            logs.Add(new Log("DTS"));
            logs.Add(new Log("Gsobr"));
            I_LogRepository repository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = repository;

            // Act
            I_LogSearchView view = new LogSearchViewMock();
            LogSearchPresenter presenter = new LogSearchPresenter(view);

            view.SearchQuery = "Gsobr";
            view.DoSearch.Execute();
            view.DoReset.Execute();

            // Assert
            Assert.AreEqual(logs.Count, view.SearchResults.Count);
            CollectionAssert.AreEquivalent(logs.Select(l => l.Name).ToList(), (List<string>)view.SearchResults);
        }

        //TODO [BSA]: dividir o test em unidades base (service / presenter / view)
    }
}
