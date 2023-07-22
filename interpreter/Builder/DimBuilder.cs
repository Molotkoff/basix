using Basix.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Types;
using Basix.Builder.Expression;

namespace Basix.Builder
{
    public class DimBuilder : IBxBuilder
    {
        enum Stage
        {
            LET,
            IDENTIFIER,
            EQ,
            EXPRESSION
        }

        private Stage stage;

        private string id;
        private BxType type;
        private ExpressionBuilder expressionBuilder;

        public DimBuilder(BxTypes bxTypes)
        {
            stage = Stage.LET;
        }

        public BxResult Build(Token token)
        {
            switch(stage)
            {
                case Stage.LET:
                    if (token.Type == TokenType.LET)
                    {
                        stage = Stage.IDENTIFIER;
                        return new BxResult(BxResultType.Proccess);
                    }
                    else
                        return new BxResult(BxResultType.Failed);
                case Stage.IDENTIFIER:
                    if (token.Type == TokenType.WORD)
                    {
                        stage = Stage.EQ;
                        id = (string)token.Value;
                        return new BxResult(BxResultType.Proccess);
                    }
                    else
                        return new BxResult(BxResultType.Failed);
                case Stage.EQ:
                    if (token.Type == TokenType.EQ)
                    {
                        stage = Stage.EXPRESSION;
                        return new BxResult(BxResultType.Proccess);
                    }
                    else
                        return new BxResult(BxResultType.Failed);
                case Stage.EXPRESSION:
                    if (expressionBuilder == null)
                        expressionBuilder = new ExpressionBuilder();

                    var result = expressionBuilder.Build(token);

                    switch(result.BxResultType)
                    {
                        case BxResultType.Failed:
                            return result;
                        case BxResultType.Proccess:
                            return result;
                        case BxResultType.Success:
                            // TODO: add generating expression with type checking
                            var dimExpression = new ContainerExpression(types);
                            dimExpression.Add()
                            expressionBuilder = null;
                            return new BxResult(BxResultType.Success, new DimExpression());
                    }

                    break;
            }

            return default;
        }
    }
}