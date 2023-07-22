using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Builder.Expression
{
    public enum ExpressionPriority
    {
        ADD  = 50,
        MIN  = 50,
        MUL  = 25,
        DIV  = 25,
        NUMB = 15,
        ID   = 15
    }
}