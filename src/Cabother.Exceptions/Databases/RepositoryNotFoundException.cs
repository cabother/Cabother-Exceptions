using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Databases
{
    [Serializable]
    public sealed class RepositoryNotFoundException : BaseException
    {
        private static string BuildMessage(string entity) =>
            $"{entity}'s repository not found";

        private string _entity;
        
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
        /// Entidade que não foi encontrada
        /// </summary>
        public string Entity
        {
            get => _entity;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Entity cannot be null.");

                _entity = value;
            }
        }
        
        /// <summary>
        /// Cria uma nova instância de <see cref="RepositoryNotFoundException"/> 
        /// </summary>
        /// <param name="entity">Entidade para qual não foi encontrado repositório</param>
        public RepositoryNotFoundException(string entity)
            : base(BuildMessage(entity))
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="RepositoryNotFoundException"/> 
        /// </summary>
        /// <param name="entity">Entidade para qual não foi encontrado repositório</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public RepositoryNotFoundException(string entity, string errorCode)
            : base(BuildMessage(entity), errorCode)
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="RepositoryNotFoundException"/> 
        /// </summary>
        /// <param name="entity">Entidade para qual não foi encontrado repositório</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro interno</param>
        public RepositoryNotFoundException(string entity, string errorCode, Exception innerException)
            : base(BuildMessage(entity), errorCode, innerException)
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="RepositoryNotFoundException"/> 
        /// </summary>
        /// <param name="entity">Entidade para qual não foi encontrado repositório</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="message">Mensagem com a descrição do erro</param>
        /// <param name="innerException">Erro interno</param>
        public RepositoryNotFoundException(string entity, string errorCode, string message, Exception innerException)
            : base(message, errorCode, innerException)
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="RepositoryNotFoundException"/> 
        /// </summary>
        /// <param name="entity">Entidade para qual não foi encontrado repositório</param>
        /// <param name="innerException">Erro interno</param>
        public RepositoryNotFoundException(string entity, Exception innerException)
            : base(BuildMessage(entity), innerException)
        {
            Entity = entity;
        }
    }
}