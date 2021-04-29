using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Environments
{
    /// <summary>
    /// Exceção para quando uma variável de ambiente não existir, ser nula ou vazia
    /// </summary>
    [Serializable]
    public sealed class InvalidEnvironmentVariableException : BaseException
    {
        private static string BuildMessage(string environmentVariableName) =>
            $"Environment variable '{environmentVariableName.ToUpper()}' don't parametrized.";

        /// <summary>
        /// Propriedade com o nome da variável de ambiente
        /// </summary>
        public string EnvironmentVariableName { get; private set; }
        /// <summary>
        /// Cria uma nova instância de <see cref="InvalidEnvironmentVariableException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private InvalidEnvironmentVariableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        /// <summary>
        /// Cria uma nova instância de <see cref="InvalidEnvironmentVariableException"/>
        /// </summary>
        /// <param name="environmentVariableName">Nome da variável de ambiente</param>
        public InvalidEnvironmentVariableException(string environmentVariableName)
            : base(BuildMessage(environmentVariableName))
        {
            EnvironmentVariableName = environmentVariableName;
        }
        /// <summary>
        /// Cria uma nova instância de <see cref="InvalidEnvironmentVariableException"/>
        /// </summary>
        /// <param name="environmentVariableName">Nome da variável de ambiente</param>
        /// <param name="errorCode">Código de erro</param>
        public InvalidEnvironmentVariableException(string environmentVariableName, string errorCode)
            : base(BuildMessage(environmentVariableName), errorCode)
        {
            EnvironmentVariableName = environmentVariableName;
        }
    }
}