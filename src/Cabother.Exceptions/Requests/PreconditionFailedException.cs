using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção de falha na pré-condição nas entidades
    /// </summary>
    [Serializable]
    public class PreconditionFailedException : BaseException
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="PreconditionFailedException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private PreconditionFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="PreconditionFailedException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public PreconditionFailedException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="PreconditionFailedException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public PreconditionFailedException(string message, string errorCode) 
            : base(message, errorCode)
        {
        }
    }
}