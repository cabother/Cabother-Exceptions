using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção quando o limite de requisições é excedido (HTTP 429)
    /// </summary>
    [Serializable]
    public sealed class TooManyRequestsException : BaseException
    {
        /// <summary>
        /// Tempo sugerido para aguardar antes de uma nova tentativa (cabeçalho Retry-After)
        /// </summary>
        public TimeSpan? RetryAfter { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="TooManyRequestsException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private TooManyRequestsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="TooManyRequestsException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public TooManyRequestsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="TooManyRequestsException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="retryAfter">Tempo sugerido para aguardar antes de uma nova tentativa</param>
        public TooManyRequestsException(string message, TimeSpan retryAfter)
            : base(message)
        {
            RetryAfter = retryAfter;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="TooManyRequestsException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public TooManyRequestsException(string message, string errorCode)
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="TooManyRequestsException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="retryAfter">Tempo sugerido para aguardar antes de uma nova tentativa</param>
        public TooManyRequestsException(string message, string errorCode, TimeSpan retryAfter)
            : base(message, errorCode)
        {
            RetryAfter = retryAfter;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="TooManyRequestsException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro interno</param>
        public TooManyRequestsException(string message, string errorCode, Exception innerException)
            : base(message, errorCode, innerException)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="TooManyRequestsException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="innerException">Erro interno</param>
        public TooManyRequestsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
