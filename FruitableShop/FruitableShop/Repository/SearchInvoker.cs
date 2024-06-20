using FruitableShop.Models;

namespace FruitableShop.Repository
{
    public class SearchInvoker
    {
        private readonly Dictionary<string, ISearchCommand> _commands;

        public SearchInvoker()
        {
            _commands = new Dictionary<string, ISearchCommand>();
        }

        public void RegisterCommand(string commandName, ISearchCommand command)
        {
            _commands[commandName] = command;
        }

        public List<Product> ExecuteCommand(string commandName, string keyword)
        {
            if (_commands.ContainsKey(commandName))
            {
                return _commands[commandName].Execute(keyword);
            }

            return new List<Product>();
        }
    }
}
