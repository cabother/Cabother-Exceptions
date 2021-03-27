using System;
using System.Runtime.Serialization;

namespace Cabother.Exceptions.WebServices
{
    /// <summary>
    /// Exception customizada para chamadas WebService
    /// </summary>
    [Serializable]
    public class WebServiceException : Exception
    {

        public string Method { get; }

        public int? ErrorCode { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="WebServiceException"/> 
        /// </summary>
        /// <param name="message">Mensagem de Erro Gerado</param>
        public WebServiceException(string message) : base(message)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="WebServiceException"/> 
        /// </summary>
        /// <param name="message">Mensagem de Erro Gerado</param>
        /// <param name="innerException">Exceção gerada</param>
        public WebServiceException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="WebServiceException"/> 
        /// </summary>
        /// <param name="method">Método do WebService Invocado</param>
        /// <param name="errorCode">Código do Erro do WebService Gerado</param>
        /// <param name="message">Mensagem de Erro Gerado</param>
        /// <param name="innerException">Exceção gerada</param>
        public WebServiceException(string method, int errorCode, string message, Exception innerException) : base(message, innerException)
        {
            Method = method;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="WebServiceException"/> 
        /// </summary>
        /// <param name="method">Método do WebService Invocado</param>
        /// <param name="errorCode">Código do Erro do WebService Gerado</param>
        /// <param name="message">Mensagem de Erro Gerado</param>
        public WebServiceException(string method, int errorCode, string message) : base(message)
        {
            Method = method;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="WebServiceException"/> 
        /// </summary>
        /// <param name="method">Método do WebService Invocado</param>
        /// <param name="message">Mensagem de Erro Gerado</param>
        /// <param name="innerException">Exceção gerada</param>
        public WebServiceException(string method, string message, Exception innerException) : base(message, innerException)
        {
            Method = method;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="WebServiceException"/> 
        /// </summary>
        /// <param name="method">Método do WebService Invocado</param>
        /// <param name="message">Mensagem de Erro Gerado</param>
        public WebServiceException(string method, string message) : base(message)
        {
            Method = method;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="WebServiceException"/>
        /// </summary>
        /// <param name="info">Objeto da Classe SerializationInfo</param>
        /// <param name="context">Objeto da Classe StreamingContext</param>
        protected WebServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}