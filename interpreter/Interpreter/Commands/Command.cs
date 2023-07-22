using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Interpreter.Commands
{
    public struct Command
    {
        public readonly CommandType Type;
        public readonly byte[] args;

        public Command(CommandType type)
        {
            this.Type = type;
            this.args = new byte[0];
        }

        public Command(CommandType type, byte[] args)
        {
            this.Type = type;
            this.args = args;
        }
    }
}