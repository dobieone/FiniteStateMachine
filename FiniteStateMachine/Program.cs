using MD.AI.Examples.Complex;
using MD.AI.Examples.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //SimpleExample();        
            ComplexExample();
        }

        private static void ComplexExample()
        {
            var wc = new WoodCutterExample();
            wc.Run();
        }

        private static void SimpleExample()
        {
            var se = new SimpleExample();
            se.Run();
        }

    }
}
