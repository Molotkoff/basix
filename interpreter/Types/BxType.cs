using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Types
{
    public class BxType
    {
        public int Size { get; private set; }
        public BxType Parent { get; private set; }

        public BxType(int size, BxType parent)
        {
            this.Size = size;
            this.Parent = parent;
        }

        public BxType(int size) : this(size, null) { }
    }
}