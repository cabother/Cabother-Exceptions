using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Databases
{
    /// <summary>
    /// Exceção para quando ocorrer erro no Oracle
    /// </summary>
    [Serializable]
    public sealed class MySqlDatabaseException : Exception
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="MySqlDatabaseException"/>
        /// </summary>dotnet add package Microsoft.Extensions.Logging
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private MySqlDatabaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="MySqlDatabaseException"/>
        /// </summary>
        /// <param name="message">Mensagem da exceção</param>
        public MySqlDatabaseException(string message)
            : base(message)
        { }

        /// <summary>
        /// Cria uma nova instância de <see cref="MySqlDatabaseException"/>
        /// </summary>
        /// <param name="message">Mensagem da exceção</param>
        /// <param name="inner">Inner Exception</param>
        public MySqlDatabaseException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}