using Basix.Interpreter.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Types;

namespace Basix.Builder.Expression
{
    public class ContainerExpression : IBxExpression
    {
        private List<IBxExpression> expressions;
        private BxTypes types;

        public ContainerExpression(BxTypes types)
        {
            this.expressions = new List<IBxExpression>();
            this.types = types;
        }

        public ContainerExpression Add(IBxExpression nextExpression)
        {
            expressions.Add(nextExpression);
            return this;
        }

        public ExpressionCommands GetExpression()
        {
            var data = new List<Command>();
            var process = new List<Command>();

            foreach(var expression in expressions) 
            {
                var expressionCommands = expression.GetExpression();

                data.AddRange(expressionCommands.Data);
                process.AddRange(expressionCommands.Process);
            }

            return new ExpressionCommands(data, process);
        }
    }
}