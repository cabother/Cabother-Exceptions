using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Configurations
{
    /// <summary>
    /// Exceção para quando uma variável de ambiente não existir, ser nula ou vazia
    /// </summary>
    [Serializable]
    public sealed class EnvironmentVariableInvalidException : Exception
    {
        /// <summary>
        /// Propriedade com o nome da variável de ambiente
        /// </summary>
        public string EnvironmentVariableName { get; private set; }

        /// <summary>
        /// Cria uma nova instância de <see cref="EnvironmentVariableInvalidException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private EnvironmentVariableInvalidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="EnvironmentVariableInvalidException"/>
        /// </summary>
        /// <param name="environmentVariableName">Nome da variável de ambiente</param>
        public EnvironmentVariableInvalidException(string environmentVariableName)
            : base($"Environment variable '{environmentVariableName.ToUpper()}' don't parametrized")
        {
            EnvironmentVariableName = environmentVariableName;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="EnvironmentVariableInvalidException"/>
        /// </summary>
        /// <param name="environmentVariableName">Nome da variável de ambiente</param>
        /// <param name="message">Mensagem da exceção</param>
        public EnvironmentVariableInvalidException(string environmentVariableName, string message)
            : base(message)
        {
            EnvironmentVariableName = environmentVariableName;
        }
    }
}