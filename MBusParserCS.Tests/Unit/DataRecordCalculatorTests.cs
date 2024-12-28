using MBusParserCS.Calculators;
using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Messages;
using MBusParserCS.Models;
using System.Reflection;

namespace MBusParserCS.Tests.Unit
{
    [TestClass]
    public class DataRecordCalculatorTests
    {
        [TestMethod]
        public void T_001_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.NoData;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_002_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x09 };
            DibDataType dataType = DibDataType.Data8BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 9.0);
        }

        [TestMethod]
        public void T_003_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0xF9 };
            DibDataType dataType = DibDataType.Data8BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == -7.0);
        }

        [TestMethod]
        public void T_004_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x67, 0x67 };
            DibDataType dataType = DibDataType.Data16BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 26471.0);
        }

        [TestMethod]
        public void T_005_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x67, 0xFF };
            DibDataType dataType = DibDataType.Data16BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == -153.0);
        }

        [TestMethod]
        public void T_006_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x10, 0x67, 0x01 };
            DibDataType dataType = DibDataType.Data24BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 91920.0);
        }

        [TestMethod]
        public void T_007_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x10, 0x67, 0xFF };
            DibDataType dataType = DibDataType.Data24BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == -39152.0);
        }

        [TestMethod]
        public void T_008_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x10, 0x67, 0xFF, 0x01 };
            DibDataType dataType = DibDataType.Data32BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 33515280.0);
        }

        [TestMethod]
        public void T_009_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x10, 0x67, 0xFF, 0xFF };
            DibDataType dataType = DibDataType.Data32BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == -39152.0);
        }

        [TestMethod]
        public void T_010_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x01, 0x00, 0x00, 0x00 };
            DibDataType dataType = DibDataType.Data32BitReal;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 1.4012984643248171E-45);
        }

        [TestMethod]
        public void T_011_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x01, 0x00, 0x00, 0xFF };
            DibDataType dataType = DibDataType.Data32BitReal;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == -1.7014120374287884E+38);
        }

        [TestMethod]
        public void T_012_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x01, 0x00, 0x00, 0xFF, 0x00, 0x01 };
            DibDataType dataType = DibDataType.Data48BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 1103789817857.0);
        }

        [TestMethod]
        public void T_013_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x01, 0x00, 0x00, 0xFF, 0x00, 0xF9 };
            DibDataType dataType = DibDataType.Data48BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == -7692303204351.0);
        }

        [TestMethod]
        public void T_014_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x01, 0x00, 0x00, 0xFF, 0x00, 0xF9, 0x00, 0x01 };
            DibDataType dataType = DibDataType.Data64BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 72331376711434240.0);
        }

        [TestMethod]
        public void T_015_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x01, 0x00, 0x00, 0xFF, 0x00, 0xF9, 0x00, 0xFF };
            DibDataType dataType = DibDataType.Data64BitInteger;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == -71783811364421632.0);
        }

        [TestMethod]
        public void T_016_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SelectionForReadout;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_017_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x12 };
            DibDataType dataType = DibDataType.Data2DigitBCD;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 12.0);
        }

        [TestMethod]
        public void T_018_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x12, 0x13 };
            DibDataType dataType = DibDataType.Data4DigitBCD;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 1312.0);
        }

        [TestMethod]
        public void T_019_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x12, 0x13, 0x14 };
            DibDataType dataType = DibDataType.Data6DigitBCD;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 141312.0);
        }

        [TestMethod]
        public void T_020_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x12, 0x13, 0x14, 0x15 };
            DibDataType dataType = DibDataType.Data8DigitBCD;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 15141312.0);
        }

        [TestMethod]
        public void T_021_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x12 };
            DibDataType dataType = DibDataType.DataVariableLength;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 18.0);
        }

        [TestMethod]
        public void T_022_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { 0x12, 0x13, 0x14, 0x15, 0x16, 0x17 };
            DibDataType dataType = DibDataType.Data12DigitBCD;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == 171615141312.0);
        }

        [TestMethod]
        public void T_023_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SpecialFunctionManufacturerSpecific;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_024_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SpecialFunctionManufacturerSpecificExtandedNextDatagram;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_025_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SpecialFunctionIdleFilter;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_026_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SpecialFunctionReserved0x3F;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_027_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SpecialFunctionReserved0x4F;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_028_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SpecialFunctionReserved0x5F;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_029_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SpecialFunctionReserved0x6F;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }

        [TestMethod]
        public void T_030_CalculateValueData()
        {
            Byte[] bytes = new Byte[] { };
            DibDataType dataType = DibDataType.SpecialFunctionGlobalReadout;
            DataRecordCalculator obj = DataRecordCalculator.GetCalculator();
            MethodInfo methodInfo = typeof(DataRecordCalculator).GetMethod("CalculateDataValue", BindingFlags.Public | BindingFlags.Instance);
            ValueDataRecordCalculatorMessage result = (ValueDataRecordCalculatorMessage)methodInfo.Invoke(obj, new object[] { dataType, bytes });
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.Value == null);
        }





        [TestMethod]
        public void T_001_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x01, 0xFD, 0x62, 0xBF };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0xBF }));
            Assert.IsTrue(result.DataRecord.NumericValue == -65.0);
            Assert.IsTrue(result.DataRecord.TextValue == null);
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_002_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x84, 0x00, 0x13, 0x84, 0x9E, 0x20, 0x02 };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x84, 0x9E, 0x20, 0x02 }));
            Assert.IsTrue(result.DataRecord.NumericValue == 35692.164);
            Assert.IsTrue(result.DataRecord.TextValue == null);
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_003_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x04, 0x24, 0x84, 0x06, 0x28, 0x05 };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x84, 0x06, 0x28, 0x05 }));
            Assert.IsTrue(result.DataRecord.NumericValue == 86509188.0);
            Assert.IsTrue(result.DataRecord.TextValue == null);
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_004_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x2E, 0x9F, 0x00, 0x65, 0xA2, 0x00, 0xFB, 0xA6, 0x00 };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x65, 0xA2, 0x00, 0xFB, 0xA6, 0x00 }));
            Assert.IsTrue(result.DataRecord.NumericValue == 107610102650000.0);
            Assert.IsTrue(result.DataRecord.TextValue == null);
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_005_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x04, 0x07, 0xA4, 0x41, 0x00, 0x00 };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0xA4, 0x41, 0x00, 0x00 }));
            Assert.IsTrue(result.DataRecord.NumericValue == 168040000.0);
            Assert.IsTrue(result.DataRecord.TextValue == null);
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_006_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x0B, 0x3B, 0x50, 0x49, 0x00 };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x50, 0x49, 0x00 }));
            Assert.IsTrue(result.DataRecord.NumericValue == 4.95);
            Assert.IsTrue(result.DataRecord.TextValue == null);
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_007_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x06, 0x6D, 0x3B, 0x09, 0x2C, 0xF7, 0x21, 0x00 };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x3B, 0x09, 0x2C, 0xF7, 0x21, 0x00 }));
            Assert.IsTrue(result.DataRecord.NumericValue == null);
            Assert.IsTrue(result.DataRecord.TextValue == "2023-01-23 12:09:59");
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_008_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x0D, 0xFD, 0x0C, 0x0B, 0x32, 0x72, 0x65, 0x74, 0x73, 0x61, 0x4D, 0x73, 0x75, 0x42, 0x4D };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x0B, 0x32, 0x72, 0x65, 0x74, 0x73, 0x61, 0x4D, 0x73, 0x75, 0x42, 0x4D }));
            Assert.IsTrue(result.DataRecord.NumericValue == null);
            Assert.IsTrue(result.DataRecord.TextValue == "MBusMaster2");
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_009_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x04, 0x6D, 0x11, 0xB2, 0xA9, 0x2C };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x11, 0xB2, 0xA9, 0x2C }));
            Assert.IsTrue(result.DataRecord.NumericValue == null);
            Assert.IsTrue(result.DataRecord.TextValue == "2021-12-09 18:17:00");
            Assert.IsTrue(result.DataRecord.Comment == "Summer time");
        }

        [TestMethod]
        public void T_010_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x04, 0x6D, 0x0B, 0x0A, 0xA9, 0x24 };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x0B, 0x0A, 0xA9, 0x24 }));
            Assert.IsTrue(result.DataRecord.NumericValue == null);
            Assert.IsTrue(result.DataRecord.TextValue == "2021-04-09 10:11:00");
            Assert.IsTrue(result.DataRecord.Comment == null);
        }

        [TestMethod]
        public void T_011_CalculateDataRecord()
        {
            Byte[] bytes = new Byte[] { 0x84, 0xC0, 0x40, 0xFF, 0x14, 0x60, 0x22, 0x00, 0x00 };
            Queue<Byte> buffer = new(bytes);
            IDataRecordCalculator dataRecordCalculator = DataRecordCalculator.GetCalculator();
            DataRecordCalculatorMessage result = dataRecordCalculator.CalculateDataRecord(ref buffer, null);
            Assert.IsFalse(result.IsError);
            Assert.IsTrue(result.DataRecord.Data.SequenceEqual(new List<Byte>() { 0x60, 0x22, 0x00, 0x00 }));
            Assert.IsTrue(result.DataRecord.NumericValue == null);
            Assert.IsTrue(result.DataRecord.TextValue == "0x60 0x22 0x00 0x00");
            Assert.IsTrue(result.DataRecord.Comment == null);
        }
    }
}