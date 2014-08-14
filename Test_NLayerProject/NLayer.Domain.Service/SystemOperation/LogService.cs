using NLayer.Domain.Entity;
using NLayer.Domain.Repository;
using NLayer.Domain.Service.SystemOperation.Response;
using NLayer.Domain.Service.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NLayer.Domain.Service.SystemOperation
{
    public class LogService
    {
        private static LogService _instance;

        #region Properties

        public I_LogRepository LogRepository { private get; set; }
        public I_LogApparenceRepository LogApparenceRepository { private get; set; }

        public static LogService Instance
        {
            get { if (_instance == null) _instance = new LogService(); return _instance; }
        }

        #endregion

        #region Constructors

        private LogService()
        {
        }

        #endregion

        #region Methods

        #region public

        public IEnumerable<string> GetAllLogNames()
        {
            return LogRepository.GetAllLogs().Select(l => l.Name).ToList();
        }

        public IEnumerable<string> SearchLogsByName(string name)
        {
            return LogRepository.SearchLogsByName(name).Select(l => l.Name).ToList();
        }

        public bool IsNewLogNameValid(string logName)
        {
            if (logName == null || logName.Trim().Equals(""))
            {
                return false;
            }

            var logs = LogRepository.GetAllLogs();

            return !logs.Where(d => d.Name.Equals(logName)).Any();
        }

        public bool IsLogImportFilePathValid(string inputFilePath)
        {
            // TODO [CMP] usar classe de infraestrutura
            return File.Exists(inputFilePath);
        }

        public bool Import(string inputFilePath, string logName)
        {
            if (!IsLogImportFilePathValid(inputFilePath))
            {
                return false;
            }

            Log log = new Log(logName);

            DatLoader loader = new DatLoader(inputFilePath);

            foreach (var pair in loader.Values)
            {
                log.Values.Add((int)Math.Round(pair.Key * 1000), pair.Value);
            }

            return AddLog(log);
        }

        public void SetLogApparence(string name, string color, int thickness)
        {
            LogApparence logAp = LogApparenceRepository.GetLogApparence(name);

            logAp.Set(color, thickness);
        }

        public LogDrawResponse GetLogDraw(string name)
        {
            Log log = LogRepository.GetLog(name);
            LogApparence logAp = LogApparenceRepository.GetLogApparence(name);

            return new LogDrawResponse(log.Name, log.Values, logAp.Color, logAp.Thickness);
        }

        public int GetLogPointsNum(string name)
        {
            Log log = LogRepository.GetLog(name);

            return log.Values.Count;
        }

        #endregion

        #region private

        private bool AddLog(Log log)
        {
            if (!IsNewLogNameValid(log.Name))
            {
                return false;
            }

            LogRepository.AddLog(log);

            return true;
        }

        #endregion

        #endregion
    }
}
