using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção para quando o valor de uma resposta não seja esperado
    /// </summary>
    [Serializable]
    public sealed class UnexpectedResponseException : Exception
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="UnexpectedResponseException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private UnexpectedResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="UnexpectedResponseException"/>
        /// </summary>
        /// <param name="message">Mensagem da exceção</param>
        public UnexpectedResponseException(string message)
            : base(message)
        {
        }
    }
}