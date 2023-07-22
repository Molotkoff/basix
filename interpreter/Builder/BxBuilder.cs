using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Parser;
using Basix.Builder.Expression;
using Basix.Types;

namespace Basix.Builder
{
    public class BxBuilder : IBxBuilder
    {
        private ContainerExpression container;
        private BxTypes bxTypes;

        private IBxBuilder builder;

        public BxBuilder(BxTypes types)
        {
            this.container = new ContainerExpression(types);
            this.bxTypes = types;
        }

        public BxResult Build(Token token)
        {
            if (builder == null)
            {
                switch(token.Type)
                {
                    case TokenType.LET:
                        builder = new DimBuilder(bxTypes);
                        break;
                }
            }

            var result = builder.Build(token);

            if (result.BxResultType == BxResultType.Success)
            {
                container.Add(result.Expression);
                builder = null;
            }

            return new BxResult(BxResultType.Success, container);
        }
    }
}