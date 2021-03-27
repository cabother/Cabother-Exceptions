using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Requests
{
    /// <summary>
    /// Exceção quando uma entidade não é encontrada
    /// </summary>
    [Serializable]
    public sealed class BadRequestException : Exception
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
        public BadRequestException(string message) : base(message)
        {

        }
    }
}