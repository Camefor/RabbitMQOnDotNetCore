using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Exceptionless;
using Exceptionless.Logging;
using LogLevel = Exceptionless.Logging.LogLevel;

namespace DotNetCoreRabbitMQ.Common.Logging {
    public class ExceptionlessLogger : ILogger {
        public ExceptionlessLogger() {
        }

        /// <summary>
        /// Trace
        /// </summary>
        public void Trace(string message, params string[] tags) {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Trace).AddTags(tags).Submit();
        }

        /// <summary>
        /// Debug
        /// </summary>
        public void Debug(string message, params string[] tags) {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Debug).AddTags(tags).Submit();
        }

        /// <summary>
        /// Info
        /// </summary>
        public void Info(string message, params string[] tags) {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Info).AddTags(tags).Submit();
        }

        /// <summary>
        /// Warn
        /// </summary>
        public void Warn(string message, params string[] tags) {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Warn).AddTags(tags).Submit();
        }

        /// <summary>
        /// Error
        /// </summary>
        public void Error(string message, params string[] tags) {
            ExceptionlessClient.Default.CreateLog(message, LogLevel.Error).AddTags(tags).Submit();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel) {
            throw new NotImplementedException();
        }

        public IDisposable BeginScope<TState>(TState state) {
            throw new NotImplementedException();
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            throw new NotImplementedException();
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel) {
            throw new NotImplementedException();
        }
    }
}