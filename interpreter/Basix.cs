using System;
using Basix.Console;
using Basix.Parser;
using Basix.Builder;
using Basix.Interpreter;

namespace Basix
{
    public class Basix
    {
        private static BasixMemory bxMemory;

        public static void Main(string[] args)
        {
            var tokens = new Parser.Parser().Parse("let i55 = 55 * 66 - 34");
        }
    }
}