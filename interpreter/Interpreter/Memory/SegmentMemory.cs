using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Interpreter.Memory
{
    public class SegmentMemory : IBasixMemory
    {
        private SegmentMemory parent;

        private int Size { get; set; }

        private BasixMemory table;

        public SegmentMemory(int size)
        {
            this.parent = parent;
        }

        public SegmentMemory(BasixMemory table)
        {
            this.table = table;
        }

        public Span<byte> Access(int index, int size)
        {
            if 
        }

        private int Shift(int index)
        {

        }
    }
}