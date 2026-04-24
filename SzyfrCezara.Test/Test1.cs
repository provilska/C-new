using System.Runtime.ConstrainedExecution;
using SzyfrCezara; 

namespace SzyfrCezara.Testy
{
    [TestClass]
    public class CezarTests
    {
        [TestMethod]
        public void Test_KluczDodatni()
        {
            var szyfr = new Cezar("abc", 3);

            string wynik = szyfr.Szyfruj();

            Assert.AreEqual("def", wynik);
        }

        [TestMethod]
        public void Test_KluczUjemny()
        {
            var szyfr = new Cezar("abc", -3);
            string wynik = szyfr.Szyfruj();
            Assert.AreEqual("xyz", wynik);
        }

        [TestMethod]
        public void Test_Spacja()
        {
            var szyfr = new Cezar("ala ma", 1);
            string wynik = szyfr.Szyfruj();
            Assert.AreEqual("bmb nb", wynik);
        }

        [TestMethod]
        public void Test_DuzyKlucz()
        {
            var szyfr = new Cezar("a", 28);
            string wynik = szyfr.Szyfruj();
            Assert.AreEqual("c", wynik);
        }
    }
}
