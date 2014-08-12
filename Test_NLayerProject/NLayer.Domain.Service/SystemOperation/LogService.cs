﻿using NLayer.Domain.Entity;
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

        public ILogRepository LogRepository { private get; set; }
        public ILogApparenceRepository LogApparenceRepository { private get; set; }

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

        public IEnumerable<string> GetAllLogsName()
        {
            return LogRepository.GetAllLogs().Select(l => l.Name).ToList();
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

        public bool IsImportLogFilePathValid(string inputFilePath)
        {
            // TODO [CMP] usar classe de infraestrutura
            return File.Exists(inputFilePath);
        }

        public bool Import(string inputFilePath, string logName)
        {
            if (!IsImportLogFilePathValid(inputFilePath))
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

        public DrawLogResponse GetDrawLog(string name)
        {
            Log log = LogRepository.GetLog(name);
            LogApparence logAp = LogApparenceRepository.GetLogApparence(name);

            return new DrawLogResponse(log.Name, log.Values, logAp.Color, logAp.Thickness);
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
