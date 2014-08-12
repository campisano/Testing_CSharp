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
    public class ViewDrawLogPresenterTest
    {
        [TestMethod]
        public void ShouldViewShowSpecificLog()
        {
            // Prepare
            List<Log> logs = new List<Log>();
            logs.Add(new Log("DTC"));
            logs.Add(new Log("GRAY"));
            logs.Add(new Log("DTS"));
            ILogRepository logRepository = new InMemoryLogRepository(logs);
            LogService.Instance.LogRepository = logRepository;
            ILogApparenceRepository logApparenceRepository = new InMemoryLogApparenceRepository(logs);
            LogService.Instance.LogApparenceRepository = logApparenceRepository;


            Log testLog = logs[1];
            string color = "Yellow";
            int thickness = 3;
            LogService.Instance.SetLogApparence(testLog.Name, color, thickness); //TODO [CMP] enum seem better for color and thickness too

            IDrawLogView view = new DrawLogViewMock();
            {
                DrawLogPresenter presenter = new DrawLogPresenter(view);
            }

            // Act
            view.Name = testLog.Name;
            view.DoDraw.Execute();

            // Test
            Assert.AreEqual(testLog.Name, view.Name);
            Assert.AreEqual(color, view.Color);
            Assert.AreEqual(thickness, view.Thickness);
            Assert.AreEqual(testLog.Values.Count, view.Points.Count);
        }
    }
}
