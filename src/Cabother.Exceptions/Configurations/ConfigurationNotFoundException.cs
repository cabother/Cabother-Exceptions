using System;
using System.Runtime.Serialization;

namespace LuizaLabs.RoySnyder.Extensions.Configurations
{
    /// <summary>
    /// Exceção de configuração não encontrada
    /// </summary>
    [Serializable]
    public sealed class ConfigurationNotFoundException : Exception
    {
        /// <summary>
        /// Chave de configuração
        /// </summary>
        public string ConfigurationKey { get; }
        
        /// <summary>
        /// Cria uma nova instância de <see cref="ConfigurationNotFoundException"/>
        /// </summary>
        /// <param name="configurationKey">Chave de configuração</param>
        public ConfigurationNotFoundException(string configurationKey) : base($"Configuration key '{configurationKey}' not found") 
        {
            ConfigurationKey = configurationKey;
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
    }
}