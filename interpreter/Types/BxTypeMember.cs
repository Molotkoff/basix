using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Types
{
    public struct BxTypeMember
    {
        public int Index { get; private set; }
        public int Length { get; private set; }

        public BxTypeMember(int index, int length)
        {
            this.Index = index;
            this.Length = length;
        }
    }
}