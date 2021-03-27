using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Databases
{
    [Serializable]
    public sealed class RepositoryNotFoundException : Exception
    {
        /// <summary>
        /// Cria uma nova instância de <see cref="RepositoryNotFoundException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private RepositoryNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="RepositoryNotFoundException"/> 
        /// </summary>
        /// <param name="entity">Entidade para qual não foi encontrado repositório</param>
        public RepositoryNotFoundException(string entity)
            : base($"Not found {entity}'s repository")
        {
            Entity = entity;
        }

        /// <summary>
        /// Entidade do repositório
        /// </summary>
        public string Entity { get; }
    }
}