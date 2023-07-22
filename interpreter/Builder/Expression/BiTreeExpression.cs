using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Util.Tree;
using Basix.Interpreter.Commands;

namespace Basix.Builder.Expression
{
    public class BiTreeExpression<T> : IBxExpression
    {
        private BiTree<T> tree;
        private Action<T, List<Command>, List<Command>> visiter;
        private List<Command> dataCommands, processCommands;

        public BiTreeExpression(BiTree<T> tree, Action<T, List<Command>, List<Command>> visiter)
        {
            this.tree = tree;
            this.visiter = visiter;
            this.dataCommands = new List<Command>();
            this.processCommands = new List<Command>();
        }

        public ExpressionCommands GetExpression()
        {
            VisitTree(tree.Node);

            return new ExpressionCommands(dataCommands, processCommands);
        }

        private void VisitTree(BiTree<T>.BiNode<T> node)
        {
            if (node.LeftChild != null)
                VisitTree(node.LeftChild);
            if (node.RightChild != null)
                VisitTree(node.RightChild);

            visiter(node.Value, dataCommands, processCommands);
        }
    }
}