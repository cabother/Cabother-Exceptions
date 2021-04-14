using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção quando uma entidade não é encontrada
    /// </summary>
    [Serializable]
    public sealed class BadRequestException : BaseException
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="BadRequestException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private BadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="BadRequestException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public BadRequestException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="BadRequestException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public BadRequestException(string message, string errorCode)
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="BadRequestException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro interno</param>
        public BadRequestException(string message, string errorCode, Exception innerException)
            : base(message, errorCode, innerException)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="BadRequestException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="innerException">Erro interno</param>
        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}