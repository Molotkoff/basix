using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Interpreter.Memory
{
    public class BasixMemory
    {
        private byte[] table;

        public BasixMemory(int size)
        {
            this.table = new byte[size];
        }

        public Span<byte> Access(int index, int size) => table.AsSpan().Slice(index, size);
    }
}