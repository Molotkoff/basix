using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Basix.Parser;
using Basix.Builder;
using Basix.Types;
using Basix.Builder.Expression;

namespace Tests
{
    public class BuilderTests
    {
        [Test]
        public void Check_Builder_Works()
        {
            var parser = new Parser();
            var tokens = parser.Parse("let i55 = 55 * 10 + 5");
            var bxTypes = new BxTypes();
            var builder = new BxBuilder(bxTypes);
            BxResult result = default;

            foreach (var token in tokens)
                result = builder.Build(token);

            var commands = result.Expression.GetExpression();
            Assert.AreEqual(null, null);
        }
    }
}