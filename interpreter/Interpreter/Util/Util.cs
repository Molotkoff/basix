using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Interpreter.Commands;

namespace Basix.Interpreter.Util
{
    public static class Util
    {
        public static byte[] CommandToBytes(Command command)
        {
            if (command.Type == CommandType.NO)
                return command.args;

            var bytes = new byte[command.args.Length + 1];
            bytes[0] = (byte)command.Type;

            for (int i = 0; i < command.args.Length; i++)
                bytes[i + 1] = command.args[i];

            return bytes;
        }

        public static byte[] CommandsToBytes(IEnumerable<Command> commands)
        {
            var bytes = new List<byte>();

            foreach(var command in commands)
            {
                if (command.Type != CommandType.NO)
                    bytes.Add((byte) command.Type);

                bytes.AddRange(command.args);
            }

            return bytes.ToArray();
        }

        //just faster version of array.Length
        public static int CommandsLength(IEnumerable<Command> commands)
        {
            var size = 0;

            foreach(var command in commands)
            {
                if (command.Type != CommandType.NO)
                    size++;
                size += command.args.Length;
            }

            return size;
        }
    }
}