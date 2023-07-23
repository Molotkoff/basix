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
        public IEnumerable<Command> Declaration => Members.All(member => member.Declaration);

        public Segment<BxTypeMember> Members { get; private set; }

        public BxType(BxType parent, Segment<BxTypeMember> members)
        {
            this.Parent = parent;
            this.Members = members;
        }

        public int Length()
        {
            return Interpreter.Util.Util.CommandsLength(Declaration);
        }
    }
}