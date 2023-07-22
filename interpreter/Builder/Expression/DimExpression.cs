using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Util.Tree;
using Basix.Types;
using Basix.Interpreter;

namespace Basix.Builder.Expression
{
    public class DimExpression : IBxExpression
    {
        private BxType dimType;
        private BasixMemory memory;
        private IBxExpression eqExpression;

        public DimExpression(BxType dimType, BasixMemory memory, IBxExpression eqExpression)
        {
            this.dimType = dimType;
            this.memory = memory;
            this.eqExpression = eqExpression;
        }

        public ExpressionCommands GetExpression()
        {
            
        }
    }
}