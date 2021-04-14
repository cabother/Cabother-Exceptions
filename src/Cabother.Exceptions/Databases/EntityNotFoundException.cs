using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Databases
{
    /// <summary>
    /// Exceção quando uma entidade não é encontrada
    /// </summary>
    [Serializable]
    public sealed class EntityNotFoundException : BaseException
    {
        private static string BuildMessage(string entity) =>
            $"{entity} not found";

        private string _entity;
        
        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="info">Informações para a serialização</param>
        /// <param name="context">Contexto para o stream</param>
        private EntityNotFoundException(SerializationInfo info, StreamingContext context)
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
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        public EntityNotFoundException(string entity)
            : base(BuildMessage(entity))
        {
            Entity = entity;
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        /// <param name="errorCode">Código do erro</param>
        public EntityNotFoundException(string entity, string errorCode)
            : base(BuildMessage(entity), errorCode)
        {
            Entity = entity;
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public EntityNotFoundException(string entity, string errorCode, string message)
            : base(message, errorCode)
        {
            Entity = entity;
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro interno ocorrido</param>
        public EntityNotFoundException(string entity, string errorCode, Exception innerException)
            : base(BuildMessage(entity), errorCode, innerException)
        {
            Entity = entity;
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="innerException">Erro interno ocorrido</param>
        public EntityNotFoundException(string entity, string errorCode, string message, Exception innerException)
            : base(message, errorCode, innerException)
        {
            Entity = entity;
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        /// <param name="innerException">Erro interno ocorrido</param>
        public EntityNotFoundException(string entity, Exception innerException)
            : base(BuildMessage(entity), innerException)
        {
            Entity = entity;
        }
    }
}