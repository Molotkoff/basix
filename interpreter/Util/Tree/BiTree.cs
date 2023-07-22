using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Util.Tree
{
    public class BiTree<T>
    {
        public class BiNode<T>
        {
            public T Value { get; internal set; }
            internal int Priority { get; set; }

            public BiNode<T> LeftChild { get; protected internal set; }
            public BiNode<T> RightChild { get; protected internal set; }

            public BiNode<T> Parent { get; protected internal set; }

            public BiNode<T> Root
            {
                get
                {
                    if (Parent != null)
                        return Parent.Root;

                    return this;
                }
            }

            public BiNode(BiNode<T> parent)
            {
                this.Parent = parent;
            }

            public BiNode(BiNode<T> parent, T value, int priority) : this(parent)
            {
                this.Value = value;
                this.Priority = priority;
            }
        }

        private BiNode<T> node;

        public BiNode<T> Node => node.Root;

        public BiTree<T> Add(T value, int priority)
        {
            if (node == null)
                node = new BiNode<T>(null, value, priority);
            else
                node = AddNode(node, value, priority);

            return this;
        }

        private BiNode<T> AddNode(BiNode<T> node, T value, int priority)
        {
            if (priority > node.Priority)
            {
                if (node.Parent == null)
                {
                    var me = new BiNode<T>(null, value, priority);
                    me.LeftChild = node;
                    node.Parent = me;

                    return me;
                }
                else
                {
                    if (priority > node.Parent.Priority)
                        return AddNode(node.Parent, value, priority);
                    else
                    {
                        var me = new BiNode<T>(node.Parent, value, priority);
                        me.LeftChild = node;

                        node.Parent = me;
                        node.Parent.RightChild = me;

                        return me;
                    }
                }
            }

            if (node.LeftChild == null)
            {
                node.LeftChild = new BiNode<T>(node, value, priority);
                return node;
            }
            else if (node.RightChild == null)
            {
                node.RightChild = new BiNode<T>(node, value, priority);
                return node.RightChild;
            }
            else if (node.RightChild.Priority < priority)
            {
                var rightChild = node.RightChild;
                node.RightChild = new BiNode<T>(node, value, priority);
                node.RightChild.LeftChild = rightChild;
                rightChild.Parent = node.RightChild;

                return node.RightChild;
            }
            else
                return AddNode(node.RightChild, value, priority);
        }
    }
}