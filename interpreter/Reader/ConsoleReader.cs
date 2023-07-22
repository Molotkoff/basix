using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basix.Parser;

namespace Basix.Console
{
    public class ConsoleReader
    {
        private Parser.Parser parser;
        //private BxBuilder builder;

        public ConsoleReader()
        {
            this.parser = new Parser.Parser();
            //this.builder = new BxBuilder();
        }

        public void Read()
        {
            /*
            while(true)
            {
                var source = Console.ReadLine();
                var tokens = parser.Parse(source);
                

            }
            */
        }
    }
}