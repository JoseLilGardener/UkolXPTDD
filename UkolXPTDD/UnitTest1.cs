using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace UkolXPTDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodJmeno()
        {
            KnihovnaTrid.Class1 HerniPostava = new KnihovnaTrid.Class1();
            HerniPostava.Jmeno = "jmeno1";
            Assert.AreEqual("jmeno1", HerniPostava.jmeno);
        }
        [TestMethod]
        public void HerniPostava_SetTooLongName_NameNotSet()
        {
            HerniPostava postava = new HerniPostava();
            postava.Jmeno = "PřílišDlouhéJméno";
            Assert.AreNotEqual("PřílišDlouhéJméno", postava.Jmeno);
            Assert.AreEqual("Příliš dlouhé jméno!", postava.Upozorneni);
        }
        [TestMethod]
        public void HerniPostava_LevelInitializedTo1()
        {
            HerniPostava postava = new HerniPostava();
            Assert.AreEqual(1, postava.Level);
        }
        [TestMethod]
        public void HerniPostava_PoziceXInitializedToZero()
        {
            HerniPostava postava = new HerniPostava();
            Assert.AreEqual(0, postava.PoziceX);
        }
        [TestMethod]
        public void HerniPostava_PoziceYInitializedToZero()
        {
            HerniPostava postava = new HerniPostava();
            Assert.AreEqual(0, postava.PoziceY);
        }
        [TestMethod]
        public void Hrac_SetValidSpecialization_SpecializationSet()
        {
            Hrac hrac = new Hrac();
            hrac.Specializace = "Kouzelník";
            Assert.AreEqual("Kouzelník", hrac.Specializace);
        }
        [TestMethod]
        public void Hrac_ConstructorSetsAttributesInheritedFromBaseClass()
        {
            HerniPostava postava = new Hrac("John");
            Hrac hrac = new Hrac(postava, "Kouzelník", Oblicej.VelkyNos, Vlasy.Drdol, BarvaVlasu.Kastanova);
            Assert.AreEqual("John", hrac.Jmeno);
            Assert.AreEqual(1, hrac.Level);
            Assert.AreEqual(0, hrac.PoziceX);
            Assert.AreEqual(0, hrac.PoziceY);
        }
        [TestMethod]
        public void Hrac_PridejXP_IncreasesLevelAt100TimesCurrentLevelXP()
        {
            Hrac hrac = new Hrac();
            hrac.PridejXP(99);
            hrac.PridejXP(2);
            Assert.AreEqual(1, hrac.Level);
            hrac.PridejXP(1); 
            Assert.AreEqual(2, hrac.Level);
        }
        [TestMethod]
        public void Hrac_ToString_ReturnsCorrectString()
        {
            HerniPostava postava = new HerniPostava("John");
            Hrac hrac = new Hrac(postava, "Kouzelník", Oblicej.VelkyNos, Vlasy.Drdol, BarvaVlasu.Kastanova);
            string result = hrac.ToString();
            Assert.AreEqual("Jméno: John, Pozice X: 0, Pozice Y: 0, Level: 1, Specializace: Kouzelník, Obličej: VelkyNos, Vlasy: Drdol, Barva Vlasů: Kastanova, XP: 0", result);
        }

    }
}