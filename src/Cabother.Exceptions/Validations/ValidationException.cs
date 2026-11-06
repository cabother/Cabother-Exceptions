using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.Validations
{
    /// <summary>
    /// Exceção quando os dados de entrada são inválidos, com a lista de erros por campo
    /// </summary>
    [Serializable]
    public sealed class ValidationException : BaseException
    {
        private const string DefaultMessage = "One or more validation errors occurred.";

        private static IReadOnlyDictionary<string, string[]> Copy(IDictionary<string, string[]> errors) =>
            errors == null
                ? new Dictionary<string, string[]>()
                : errors.ToDictionary(e => e.Key, e => e.Value ?? Array.Empty<string>());

        /// <summary>
        /// Erros de validação agrupados pelo nome do campo
        /// </summary>
        public IReadOnlyDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();

        /// <summary>
        /// Cria uma nova instância de <see cref="ValidationException"/>
        /// </summary>
        /// <param name="info">Informações do objeto sobre a exceção que está sendo lançada</param>
        /// <param name="context">Informação de local onde a exception será lançada, seu contexto de origem/destino</param>
        private ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ValidationException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        public ValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ValidationException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public ValidationException(string message, string errorCode)
            : base(message, errorCode)
        {
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ValidationException"/> com um único erro de campo
        /// </summary>
        /// <param name="field">Nome do campo inválido</param>
        /// <param name="error">Descrição do erro no campo</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public ValidationException(string field, string error, string errorCode)
            : base(error, errorCode)
        {
            Errors = new Dictionary<string, string[]> { [field] = new[] { error } };
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ValidationException"/>
        /// </summary>
        /// <param name="errors">Erros de validação agrupados pelo nome do campo</param>
        public ValidationException(IDictionary<string, string[]> errors)
            : base(DefaultMessage)
        {
            Errors = Copy(errors);
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ValidationException"/>
        /// </summary>
        /// <param name="errors">Erros de validação agrupados pelo nome do campo</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public ValidationException(IDictionary<string, string[]> errors, string errorCode)
            : base(DefaultMessage, errorCode)
        {
            Errors = Copy(errors);
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ValidationException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="errors">Erros de validação agrupados pelo nome do campo</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        public ValidationException(string message, IDictionary<string, string[]> errors, string errorCode)
            : base(message, errorCode)
        {
            Errors = Copy(errors);
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="ValidationException"/>
        /// </summary>
        /// <param name="message">Mensagem descritiva da exceção</param>
        /// <param name="innerException">Erro interno</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
