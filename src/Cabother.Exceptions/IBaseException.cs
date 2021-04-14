namespace Cabother.Exceptions
{
    public interface IBaseException
    {
        /// <summary>
        /// Código de identificação do erro
        /// </summary>
        string ErrorCode { get; }
    }
}