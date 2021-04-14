using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Configurations
{
    /// <summary>
    /// Exceção de configuração não encontrada
    /// </summary>
    [Serializable]
    public sealed class ConfigurationNotFoundException : BaseException
    {
        private static string BuildMessage(string configurationKey) =>
            $"Configuration key '{configurationKey}' not found.";

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
        /// Cria uma nova instância de <see cref="ConfigurationNotFoundException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private ConfigurationNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        
        /// <summary>
        /// Cria uma nova instância de <see cref="ConfigurationNotFoundException"/>
        /// </summary>
        /// <param name="configurationKey">Chave de configuração</param>
        public ConfigurationNotFoundException(string configurationKey) 
            : base(BuildMessage(configurationKey)) 
        {
            ConfigurationKey = configurationKey;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConfigurationNotFoundException"/>
        /// </summary>
        /// <param name="configurationKey">Chave de configuração</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public ConfigurationNotFoundException(string configurationKey, string errorCode) 
            : base(BuildMessage(configurationKey), errorCode) 
        {
            ConfigurationKey = configurationKey;
        }
    }
}