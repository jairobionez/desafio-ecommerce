using DesafioEcommerce.Domain.Interfaces;

namespace DesafioEcommerce.Domain.Commands
{
    /// <summary>
    /// Resultado de um comando
    /// </summary>
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(string message)
        {
            this.Message = message;

        }
        
        /// <summary>
        /// Informa se o comando foi executado com sucesso ou não
        /// </summary>
        public string Message { get; set; }
    }
}