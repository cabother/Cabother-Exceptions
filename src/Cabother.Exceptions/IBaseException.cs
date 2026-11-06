namespace Cabother.Exceptions
{
    /// <summary>
    /// Contrato base para as exceções da biblioteca
    /// </summary>
    public interface IBaseException
    {
        /// <summary>
        /// Código de identificação do erro
        /// </summary>
        string ErrorCode { get; }
    }
}