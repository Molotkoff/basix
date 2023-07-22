using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Builder.Expression
{
    [Flags]
    public enum ExpressionFlag : long
    {
        NONE = 0,
        FLOAT = 1,
        DATA = 8
    }
}