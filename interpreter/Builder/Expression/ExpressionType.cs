using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Builder.Expression
{
    public enum ExpressionType : byte
    {
        NONE,
        ADD,
        MIN,
        MUL,
        DIV,
        NUMBER_INT,
        NUMBER_FLOAT,
        ID
    }
}