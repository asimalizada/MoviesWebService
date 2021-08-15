using log4net;
using log4net.Repository;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;

        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager
                .CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

            _log = LogManager.GetLogger(loggerRepository.Name, name);
        }

        public bool IsInfoEnabled => this._log.IsInfoEnabled;
        public bool IsDebugEnabled => this._log.IsDebugEnabled;
        public bool IsWarnEnabled => this._log.IsWarnEnabled;
        public bool IsFatalEnabled => this._log.IsFatalEnabled;
        public bool IsErrorEnabled => this._log.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if (this.IsInfoEnabled) this._log.Info(logMessage);
        }

        public void Debug(object logMessage)
        {
            if (this.IsDebugEnabled) this._log.Debug(logMessage);
        }

        public void Warn(object logMessage)
        {
            if (this.IsWarnEnabled) this._log.Warn(logMessage);
        }

        public void Fatal(object logMessage)
        {
            if (this.IsFatalEnabled) this._log.Fatal(logMessage);
        }

        public void Error(object logMessage)
        {
            if (this.IsErrorEnabled) this._log.Error(logMessage);
        }

    }
}
