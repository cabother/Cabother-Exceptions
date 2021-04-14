using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção de Timeout do Gateway
    /// </summary>
    [Serializable]
    public class GatewayTimeoutException : BaseException
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private GatewayTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public GatewayTimeoutException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="GatewayTimeoutException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public GatewayTimeoutException(string message, string errorCode) 
            : base(message, errorCode)
        {
        }

    }
}