using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Util.Segment;
using Basix.Interpreter.Commands;
using Basix.Interpreter.Util;

namespace Basix.Types
{
    public class BxTypeMember : ISegment
    {
        public IEnumerable<Command> Declaration { get; private set; }

        public const string PARENT = "PARENT";
        public const string SIZE   = "SIZE";

        public BxTypeMember(IEnumerable<Command> declaration)
        {
            this.Declaration = declaration;
        }

        public int Length()
        {
            return Interpreter.Util.Util.CommandsLength(Declaration);
        }
    }
}