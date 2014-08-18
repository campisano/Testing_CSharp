using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLayer.Domain.Entity;
using NLayer.Domain.InMemoryRepository;
using NLayer.Domain.Repository;
using NLayer.Domain.Service.SystemOperation;
using NLayer.Presentation.IView;
using NLayer.Presentation.Presenter;
using NLayer.Test.Mock;
using System.Collections.Generic;

namespace NLayer.Test.Test
{
    [TestClass]
    public class LogChangeDisplayPropertiesTest
    {
        private I_LogRepository _logRepository;
        private I_LogApparenceRepository _logApparenceRepository;

        [TestInitialize]
        public void Initialize()
        {
            List<Log> logs = new List<Log>();
            _logRepository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = _logRepository;
            _logApparenceRepository = new InMemoryLogApparenceRepository(logs);
            LogService.Instance.LogApparenceRepository = _logApparenceRepository;
        }

        [TestMethod]
        public void ChangePropertiesActionMustChangeLogDisplayDataOnLogDrawView()
        {
            I_LogDrawView logDrawView;

            // Arrange
            {
                _logRepository.AddLog(new Log("DTC"));
                LogService.Instance.SetLogApparence("DTC", "Yellow", 3); //TODO [CMP] enum seem better for color and thickness too
                logDrawView = new LogDrawViewMock();
                LogDrawPresenter presenter = new LogDrawPresenter(logDrawView);
            }

            // Act
            {
                logDrawView.LogName = "DTC";
                logDrawView.DoDraw.Execute();
                I_LogChangeDisplayPropertiesView view = new LogChangeDisplayPropertiesViewMock();
                LogChangeDisplayPropertiesPresenter presenter = new LogChangeDisplayPropertiesPresenter(view);

                view.LogName = "DTC";
                view.LogColor = "Red";
                view.LogThickness = 5;
                view.DoChange.Execute();
            }

            // Assert
            {
                Assert.AreEqual("Red", logDrawView.Color);
                Assert.AreEqual(5, logDrawView.Thickness);
            }
        }
    }
}
