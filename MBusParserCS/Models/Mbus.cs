namespace MBusParserCS.Models
{
    internal enum HeaderType
    {
        None,
        Short,
        Long,
        Unknown,
    }

    internal enum EncryptionMethod
    {
        None,
        Reserved1,
        DesCbcIvZero,
        DesCbcIvNonZero,
        Reserved0x04,
        AesCbcIvNonZero,
        Reserved0x06,
        Reserved0x07,
        Reserved0x08,
        Reserved0x09,
        Reserved0x0A,
        Reserved0x0B,
        Reserved0x0C,
        Reserved0x0D,
        Reserved0x0E,
        Reserved0x0F,
        Unknown,
    }

    internal enum DecryptionStatus
    {
        NotEncrypted,
        Encrypted,
        Decrypted,
        Unknown,
    }

    internal enum DibFunctionField
    {
        Instantaneous,
        Maximum,
        Minimum,
        ValueDuringError,
        Unknown,
    }

    internal enum DibDataType
    {
        NoData,
        Data8BitInteger,
        Data16BitInteger,
        Data24BitInteger,
        Data32BitInteger,
        Data32BitReal,
        Data48BitInteger,
        Data64BitInteger,
        SelectionForReadout,
        Data2DigitBCD,
        Data4DigitBCD,
        Data6DigitBCD,
        Data8DigitBCD,
        DataVariableLength,
        Data12DigitBCD,
        SpecialFunctionManufacturerSpecific,
        SpecialFunctionManufacturerSpecificExtandedNextDatagram,
        SpecialFunctionIdleFilter,
        SpecialFunctionReserved0x3F,
        SpecialFunctionReserved0x4F,
        SpecialFunctionReserved0x5F,
        SpecialFunctionReserved0x6F,
        SpecialFunctionGlobalReadout,
        Unknown,
    }

    internal enum VibDataType
    {
        AnyVif,
        CompactProfileWithRegister,
        CompactProfile,
        CustomString,
        DataTypeFJIM,
        DataTypeG,
        ManufacturerSpecificDataContainer,
        Numeric,
        StandardConformData,
        WirelessMbusDataContainer,
        Unknown,
    }

    internal enum LvarDataType
    {
        TextString,
        PositiveBCDnumber,
        NegativeBCDnumber,
        BinaryNumber,
        Unknown,
    }

    internal enum Manufacturer
    {
        Unknown,
        Abb,
        Schneider,
    }

    internal enum TelegramFormat
    {
        Unknown,
        LongFrameMBus,
        LongFrameWMBusFormatA,
        LongFrameWMBusFormatB,
    }

    internal enum ExtendedLinkLayerType
    {
        I,
        II,
        III,
        IV,
        V,
        None,
    }

    internal class ExtendedLinkLayer
    {
        public ExtendedLinkLayerType Type { get; set; }
        public Byte? Cc {  get; set; }
        public Byte? Acc { get; set; }
        public Byte[]? Sn {  get; set; }
        public Byte[]? PayloadCrc { get; set; }
        public Byte[]? M2 {  get; set; }
        public Byte[]? A2 { get; set; }
        public Byte? Ecl { get; set; }
        public Byte[]? Rtd { get; set; }
        public Byte? Rxl { get; set; }
        public Byte Length {  get; set; }
    }

    internal class ExtendedLinkLayerTypeAndLength
    {
        public ExtendedLinkLayerType Type { get; set; }
        public Byte Length { get; set; }
    }

    internal class VifVife
    {
        public Byte VifVifeByte { get; set; }
        public Byte? Extension { get; set; }
        public VibDataType? DataType { get; set; }
        public String Unit { get; set; } = String.Empty;
        public String Description { get; set; } = String.Empty;
        public SByte? Magnitude { get; set; }
    }

    internal class LvarDataTypeAndLength
    {
        public LvarDataType DataType { get; set; }
        public Byte DataLength { get; set; }
    }

    internal class Lvar
    {
        public List<Byte> Data { get; set; } = new();
        public Double? NumericValue { get; set; }
        public String? TextValue { get; set; }
    }

    internal class Header
    {
        public HeaderType HeaderType { get; set; }
        public Byte[]? IdentificationNumber { get; set; }
        public Byte[]? Manufacturer { get; set; } 
        public Byte? Version { get; set; }
        public Byte? DeviceType { get; set; }
        public Byte? AccessNumber { get; set; }
        public Byte? Status { get; set; }
        public Byte[]? Configuration { get; set; }
        public EncryptionMethod? Encryption { get; set; }
    }

    internal class Information
    {
        public Byte CField { get; set; }
        public Byte? PrimaryAddress { get; set; }
        public Byte CiField { get; set; }
        public DecryptionStatus DecryptionStatus { get; set; }
    }

    internal class Dib
    {
        public Byte DifByte { get; set; }
        public List<Byte> DifeBytes { get; set; } = new();
        public Boolean ExtensionBit { get; set; }
        public UInt32? StorageNumber { get; set; }
        public UInt32? Tariff {  get; set; }
        public UInt32? Subunit { get; set; }
        public DibFunctionField? FunctionField { get; set; }
        public DibDataType DataType { get; set; }
        public Byte DataLength { get; set; }
    }

    internal class Vib
    {
        public Byte VifByte { get; set; }
        public List<Byte> VifeBytes { get; set; } = new();
        public Byte? Extension { get; set; }
        public VibDataType? DataType { get; set; }
        public String Unit { get; set; } = String.Empty;
        public String Description { get; set; } = String.Empty;
        public SByte? Magnitude { get; set; }
    }

    internal class DataRecord
    {
        public Byte RecordNumber { get; set; }
        public Dib Dib { get; set; } = new();
        public Vib? Vib { get; set; }
        public List<Byte> Data { get; set; } = new();
        public Double? NumericValue { get; set; }
        public String? TextValue { get; set; }
        public String? Comment { get; set; }
    }

    internal class Datagram
    {
        public Information Information { get; set; } = new();
        public Header Header { get; set; } = new();
        public List<DataRecord> DataRecords { get; set; } = new();
    }
}