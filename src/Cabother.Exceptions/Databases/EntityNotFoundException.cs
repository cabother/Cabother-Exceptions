using System;
using System.Runtime.Serialization;
using Cabother.Exceptions.Extensions;

namespace Cabother.Exceptions.Databases
{
    /// <summary>
    /// Exceção quando uma entidade não é encontrada
    /// </summary>
    [Serializable]
    public sealed class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Entidade que não foi encontrada
        /// </summary>
        public string Entity { get; }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        public EntityNotFoundException(string entity)
            : base($"{entity} not found")
        {
            Entity = entity;
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        public EntityNotFoundException(string entity, string message)
            : base(message)
        {
            Entity = entity;
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        /// <param name="inner">Inner Exception</param>
        public EntityNotFoundException(string entity, string message, Exception inner)
            : base(message, inner)
        {
            Entity = entity;
        }

        /// <summary>
        /// Retorna uma nova instância de <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="errorCode">Código que identifica o erro ocorrido</param>
        /// <param name="entity">Nome da entidade que não foi encontrada</param>
        /// <param name="message">Mensagem descritiva do erro</param>
        public EntityNotFoundException(int errorCode, string entity, string message)
            : base($"#{errorCode} - {message}")
        {
            this.AddErrorCode(errorCode.ToString());

            Entity = entity;
        }
    }
}