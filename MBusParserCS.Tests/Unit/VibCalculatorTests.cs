using MBusParserCS.Calculators;
using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Tests.Unit
{
    [TestClass]
    public class VibCalculatorTests
    {
        [TestMethod]
        public void T_04_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0x04 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0x04);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "Wh");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "Energy");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == 1);
        }

        [TestMethod]
        public void T_65_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0x65 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0x65);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "\u00B0C");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "External temperature");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == -2);
        }

        [TestMethod]
        public void T_6D_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0x6D };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0x6D);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.DataTypeFJIM);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "Time point (date & time)");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == 0);
        }

        [TestMethod]
        public void T_7C_01_48_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0x7C, 0x01, 0x48 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0x7C);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { 0x01, 0x48 }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "H");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == 0);
        }

        [TestMethod]
        public void T_83_FC_10_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0x83, 0xFc, 0x10 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0x83);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { 0xFC, 0x10 }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "Wh");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "Energy Accumulation of abs value for both positive and negative contribution");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == 0);
        }

        [TestMethod]
        public void T_FC_A2_73_04_6C_61_67_69_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0xFC, 0xA2, 0x73, 0x04, 0x6C, 0x61, 0x67, 0x69 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0xFC);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { 0xA2, 0x73, 0x04, 0x6C, 0x61, 0x67, 0x69 }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "igal Per hour");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == -3);
        }

        [TestMethod]
        public void T_FD_08_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0xFD, 0x08 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0xFD);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { 0x08 }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "Access number");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == 0);
        }

        [TestMethod]
        public void T_FD_10_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0xFD, 0x10 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0xFD);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { 0x10 }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "Customer location");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == 0);
        }

        [TestMethod]
        public void T_FD_48_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0xFD, 0x48 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0xFD);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { 0x48 }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "V");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "Volts");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == -1);
        }

        [TestMethod]
        public void T_FD_62_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0xFD, 0x62 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0xFD);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { 0x62 }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == VibDataType.Numeric);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "Control signal");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == 0);
        }

        [TestMethod]
        public void T_FF_14_CalculateVib()
        {
            Byte[] bytes = new Byte[] { 0xFF, 0x14 };
            Byte[]? manufacturer = null;
            Queue<Byte> buffer = new(bytes);
            IVibCalculator vibCalculator = VibCalculator.GetCalculator();
            VibCalculatorMessage vibCalculatorMessage = vibCalculator.CalculateVib(ref buffer, ref manufacturer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifByte == 0xFF);
            Assert.IsTrue(vibCalculatorMessage.Vib.VifeBytes.SequenceEqual(new List<Byte>() { 0x14 }));
            Assert.IsTrue(vibCalculatorMessage.Vib.DataType == null);
            Assert.IsTrue(vibCalculatorMessage.Vib.Unit == "");
            Assert.IsTrue(vibCalculatorMessage.Vib.Description == "VIFEs and data of this block are manufacturer specific");
            Assert.IsTrue(vibCalculatorMessage.Vib.Magnitude == null);
        }
    }
}