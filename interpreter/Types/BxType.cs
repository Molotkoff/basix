using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Interpreter.Commands;
using Basix.Util.Segment;
using Basix.Interpreter.Util;

namespace Basix.Types
{
    public class BxType : ISegment
    {
        public BxType Parent { get; private set; }
        public IEnumerable<Command> Declaration { get; private set; }

        public BxType(BxType parent, IEnumerable<Command> declaration)
        {
            this.Parent = parent;
            this.Declaration = declaration;
        }

        public int Length()
        {
            return Interpreter.Util.Util.CommandsLength(Declaration);
        }
    }
}