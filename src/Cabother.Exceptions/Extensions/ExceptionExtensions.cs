using System;
using Cabother.Exceptions.Databases;
using Cabother.Exceptions.Requests;
using Microsoft.Extensions.Logging;

namespace Cabother.Exceptions.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Adiciona código de erro na exceção
        /// </summary>
        /// <param name="exception">Exceção ocorrida</param>
        /// <param name="errorCode">Código do erro que será inserido</param>
        public static void AddErrorCode(this Exception exception, string errorCode)
        {
            if (exception.Data["ErrorCode"] == null)
                exception.Data.Add("ErrorCode", errorCode);
        }
        /// <summary>
        /// Adiciona código de erro na exceção a partir do evento ocorrido
        /// </summary>
        /// <param name="exception">Exceção ocorrida</param>
        /// <param name="eventId">Evento que será utilizado como base para o código de erro</param>
        public static void AddErrorCode(this Exception exception, EventId eventId)
        {
            AddErrorCode(exception, eventId.ToString());
        }

        /// <summary>
        /// Retorna o código de erro a partir da exceção ocorrida
        /// </summary>
        /// <param name="exception">Exceção ocorrida</param>
        public static string GetErrorCode(this Exception exception)
        {
            return exception.Data["ErrorCode"]?.ToString();
        }

        #region InernalServerException

        /// <summary>
        /// Converte para InternalServerErrorException.
        /// </summary>
        /// <param name="exception">Exceção lançada.</param>
        /// <param name="code">Código do erro à ser mostrado na mensagem.</param>
        /// <param name="message">Mensagem complementar à ser mostrada no log e na exceção.</param>
        /// <returns>Exceção do tipo <see cref="InternalServerErrorException"/> com a mensagem gerada.</returns>
        public static InternalServerErrorException ToInternalServerErrorException(
            this Exception exception,
            string code,
            string message) =>
            new InternalServerErrorException(message, code, exception);


        /// <summary>
        /// Converte para InternalServerErrorException.
        /// </summary>
        /// <param name="exception">Exceção lançada.</param>
        /// <param name="message">Mensagem complementar à ser mostrada no log e na exceção.</param>
        /// <returns>Exceção do tipo <see cref="InternalServerErrorException"/> com a mensagem gerada.</returns>
        public static InternalServerErrorException ToInternalServerErrorException(
            this Exception exception,
            string message) =>
            new InternalServerErrorException(message, exception);

        #endregion

        #region EntityNotFoundException

        /// <summary>
        /// Converte a exceção para o tipo <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="entity">Nome da entidade não encontrada</param>
        /// <returns>Retorna exceção do tipo <see cref="EntityNotFoundException"/></returns>
        public static EntityNotFoundException ToEntityNotFoundException(
            this Exception exception,
            string entity) =>
            new EntityNotFoundException(entity, exception);

        /// <summary>
        /// Converte a exceção para o tipo <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="entity">Nome da entidade não encontrada</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <returns>Retorna exceção do tipo <see cref="EntityNotFoundException"/></returns>
        public static EntityNotFoundException ToEntityNotFoundException(
            this Exception exception,
            string entity,
            string errorCode) =>
            new EntityNotFoundException(entity, errorCode, exception);

        /// <summary>
        /// Converte a exceção para o tipo <see cref="EntityNotFoundException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="entity">Nome da entidade não encontrada</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <param name="message">Mensagem descritiva da nova exceção</param>
        /// <returns>Retorna exceção do tipo <see cref="EntityNotFoundException"/></returns>
        public static EntityNotFoundException ToEntityNotFoundException(
            this Exception exception,
            string entity,
            string errorCode,
            string message) =>
            new EntityNotFoundException(entity, errorCode, message, exception);

        #endregion

        #region

        /// <summary>
        /// Converte a exceção para o tipo <see cref="ConflictException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="message">Mensagem descritiva da nova exceção</param>
        /// <returns>Retorna exceção do tipo <see cref="ConflictException"/></returns>
        public static ConflictException ToConflictException(
            this Exception exception,
            string message) =>
            new ConflictException(message, exception);

        /// <summary>
        /// Converte a exceção para o tipo <see cref="ConflictException"/>
        /// </summary>
        /// <param name="exception">Exceção original</param>
        /// <param name="message">Mensagem descritiva da nova exceção</param>
        /// <param name="errorCode">Código de identificação do erro</param>
        /// <returns>Retorna exceção do tipo <see cref="ConflictException"/></returns>
        public static ConflictException ToConflictException(
            this Exception exception,
            string message,
            string errorCode) =>
            new ConflictException(message, errorCode, exception);

        #endregion
    }
}