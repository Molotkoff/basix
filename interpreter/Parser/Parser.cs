using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Parser
{
    public class Parser
    {
        public IEnumerable<Token> Parse(string source)
        {
            var rawParser = new RawParser(source);
            var tokens = new List<Token>();

            while(true)
            {
                var token = rawParser.Next();
                tokens.Add(token);

                if (token.Type == TokenType.EOL)
                    return tokens;
            }
        }
    }
}
