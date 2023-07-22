using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Parser
{
    public enum TokenType
    {
        ERROR,
        NUMB_INT,
        LET,
        WORD,
        ADD,
        MIN,
        MUL,
        DIV,
        EQ,
        EOL
    }
}