using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção de Gateway incorreto
    /// </summary>
    [Serializable]
    public sealed class BadGatewayException : Exception
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private BadGatewayException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="BadGatewayException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public BadGatewayException(string message) : base(message)
        {

        }

    }
}