using System;
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

        /// <summary>
        /// Monta InternalServerErrorException e imprimir um log de erro de acordo com os parâmetros.
        /// </summary>
        /// <param name="exception">Exceção lançada.</param>
        /// <param name="logger">Objeto para impressão da mensagem de log.</param>
        /// <param name="code">Código do erro à ser mostrado na mensagem.</param>
        /// <param name="message">Mensagem complementar à ser mostrada no log e na exceção.</param>
        /// <param name="args">Uma lista de objetos que contém um ou mais objetos para formatar com a mensagem.</param>
        /// <returns>Exceção do tipo <see cref="InternalServerErrorException"/> com a mensagem gerada.</returns>
        public static InternalServerErrorException ToInternalServerException(
            this Exception exception,
            ILogger logger,
            int code,
            string message,
            params object[] args)
        {
            var errorMessage = string.Format($"#{code} - {message}: {exception.Message}", args);

            var newEx = new InternalServerErrorException(errorMessage, exception);
            newEx.AddErrorCode(code.ToString());
            logger.LogError(code, exception, errorMessage);

            return newEx;
        }
    }
}