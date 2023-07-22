using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Parser;

namespace Basix.Builder
{
    public interface IBxBuilder
    {
        BxResult Build(Token token);
    }
}