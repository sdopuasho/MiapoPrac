using System;
using MiapoPracticProjectGAN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiapoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForNotNull()
        {
            MiapoPracticProjectGAN.Windows.MainWindowMoreInfo page = new MiapoPracticProjectGAN.Windows.MainWindowMoreInfo();
            MiapoPracticProjectGAN.Windows.ShipmentMoreInfo page2 = new MiapoPracticProjectGAN.Windows.ShipmentMoreInfo();
            MiapoPracticProjectGAN.Windows.EmployeeMoreInfo page3 = new MiapoPracticProjectGAN.Windows.EmployeeMoreInfo();
            Assert.IsNotNull(page.testupload("", "", 0, 0));
            Assert.IsNotNull(page2.Loadtobd(0,0, ""));
            Assert.IsNotNull(page3.testSave(1,"", "", "", "", ""));
        }

        [TestMethod]
        public void TestForCorrectValue()
        {
            MiapoPracticProjectGAN.Windows.MainWindowMoreInfo page = new MiapoPracticProjectGAN.Windows.MainWindowMoreInfo();
            MiapoPracticProjectGAN.Windows.ShipmentMoreInfo page2 = new MiapoPracticProjectGAN.Windows.ShipmentMoreInfo();
            MiapoPracticProjectGAN.Windows.EmployeeMoreInfo page3 = new MiapoPracticProjectGAN.Windows.EmployeeMoreInfo();
            Assert.IsInstanceOfType(page.testupload("", "", 0, 0), typeof( bool));
            Assert.IsNotInstanceOfType(page.testupload("", "", 0, 0), typeof(string));
            Assert.IsNotInstanceOfType(page.testupload("", "", 0, 0), typeof(int));
            Assert.IsNotInstanceOfType(page.testupload("", "", 0, 0), typeof(decimal));
            Assert.IsNotInstanceOfType(page.testupload("", "", 0, 0), typeof(char));
            Assert.IsInstanceOfType(page2.Loadtobd(0, 0, ""), typeof(bool));
            Assert.IsNotInstanceOfType(page2.Loadtobd(0, 0, ""), typeof(string));
            Assert.IsNotInstanceOfType(page2.Loadtobd(0, 0, ""), typeof(int));
            Assert.IsNotInstanceOfType(page2.Loadtobd(0, 0, ""), typeof(decimal));
            Assert.IsNotInstanceOfType(page2.Loadtobd(0, 0, ""), typeof(char));
            Assert.IsInstanceOfType(page3.testSave(1, "", "", "", "", ""), typeof(bool));
            Assert.IsNotInstanceOfType(page3.testSave(1, "", "", "", "", ""), typeof(string));
            Assert.IsNotInstanceOfType(page3.testSave(1, "", "", "", "", ""), typeof(int));
            Assert.IsNotInstanceOfType(page3.testSave(1,"", "", "", "", ""), typeof(decimal));
            Assert.IsNotInstanceOfType(page3.testSave(1,"", "", "", "", ""), typeof(char));
        }

        [TestMethod]
        public void TestForWorkUpdateInformationProducts()
        {
            MiapoPracticProjectGAN.Windows.MainWindowMoreInfo page = new MiapoPracticProjectGAN.Windows.MainWindowMoreInfo();
            MiapoPracticProjectGAN.Windows.ShipmentMoreInfo page2 = new MiapoPracticProjectGAN.Windows.ShipmentMoreInfo();
            MiapoPracticProjectGAN.Windows.EmployeeMoreInfo page3 = new MiapoPracticProjectGAN.Windows.EmployeeMoreInfo();
            Assert.IsFalse(page.testupload("","",0,0));
            Assert.IsFalse(page.testupload("", "new", 1, 1));
            Assert.IsFalse(page.testupload("new", "", 1, 1));
            Assert.IsFalse(page.testupload("new", "new", 0,1));
            Assert.IsFalse(page.testupload("new", "new", 1, 0));
            Assert.IsTrue(page.testupload("Отвертка", "Сыр-косичка", 21, 100));
            //Assert.IsTrue(page.testupload("Сыр-косичка", "Отвертка", 100, 21));
            Assert.IsFalse(page2.Loadtobd(0, 1, "1"));
            Assert.IsFalse(page2.Loadtobd(1, 0, "1"));
            Assert.IsFalse(page2.Loadtobd(1, 1, ""));
            Assert.IsTrue(page2.Loadtobd(1, 1, "Мясо"));
            Assert.IsFalse(page3.testSave(1, "", "1", "1", "1", "1"));
            Assert.IsFalse(page3.testSave(1, "1", "", "1", "1", "1"));
            Assert.IsFalse(page3.testSave(1, "1", "1", "", "1", "1"));
            Assert.IsFalse(page3.testSave(1, "1", "1", "1", "", "1"));
            Assert.IsFalse(page3.testSave(1, "1", "1", "1", "1", ""));
            Assert.IsTrue(page3.testSave(1, "Alehandro1", "Ivanov1", "MiDlovich1", "And@gmail.com", "8(800)1553535"));
        }
        [TestMethod]
        public void testautor()
        {
            MiapoPracticProjectGAN.Windows.Autorization page = new MiapoPracticProjectGAN.Windows.Autorization();
            Assert.IsNotNull(page.test("", ""));
            Assert.IsInstanceOfType(page.test("", ""), typeof(int));
            Assert.IsNotInstanceOfType(page.test("", ""), typeof(string));
            Assert.IsNotInstanceOfType(page.test("", ""), typeof(bool));
            Assert.IsNotInstanceOfType(page.test("", ""), typeof(char));
            int idroresult = 1;
            Assert.AreEqual(page.test("QWE", "ASD"), idroresult);
        }
        [TestMethod]
        public void testregistration()
        {
            MiapoPracticProjectGAN.Windows.Registration page = new MiapoPracticProjectGAN.Windows.Registration();
            Assert.IsNotNull(page.testing("", "", "", "", "", "", ""));
            Assert.IsInstanceOfType(page.testing("", "", "", "", "", "", ""), typeof(bool));
            Assert.IsNotInstanceOfType(page.testing("", "", "", "", "", "", ""), typeof(string));
            Assert.IsNotInstanceOfType(page.testing("", "", "", "", "", "", ""), typeof(int));
            Assert.IsNotInstanceOfType(page.testing("", "", "", "", "", "", ""), typeof(char));
            Assert.IsTrue(page.testing("Testvalue", "Testvalue", "Testvalue", "Testvalue", "Testvalue", "Testvalue", "Testvalue"));
        }
    }
}
//testing("","","","","","","")