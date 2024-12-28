using MBusParserCS.Calculators.Interfaces;
using MBusParserCS.Calculators;
using MBusParserCS.Messages;
using MBusParserCS.Models;

namespace MBusParserCS.Tests.Unit
{
    [TestClass]
    public class HeaderCalculatorTests
    {
        [TestMethod]
        public void T_001_CalculateHeader()
        {
            Byte ciField = 0x72;
            Byte[] bytes = new Byte[] { 0x09, 0x05, 0x80, 0x98, 0x01, 0x06, 0x01, 0x02, 0x24, 0x10, 0x20, 0x05 };
            Queue<Byte> buffer = new(bytes);
            IHeaderCalculator headerCalculator = HeaderCalculator.GetCalculator();
            HeaderMessage headerMessage = headerCalculator.CalculateHeader(ciField, ref buffer);
            Assert.IsFalse(headerMessage.IsError);
            Assert.IsTrue(headerMessage.Header.HeaderType == HeaderType.Long);
            Assert.IsTrue(headerMessage.Header.Manufacturer.SequenceEqual(new List<Byte>() { 0x01, 0x06 }));
            Assert.IsTrue(headerMessage.Header.Version == 0x01);
            Assert.IsTrue(headerMessage.Header.DeviceType == 0x02);
            Assert.IsTrue(headerMessage.Header.AccessNumber == 0x24);
            Assert.IsTrue(headerMessage.Header.Status == 0x10);
            Assert.IsTrue(headerMessage.Header.Configuration.SequenceEqual(new List<Byte>() { 0x20, 0x05 }));
            Assert.IsTrue(headerMessage.Header.Encryption == EncryptionMethod.AesCbcIvNonZero);
        }

        [TestMethod]
        public void T_002_CalculateHeader()
        {
            Byte ciField = 0x7A;
            Byte[] bytes = new Byte[] { 0x2F, 0x00, 0x30, 0x25 };
            Queue<Byte> buffer = new(bytes);
            IHeaderCalculator headerCalculator = HeaderCalculator.GetCalculator();
            HeaderMessage headerMessage = headerCalculator.CalculateHeader(ciField, ref buffer);
            Assert.IsFalse(headerMessage.IsError);
            Assert.IsTrue(headerMessage.Header.HeaderType == HeaderType.Short);
            Assert.IsTrue(headerMessage.Header.Manufacturer == null);
            Assert.IsTrue(headerMessage.Header.Version == null);
            Assert.IsTrue(headerMessage.Header.DeviceType == null);
            Assert.IsTrue(headerMessage.Header.AccessNumber == 0x2F);
            Assert.IsTrue(headerMessage.Header.Status == 0x00);
            Assert.IsTrue(headerMessage.Header.Configuration.SequenceEqual(new List<Byte>() { 0x30, 0x25 }));
            Assert.IsTrue(headerMessage.Header.Encryption == EncryptionMethod.AesCbcIvNonZero);
        }
    }
}
