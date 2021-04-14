using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção de Forbidden
    /// </summary>
    [Serializable]
    public class ForbiddenException : BaseException
    {

        /// <summary>
        /// Cria uma nova instância de <see cref="ForbiddenException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private ForbiddenException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ForbiddenException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public ForbiddenException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ForbiddenException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public ForbiddenException(string message, string errorCode) 
            : base(message, errorCode)
        {
        }
        
    }
}