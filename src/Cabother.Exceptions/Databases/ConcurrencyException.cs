using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Databases
{
    /// <summary>
    /// Exceção quando a entidade foi alterada por outro processo entre a leitura e a gravação
    /// </summary>
    [Serializable]
    public sealed class ConcurrencyException : BaseException
    {
        private static string BuildMessage(string entity) =>
            $"{entity} was modified by another process";

        private string _entity;

        /// <summary>
        /// Cria uma nova instância de <see cref="ConcurrencyException"/>
        /// </summary>
        /// <param name="info">Informações para a serialização</param>
        /// <param name="context">Contexto para o stream</param>
        private ConcurrencyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Entidade que sofreu conflito de concorrência
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
        /// Cria uma nova instância de <see cref="ConcurrencyException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade com conflito</param>
        public ConcurrencyException(string entity)
            : base(BuildMessage(entity))
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConcurrencyException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade com conflito</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public ConcurrencyException(string entity, string errorCode)
            : base(BuildMessage(entity), errorCode)
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConcurrencyException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade com conflito</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="innerException">Erro interno ocorrido</param>
        public ConcurrencyException(string entity, string errorCode, Exception innerException)
            : base(BuildMessage(entity), errorCode, innerException)
        {
            Entity = entity;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ConcurrencyException"/>
        /// </summary>
        /// <param name="entity">Nome da entidade com conflito</param>
        /// <param name="innerException">Erro interno ocorrido</param>
        public ConcurrencyException(string entity, Exception innerException)
            : base(BuildMessage(entity), innerException)
        {
            Entity = entity;
        }
    }
}
