using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Calculators;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Tests.Unit
{
    [TestClass]
    public class DibCalculatorTests
    {
        [TestMethod]
        public void T_01_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x01 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x01);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data8BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 1);
        }

        [TestMethod]
        public void T_02_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x02 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x02);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data16BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 2);
        }

        [TestMethod]
        public void T_03_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x03 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x03);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data24BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 3);
        }

        [TestMethod]
        public void T_04_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x04 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x04);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_0F_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x0F };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x0F);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.SpecialFunctionManufacturerSpecific);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 0);
        }

        [TestMethod]
        public void T_12_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x12 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x12);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Maximum);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data16BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 2);
        }

        [TestMethod]
        public void T_14_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x14 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x14);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Maximum);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_1F_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x1F };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x1F);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 0);
        }

        [TestMethod]
        public void T_22_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x22 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x22);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Minimum);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data16BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 2);
        }

        [TestMethod]
        public void T_44_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x44 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x44);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_54_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x54 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x54);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == null);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Maximum);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_84_00_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x84, 0x00 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x84);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x00 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_84_10_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x84, 0x10 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x84);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x10 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_84_20_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x84, 0x20 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x84);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x20 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 2);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_84_40_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x84, 0x40 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x84);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x40 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_84_50_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x84, 0x50 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x84);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x50 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_84_60_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x84, 0x60 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x84);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x60 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 2);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_84_80_40_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x84, 0x80, 0x40 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x84);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x80, 0x40 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 2);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_84_C0_40_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0x84, 0xC0, 0x40 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0x84);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0xC0, 0x40 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 3);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_C4_10_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0xC4, 0x10 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0xC4);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x10 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_C4_20_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0xC4, 0x20 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0xC4);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x20 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 2);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_C4_3B_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0xC4, 0x3B };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0xC4);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x3B }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 23);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 3);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }

        [TestMethod]
        public void T_C4_80_40_CalculateDib()
        {
            Byte[] bytes = new Byte[] { 0xC4, 0x80, 0x40 };
            Queue<Byte> buffer = new(bytes);
            IDibCalculator dibCalculator = DibCalculator.GetCalculator();
            DibCalculatorMessage vibCalculatorMessage = dibCalculator.CalculateDib(ref buffer);
            Assert.IsFalse(vibCalculatorMessage.IsError);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifByte == 0xC4);
            Assert.IsTrue(vibCalculatorMessage.Dib.DifeBytes.SequenceEqual(new List<Byte>() { 0x80, 0x40 }));
            Assert.IsTrue(vibCalculatorMessage.Dib.StorageNumber == 1);
            Assert.IsTrue(vibCalculatorMessage.Dib.Tariff == 0);
            Assert.IsTrue(vibCalculatorMessage.Dib.Subunit == 2);
            Assert.IsTrue(vibCalculatorMessage.Dib.FunctionField == DibFunctionField.Instantaneous);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataType == DibDataType.Data32BitInteger);
            Assert.IsTrue(vibCalculatorMessage.Dib.DataLength == 4);
        }
    }
}
