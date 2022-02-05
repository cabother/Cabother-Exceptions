using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção requisição não autorizada
    /// </summary>
    [Serializable]
    public sealed class UnauthorizedException : BaseException
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private UnauthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public UnauthorizedException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public UnauthorizedException(string message, string errorCode) 
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro interno</param>
        public UnauthorizedException(string message, string errorCode, Exception innerException) 
            : base(message, errorCode, innerException)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="innerException">Erro interno</param>
        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}