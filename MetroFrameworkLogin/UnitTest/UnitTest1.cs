using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetroFrameworkLogin.Siniflar;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        TestFunctions test = new TestFunctions();
        [TestMethod]
        public void TestMethod1()
        {
             test = new TestFunctions();
        }
        [TestMethod]
        public void girisYapiliyorMu()
        {
            bool sonuc = test.girisYapiliyor("admin", "admin");
            Assert.AreEqual(true, sonuc);
        }
        [TestMethod]
        public void AdetSayiMi()
        {
            bool sonuc = test.AdetSayi("5");
            Assert.AreEqual(true, sonuc);
        }
        [TestMethod]
        public void AdetBosMu()
        {
            bool sonuc = test.AdetBos("");
            Assert.AreEqual(true, sonuc);
        }
        [TestMethod]
        public void AdetSifirIleMiBaslar()
        {
            bool sonuc = test.adetSifirIleMiBasliyor("03");
            Assert.AreEqual(true, sonuc);
        }

    }
}
