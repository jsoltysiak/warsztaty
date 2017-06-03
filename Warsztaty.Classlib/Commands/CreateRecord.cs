namespace Warsztaty.Messages.Commands
{
    public class CreateRecord : ICommand
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}