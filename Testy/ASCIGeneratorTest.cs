using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testy
{
    public class ASCIGeneratorTest
    {
        
        [Fact]
        public void RemovePolishLettersTest()
        {
            var generator = new ASCIGenerator("WROCŁAW");
            var result = generator.removePolishLetters();
            Assert.Equal("WROCLAW", result);
        }
    }
}
