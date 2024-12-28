using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Calculators;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Tests.Unit
{
    [TestClass]
    public class LvarCalculatorTests
    {
        [TestMethod]
        public void T_001_CalculateLvar()
        {
            Byte lvarFirstByte = 0x0B;
            Byte[] bytes = new Byte[] { 0x32, 0x72, 0x65, 0x74, 0x73, 0x61, 0x4D, 0x73, 0x75, 0x42, 0x4D };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0x0B, 0x32, 0x72, 0x65, 0x74, 0x73, 0x61, 0x4D, 0x73, 0x75, 0x42, 0x4D }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == null);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == "MBusMaster2");
        }

        [TestMethod]
        public void T_002_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC1;
            Byte[] bytes = new Byte[] { 0x12 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC1, 0x12 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 12.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_003_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC2;
            Byte[] bytes = new Byte[] { 0x12, 0x34 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC2, 0x12, 0x34 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 3412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_004_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC3;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC3, 0x12, 0x34, 0x56 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_005_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC4;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC4, 0x12, 0x34, 0x56, 0x78 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 78563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_006_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC5;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC5, 0x12, 0x34, 0x56, 0x78, 0x11 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 1178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_007_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC6;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11, 0x22 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC6, 0x12, 0x34, 0x56, 0x78, 0x11, 0x22 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 221178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_008_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC7;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC7, 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 33221178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_009_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC8;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33, 0x44 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC8, 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33, 0x44 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 4433221178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_010_CalculateLvar()
        {
            Byte lvarFirstByte = 0xC9;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33, 0x44, 0x55 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xC9, 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33, 0x44, 0x55 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == 554433221178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_011_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD1;
            Byte[] bytes = new Byte[] { 0x12 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD1, 0x12 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -12.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_012_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD2;
            Byte[] bytes = new Byte[] { 0x12, 0x34 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD2, 0x12, 0x34 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -3412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_013_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD3;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD3, 0x12, 0x34, 0x56 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_014_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD4;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD4, 0x12, 0x34, 0x56, 0x78 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -78563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_015_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD5;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD5, 0x12, 0x34, 0x56, 0x78, 0x11 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -1178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_016_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD6;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11, 0x22 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD6, 0x12, 0x34, 0x56, 0x78, 0x11, 0x22 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -221178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_017_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD7;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD7, 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -33221178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_018_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD8;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33, 0x44 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD8, 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33, 0x44 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -4433221178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_019_CalculateLvar()
        {
            Byte lvarFirstByte = 0xD9;
            Byte[] bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33, 0x44, 0x55 };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xD9, 0x12, 0x34, 0x56, 0x78, 0x11, 0x22, 0x33, 0x44, 0x55 }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == -554433221178563412.0);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == null);
        }

        [TestMethod]
        public void T_020_CalculateLvar()
        {
            Byte lvarFirstByte = 0xE1;
            Byte[] bytes = new Byte[] { 0xAA };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xE1, 0xAA }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == null);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == "10101010");
        }

        [TestMethod]
        public void T_021_CalculateLvar()
        {
            Byte lvarFirstByte = 0xE2;
            Byte[] bytes = new Byte[] { 0xAA, 0xAA };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xE2, 0xAA, 0xAA }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == null);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == "1010101010101010");
        }

        [TestMethod]
        public void T_022_CalculateLvar()
        {
            Byte lvarFirstByte = 0xE4;
            Byte[] bytes = new Byte[] { 0xAA, 0xAA, 0xAA, 0xAA };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xE4, 0xAA, 0xAA, 0xAA, 0xAA }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == null);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == "10101010101010101010101010101010");
        }

        [TestMethod]
        public void T_023_CalculateLvar()
        {
            Byte lvarFirstByte = 0xF6;
            Byte[] bytes = new Byte[] { 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA };
            Queue<Byte> buffer = new(bytes);
            ILvarCalculator lvarCalculator = LvarCalculator.GetCalculator();
            LvarCalculatorMessage lvarCalculatorMessage = lvarCalculator.CalculateLvar(ref buffer, lvarFirstByte);
            Assert.IsFalse(lvarCalculatorMessage.IsError);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.Data.SequenceEqual(new List<Byte>() { 0xF6, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA }));
            Assert.IsTrue(lvarCalculatorMessage.Lvar.NumericValue == null);
            Assert.IsTrue(lvarCalculatorMessage.Lvar.TextValue == "1010101010101010101010101010101010101010101010101010101010101010");
        }
    }
}