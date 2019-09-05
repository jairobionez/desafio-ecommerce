using DesafioEcommerce.Domain.Interfaces;

namespace DesafioEcommerce.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(string message)
        {
            this.Message = message;

        }
        public string Message { get; set; }
    }
}