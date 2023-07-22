using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Parser
{
    public class RawParser
    {
        private string source;
        private int index;

        public RawParser(string source)
        {
            this.source = source;
            this.index = 0;
        }

        public Token Next()
        {
            index = skip(index);

            if (index == -1)
                return new Token(TokenType.EOL, null);

            var _char = source[index];
            
            if (_char == '\n')
            {
                index = -1;
                return new Token(TokenType.EOL, null);
            }

            if (char.IsDigit(_char))
            {
                var nextIndex = parseNumber(index);
                var _int = int.Parse(source.Substring(index, nextIndex - index + 1));
                index = nextIndex + 1;

                return new Token(TokenType.NUMB_INT, _int);
            }

            if (_char == '=')
            {
                index++;
                return new Token(TokenType.EQ, null);
            }

            if (_char == '+')
            {
                index++;
                return new Token(TokenType.ADD, null);
            }

            if (_char == '-')
            {
                index++;
                return new Token(TokenType.MIN, null);
            }

            if (_char  == '*')
            {
                index++;
                return new Token(TokenType.MUL, null);
            }

            if (_char == '/')
            {
                index++;
                return new Token(TokenType.DIV, null);
            }

            if (char.IsLetter(_char))
            {
                var nextIndex = parseWord(index);
                var word = source.Substring(index, nextIndex - index + 1);

                index = nextIndex + 1;

                if (word == "let")
                    return new Token(TokenType.LET, null);

                return new Token(TokenType.WORD, word);
            }

            return new Token(TokenType.ERROR, "error message");
        }

        private int skip(int index)
        {
            next: if (index >= source.Length || index == -1)
                      return -1;

            switch(source[index])
            {
                case '\t':
                    index++;
                    goto next;
                case ' ':
                    index++;
                    goto next;
                default:
                    return index;
            }
        }

        private int parseNumber(int index)
        {
            while (char.IsDigit(source[index]))
                if (++index >= source.Length)
                    return index - 1;

            return index - 1;
        }

        private int parseWord(int index)
        {
            while (char.IsLetterOrDigit(source[index]))
                if (++index >= source.Length)
                    return index - 1;

            return index - 1;
        }
    }
}