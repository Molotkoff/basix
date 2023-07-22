using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Parser
{
    public struct Token
    {
        public TokenType Type { get; init; }
        public object Value { get; init; }

        public Token(TokenType type, object _value)
        {
            this.Type = type;
            this.Value = _value;
        }
    }
}