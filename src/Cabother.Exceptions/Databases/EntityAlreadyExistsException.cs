using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Databases
{
    /// <summary>
    /// Exceção quando se tenta criar uma entidade que já existe (ex.: chave duplicada)
    /// </summary>
    [Serializable]
    public sealed class EntityAlreadyExistsException : BaseException
    {
        private static string BuildMessage(string entity) =>
            $"{entity} already exists";

        private string _entity;

        /// <summary>
        /// Cria uma nova instância de <see cref="EntityAlreadyExistsException"/>
        /// </summary>
        /// <param name="info">Informações para a serialização</param>
        /// <param name="context">Contexto para o stream</param>
        private EntityAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Entidade que já existe
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
        /// Cria uma nova instância de <see cref="EntityAlreadyExistsException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que já existe</param>
        public EntityAlreadyExistsException(string entity)
            : base(BuildMessage(entity))
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="EntityAlreadyExistsException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que já existe</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public EntityAlreadyExistsException(string entity, string errorCode)
            : base(BuildMessage(entity), errorCode)
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="EntityAlreadyExistsException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que já existe</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        public EntityAlreadyExistsException(string entity, string errorCode, string message)
            : base(message, errorCode)
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="EntityAlreadyExistsException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que já existe</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro interno ocorrido</param>
        public EntityAlreadyExistsException(string entity, string errorCode, Exception innerException)
            : base(BuildMessage(entity), errorCode, innerException)
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="EntityAlreadyExistsException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que já existe</param>
        /// <param name="innerException">Erro interno ocorrido</param>
        public EntityAlreadyExistsException(string entity, Exception innerException)
            : base(BuildMessage(entity), innerException)
        {
            Entity = entity;
        }
    }
}
