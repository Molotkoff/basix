using Basix.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Util.Tree;
using Basix.Interpreter.Commands;

namespace Basix.Builder.Expression
{
    public class ExpressionBuilder : IBxBuilder
    {
        private BiTree<Expression> tree;

        public ExpressionBuilder()
        {
            tree = new BiTree<Expression>();
        }

        public BxResult Build(Token token)
        {
            switch (token.Type)
            {
                case TokenType.NUMB_INT:
                    tree = tree.Add(new Expression(ExpressionType.NUMBER_INT, token.Value), (int)ExpressionPriority.NUMB);
                    return new BxResult(BxResultType.Proccess, null);
                case TokenType.WORD:
                    tree = tree.Add(new Expression(ExpressionType.ID, token.Value), (int)ExpressionPriority.ID);
                    return new BxResult(BxResultType.Proccess, null);
                case TokenType.ADD:
                    tree = tree.Add(new Expression(ExpressionType.ADD, token.Value), (int)ExpressionPriority.ADD);
                    return new BxResult(BxResultType.Proccess, null);
                case TokenType.MIN:
                    tree = tree.Add(new Expression(ExpressionType.MIN, token.Value), (int)ExpressionPriority.MIN);
                    return new BxResult(BxResultType.Proccess, null);
                case TokenType.MUL:
                    tree = tree.Add(new Expression(ExpressionType.MUL, token.Value), (int)ExpressionPriority.MUL);
                    return new BxResult(BxResultType.Proccess, null);
                case TokenType.DIV:
                    tree = tree.Add(new Expression(ExpressionType.DIV, token.Value), (int)ExpressionPriority.DIV);
                    return new BxResult(BxResultType.Proccess, null);
                case TokenType.EOL:
                    return new BxResult(BxResultType.Success, new BiTreeExpression<Expression>(tree, BuildNode));
            }

            return default;
        }

        private void BuildNode(Expression expression, List<Command> dataCommands, List<Command> processCommands)
        {
            switch(expression.Type)
            {
                case ExpressionType.NONE:
                    {
                        var size = expression.Value != null ? (byte)expression.Value : (byte)1;
                        var args = new byte[1] { size };
                        var command = new Command(CommandType.NONE, args);

                        if (expression.Flag.HasFlag(ExpressionFlag.DATA))
                            dataCommands.Add(command);
                        else
                            processCommands.Add(command);
                        break;
                    }
                case ExpressionType.ADD:
                    {
                        if (expression.Flag.HasFlag(ExpressionFlag.FLOAT))
                            processCommands.Add(new Command(CommandType.ADD_FLOAT));
                        else
                            processCommands.Add(new Command(CommandType.ADD_INTEGER));
                        break;
                    }
                case ExpressionType.MIN:
                    {
                        if (expression.Flag.HasFlag(ExpressionFlag.FLOAT))
                            processCommands.Add(new Command(CommandType.MIN_FLOAT));
                        else
                            processCommands.Add(new Command(CommandType.MIN_INTEGER));
                        break;
                    }
                case ExpressionType.MUL:
                    {
                        if (expression.Flag.HasFlag(ExpressionFlag.FLOAT))
                            processCommands.Add(new Command(CommandType.MUL_FLOAT));
                        else
                            processCommands.Add(new Command(CommandType.MUL_INTEGER));
                        break;
                    }
                case ExpressionType.DIV:
                    {
                        if (expression.Flag.HasFlag(ExpressionFlag.FLOAT))
                            processCommands.Add(new Command(CommandType.DIV_FLOAT));
                        else
                            processCommands.Add(new Command(CommandType.DIV_INTEGER));
                        break;
                    }
                case ExpressionType.NUMBER_INT:
                    {
                        processCommands.Add(new Command(CommandType.PUSH_STACK_INTEGER, BitConverter.GetBytes((int)expression.Value)));
                        break;
                    }
            }
        }
    }
}