using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSeminar7
{
    class TestClass
    {
        [CustomName("цифра")]
        public int I { get; set; }
        [CustomName("строка")]
        public string? S { get; set; }
        [CustomName("десятичная дробь")]
        public decimal D { get; set; }
        [CustomName("набор символов")]
        public char[]? C { get; set; }

        public TestClass()
        { }
        private TestClass(int i)
        {
            this.I = i;
        }
        public TestClass(int i, string s, decimal d, char[] c) : this(i)
        {
            this.S = s;
            this.D = d;
            this.C = c;
        }

        
    }
}
