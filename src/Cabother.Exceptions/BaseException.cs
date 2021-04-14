using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions
{
    /// <summary>
    /// Exceção com estrutura base para novas exceções 
    /// </summary>
    [Serializable]
    public abstract class BaseException : Exception, IBaseException
    {
        private static string ValidateMessage(string message) =>
            string.IsNullOrWhiteSpace(message) ? throw new ArgumentException("Message cannot be null.") : message;

        private static string BuildMessage(string message, string errorCode) =>
            $"{errorCode} - {message}";

        private static string BuildMessage(string message, string errorCode, Exception innerException) =>
            $"{errorCode} - {message}: {innerException.InnerException?.Message ?? innerException.Message}";

        private static string BuildMessage(string message, Exception innerException) =>
            $"{message}: {innerException.InnerException?.Message ?? innerException.Message}";

        private string _errorCode;

        /// <summary>
        /// Cria uma nova exceção
        /// </summary>
        protected BaseException()
        {
            _errorCode = null;
        }

        /// <summary>
        /// Cria uma nova exceção
        /// </summary>
        /// <param name="info">Informações para a serialização</param>
        /// <param name="context">Contexto para o stream</param>
        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _errorCode = null;
        }

        /// <summary>
        /// Cria uma nova exceção
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        protected BaseException(string message)
            : base(ValidateMessage(message))
        {
            _errorCode = null;
        }

        /// <summary>
        /// Cria uma nova exceção
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        protected BaseException(string message, string errorCode)
            : base(BuildMessage(ValidateMessage(message), errorCode))
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Cria uma nova exceção
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="innerException">Erro original que gerou a exceção</param>
        protected BaseException(string message, Exception innerException)
            : base(BuildMessage(ValidateMessage(message), innerException), innerException)
        {
            _errorCode = null;
        }

        /// <summary>
        /// Cria uma nova exceção
        /// </summary>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro original que gerou a exceção</param>
        protected BaseException(string message, string errorCode, Exception innerException)
            : base(BuildMessage(ValidateMessage(message), errorCode, innerException), innerException)
        {
            ErrorCode = errorCode;
        }

        /// <inheritdoc cref="IBaseException.ErrorCode"/>
        public string ErrorCode
        {
            get => _errorCode;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    // ReSharper disable once S3928
                    throw new ArgumentException("ErrorCode cannot be null.");

                _errorCode = value;
            }
        }
    }
}
