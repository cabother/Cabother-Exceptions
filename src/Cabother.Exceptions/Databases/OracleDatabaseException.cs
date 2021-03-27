using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Databases
{
    /// <summary>
    /// Exceção para quando ocorrer erro no Oracle
    /// </summary>
    [Serializable]
    public sealed class OracleDatabaseException : Exception
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="OracleDatabaseException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private OracleDatabaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="OracleDatabaseException"/>
        /// </summary>
        /// <param name="message">Mensagem da exceção</param>
        public OracleDatabaseException(string message)
            : base(message)
        { }

        /// <summary>
        /// Cria uma nova instância de <see cref="OracleDatabaseException"/>
        /// </summary>
        /// <param name="message">Mensagem da exceção</param>
        /// <param name="inner">Inner Exception</param>
        public OracleDatabaseException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}