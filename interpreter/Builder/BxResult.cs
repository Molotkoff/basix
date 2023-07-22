using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Builder.Expression;

namespace Basix.Builder
{
    public struct BxResult
    {
        public BxResultType BxResultType { get; private set; }
        public IBxExpression Expression { get; private set; }

        public BxResult(BxResultType resultType) : this(resultType, null) { }

        public BxResult(BxResultType resultType, IBxExpression expression)
        {
            this.BxResultType = resultType;
            this.Expression = expression;
        }
    }
}