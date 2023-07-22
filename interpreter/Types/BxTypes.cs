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
            internal List<Command> Declaration { get; private set; }

            private BxTypes bxTypes;
            private int nextIndex;

            public BxTypesBuilder(BxTypes types, BxType parent, int requiredSize)
            {
                this.bxTypes = types;
                this.Declaration = new List<Command>();
                this.nextIndex = 0;

                var sizeCommandArgs = new List<byte>();
                sizeCommandArgs.Add((byte)InterpreterFlag.SIZE);
                sizeCommandArgs.AddRange(BitConverter.GetBytes(requiredSize));

                var sizeCommand = new Command(CommandType.NO, sizeCommandArgs.ToArray());
                Declaration.Add(sizeCommand);
                this.nextIndex += Interpreter.Util.Util.CommandToBytes(sizeCommand).Length;

                var parentDeclaration = new List<byte>();

                if (parent != null)
                {
                    parentDeclaration.Add((byte)InterpreterFlag.PARENT);
                    parentDeclaration.AddRange(BitConverter.GetBytes(parentIndex));
                }
                else
                    parentDeclaration.Add((byte)InterpreterFlag.NO_PARENT);

                var declaration = new Command(CommandType.NO, parentDeclaration.ToArray());
                Declaration.Add(declaration);
                this.nextIndex += Interpreter.Util.Util.CommandToBytes(declaration).Length;
            }

            public int AddOperation(string name, IEnumerable<Command> commands)
            {
                var operationIndex = nextIndex;
                var commandsAsBytes = Interpreter.Util.Util.CommandsToBytes(commands);

                this.Declaration.AddRange(commands);
                this.nextIndex += commandsAsBytes.Length;

                return operationIndex;
            }

            public BxType Build()
            {
                return new BxType(this.index, Declaration);
            }
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
            AddInteger();
        }

        public BxTypesBuilder Add(string name, BxType parent)
        {
            
        }

        private void AddNone()
        {

        }

        private void AddInteger()
        {

        }
    }
}