using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção quando o serviço está temporariamente indisponível (HTTP 503)
    /// </summary>
    [Serializable]
    public sealed class ServiceUnavailableException : BaseException
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="ServiceUnavailableException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private ServiceUnavailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ServiceUnavailableException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public ServiceUnavailableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ServiceUnavailableException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public ServiceUnavailableException(string message, string errorCode)
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ServiceUnavailableException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro interno</param>
        public ServiceUnavailableException(string message, string errorCode, Exception innerException)
            : base(message, errorCode, innerException)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ServiceUnavailableException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="innerException">Erro interno</param>
        public ServiceUnavailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
