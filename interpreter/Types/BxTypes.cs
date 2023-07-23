using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Builder.Expression;
using Basix.Interpreter.Commands;
using Basix.Interpreter;
using Basix.Util.Segment;

namespace Basix.Types
{
    public class BxTypes
    {
        public class BxTypesBuilder
        {
            private BxType me;
            private Segment<BxTypeMember> members;

            public BxTypesBuilder(BxTypes types, BxType parent, string name, int requiredSize)
            {
                this.members = new Segment<BxTypeMember>();

                var parentDeclaration = new List<byte>();

                if (parent != null)
                {
                    parentDeclaration.Add((byte)InterpreterFlag.PARENT);
                    parentDeclaration.AddRange(BitConverter.GetBytes(types.typeSegment.IndexOfSegment(parent)));
                }
                else
                    parentDeclaration.Add((byte)InterpreterFlag.NO_PARENT);

                var declaration = new Command(CommandType.NO, parentDeclaration);
                this.members.Add(BxTypeMember.PARENT, new BxTypeMember(new[] { declaration }));

                var sizeCommandArgs = new List<byte>();
                sizeCommandArgs.Add((byte)InterpreterFlag.SIZE);
                sizeCommandArgs.AddRange(BitConverter.GetBytes(requiredSize));

                var sizeCommand = new Command(CommandType.NO, sizeCommandArgs.ToArray());

                this.members.Add(BxTypeMember.SIZE, new BxTypeMember(new[] { sizeCommand }));

                this.me = new BxType(parent, members);
                types.typeSegment.Add(name, me);
            }

            public BxTypesBuilder AddMember(string name, IEnumerable<Command> commands)
            {
                this.members.Add(name, new BxTypeMember(commands));
                return this;
            }

            public BxTypesBuilder AddMember(string name, Command command)
            {
                return AddMember(name, new[] { command });
            }

            public BxType Build() => me;
        }

        public const string NONE = "NONE";
        public const string INTEGER = "INTEGER";
        public const string BYTE = "BYTE";
        public const string SHORT = "SHORT";
        public const string FLOAT = "FLOAT";

        private Segment<BxType> typeSegment;

        public BxTypes()
        {
            this.typeSegment = new Segment<BxType>();

            AddNone();
            Add4BytesInteger();
        }

        public BxTypesBuilder Add(string name, BxType parent, int dataSize)
        {
            return new BxTypesBuilder(this, parent, name, dataSize);
        }

        private void AddNone()
        {
            Add(NONE, null, 0).Build();
        }

        private void Add4BytesInteger()
        {
            Add(INTEGER, null, 4)
           .AddMember(CommandType.ADD_INTEGER.ToString(), new Command(CommandType.ADD_INTEGER))
           .AddMember(CommandType.MIN_INTEGER.ToString(), new Command(CommandType.MIN_INTEGER))
           .AddMember(CommandType.MUL_INTEGER.ToString(), new Command(CommandType.MUL_INTEGER))
           .AddMember(CommandType.DIV_INTEGER.ToString(), new Command(CommandType.DIV_INTEGER))
           .Build();
        }
    }
}