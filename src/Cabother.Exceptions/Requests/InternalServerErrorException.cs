using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção interna na execução de algum processo
    /// </summary>
    [Serializable]
    public sealed class InternalServerErrorException : Exception
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="InternalServerErrorException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private InternalServerErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="InternalServerErrorException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public InternalServerErrorException(string message) : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="InternalServerErrorException"/>
        /// </summary>
        /// <param name="message">Mensagem da exceção</param>
        /// <param name="inner">Inner Exception</param>
        public InternalServerErrorException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}