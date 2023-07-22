using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Interpreter.Commands;
using Basix.Types;

namespace Basix.Builder.Expression
{
    public class ExpressionCommands
    {
        public IEnumerable<Command> Data { get; private set; }
        public IEnumerable<Command> Process { get; private set; }

        public ExpressionCommands(IEnumerable<Command> data, IEnumerable<Command> process)
        {
            this.Data = data;
            this.Process = process;
        }
    }
}