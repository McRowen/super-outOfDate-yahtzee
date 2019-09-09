using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatzyGrupp2.Test
{
    class DataTest
    {
        public string Spelare { get; set; }
        public int Test1 { get; set; }
        public int Test2 { get; set; }
        public int Test3 { get; set; }
        public int Test4 { get; set; }

        public DataTest(string spelare, int test1, int test2, int test3, int test4)
        {
            Spelare = spelare;
            Test1 = test1;
            Test2 = test2;
            Test3 = test3;
            Test4 = test4;
        }
    }
}
