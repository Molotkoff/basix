using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Builder.Expression
{
    public struct Expression
    {
        public ExpressionFlag Flag { get; private set; }
        public ExpressionType Type { get; private set; }
        public object Value { get; private set; }

        public Expression(ExpressionType type, object value)
        {
            this.Type = type;
            this.Value = value;
            this.Flag = ExpressionFlag.NONE;
        }

        public Expression(ExpressionType type, ExpressionFlag flags, object value)
        {
            this.Type = type;
            this.Value = value;
            this.Flag = flags;
        }

    }
}