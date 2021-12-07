using System.Text;


namespace FileManager.Command
{
    internal struct Request
    {
        private UserCommand _command;

        private string[] _context;


        public Request((UserCommand, string[]) request) : this(request.Item1, request.Item2)
        {
        }

        public Request(UserCommand command, string[] context)
        {
            _command = command;
            _context = context;
        }


        public UserCommand Command => _command;

        public string[] Context => _context;

        public string Info()
        {
            StringBuilder result = new($"Command name: {_command}\n");

            if (_context != null)
            {
                for(int i=0; i < _context.Length; i++)
                {
                    result.Append($"Context {i + 1}: {_context[i]}\n");
                }
            }

            return result.ToString();
        }
    }
}
