using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Builder.Expression;

namespace Basix.Types
{
    public class BxTypes
    {
        private Dictionary<string, BxType> values = new Dictionary<string, BxType>();

        private ExpressionCommands[][] casts;

        public BxType this[string name]
        {
            get => values[name];
        }

        public BxTypes()
        {
            expressions
            //generate standard types

            values.Add("NONE", new BxType(0));
            values.Add("BYTE", new BxType(1));
            values.Add("INTEGER", new BxType(4));
            values.Add("FLOAT", new BxType(4, 1));
        }

        public BxType Add(string name, int size, int parent) 
        {

        }

        public BxType Find(string name) => values[name];
    }
}