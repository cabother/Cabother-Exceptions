using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção de conflitos nas entidades
    /// </summary>
    [Serializable]
    public sealed class ConflictException : Exception
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private ConflictException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public ConflictException(string message) : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConflictException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="inner">Inner Exception</param>
        public ConflictException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}