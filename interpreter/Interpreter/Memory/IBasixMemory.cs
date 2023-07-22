using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Interpreter.Memory
{
    public interface IBasixMemory
    {
        Span<byte> Access(int index, int size);
    }
}