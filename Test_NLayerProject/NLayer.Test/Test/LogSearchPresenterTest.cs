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
        private I_LogRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new InMemoryLogRepository(new List<Log>());
            LogService.Instance.LogRepository = _repository;
        }

        [TestMethod]
        public void ShouldViewOpenReturnAllLogs()
        {
            // Arrange
            _repository.AddLog(new Log("GRAY"));
            _repository.AddLog(new Log("DTS"));
            _repository.AddLog(new Log("Gsobr"));

            // Act
            I_LogSearchView view = new LogSearchViewMock();
            LogSearchPresenter presenter = new LogSearchPresenter(view);

            // Assert
            Assert.AreEqual(3, view.SearchResults.Count);
            CollectionAssert.AreEquivalent(_repository.GetAllLogs().Select(l => l.Name).ToList(), (List<string>)view.SearchResults);
        }

        [TestMethod]
        public void ShouldViewDoSearchEmptyReturnAllLogs()
        {
            // Arrange
            _repository.AddLog(new Log("GRAY"));
            _repository.AddLog(new Log("DTS"));
            _repository.AddLog(new Log("Gsobr"));

            // Act
            I_LogSearchView view = new LogSearchViewMock();
            LogSearchPresenter presenter = new LogSearchPresenter(view);

            view.SearchQuery = string.Empty;
            view.DoSearch.Execute();

            // Assert
            Assert.AreEqual(3, view.SearchResults.Count);
            CollectionAssert.AreEquivalent(_repository.GetAllLogs().Select(l => l.Name).ToList(), (List<string>)view.SearchResults);
        }

        [TestMethod]
        public void ShouldViewDoSearchAgremisReturnAgremis()
        {
            // Arrange
            _repository.AddLog(new Log("GRAY"));
            _repository.AddLog(new Log("DTS"));
            _repository.AddLog(new Log("Gsobr"));

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
            _repository.AddLog(new Log("GRAY"));
            _repository.AddLog(new Log("DTS"));
            _repository.AddLog(new Log("Gsobr"));

            // Act
            I_LogSearchView view = new LogSearchViewMock();
            LogSearchPresenter presenter = new LogSearchPresenter(view);

            view.SearchQuery = "Gsobr";
            view.DoSearch.Execute();
            view.DoReset.Execute();

            // Assert
            Assert.AreEqual(3, view.SearchResults.Count);
            CollectionAssert.AreEquivalent(_repository.GetAllLogs().Select(l => l.Name).ToList(), (List<string>)view.SearchResults);
        }

        [TestMethod]
        public void SearchQueryMustBeEmptyAfterReset()
        {
            // Arrange
            _repository.AddLog(new Log("GRAY"));
            _repository.AddLog(new Log("DTS"));
            _repository.AddLog(new Log("Gsobr"));

            // Act
            I_LogSearchView view = new LogSearchViewMock();
            LogSearchPresenter presenter = new LogSearchPresenter(view);

            view.SearchQuery = "Gsobr";
            view.DoReset.Execute();

            // Assert
            Assert.AreEqual(string.Empty, view.SearchQuery);
        }

        //TODO [BSA]: dividir o test em unidades base (service / presenter / view)
    }
}
