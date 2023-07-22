using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Interpreter.Commands;

namespace Basix.Builder.Expression
{
    public interface IBxExpression
    {
        ExpressionCommands GetExpression();
    }
}