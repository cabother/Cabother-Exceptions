using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Configurations
{
    /// <summary>
    /// Exceção quando uma configuração existe mas possui valor inválido
    /// </summary>
    [Serializable]
    public sealed class InvalidConfigurationException : BaseException
    {
        private static string BuildMessage(string configurationKey) =>
            $"Configuration key '{configurationKey}' has an invalid value.";

        private static string BuildMessage(string configurationKey, string reason) =>
            $"Configuration key '{configurationKey}' has an invalid value: {reason}";

        private string _configurationKey;

        /// <summary>
        /// Chave de configuração
        /// </summary>
        public string ConfigurationKey
        {
            get => _configurationKey;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ConfigurationKey cannot be null.");

                _configurationKey = value;
            }
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="InvalidConfigurationException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private InvalidConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="InvalidConfigurationException"/>
        /// </summary>
        /// <param name="configurationKey">Chave de configuração</param>
        public InvalidConfigurationException(string configurationKey)
            : base(BuildMessage(configurationKey))
        {
            ConfigurationKey = configurationKey;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="InvalidConfigurationException"/>
        /// </summary>
        /// <param name="configurationKey">Chave de configuração</param>
        /// <param name="reason">Motivo pelo qual o valor é inválido</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public InvalidConfigurationException(string configurationKey, string reason, string errorCode)
            : base(BuildMessage(configurationKey, reason), errorCode)
        {
            ConfigurationKey = configurationKey;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="InvalidConfigurationException"/>
        /// </summary>
        /// <param name="configurationKey">Chave de configuração</param>
        /// <param name="innerException">Erro interno ocorrido (ex.: falha de conversão)</param>
        public InvalidConfigurationException(string configurationKey, Exception innerException)
            : base(BuildMessage(configurationKey), innerException)
        {
            ConfigurationKey = configurationKey;
        }
    }
}
