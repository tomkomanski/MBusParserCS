using System.Text.Json.Serialization;

namespace MBusParserCS.Models
{
    public struct HeaderResult
    {
        [JsonPropertyName("Identification number")]
        public UInt32 IdentificationNumber { get; set; }
        [JsonPropertyName("Manufacturer")]
        public String Manufacturer { get; set; }
        [JsonPropertyName("Version")]
        public Byte Version { get; set; }
        [JsonPropertyName("Device type")]
        public Byte DeviceType { get; set; }
        [JsonPropertyName("Device type hum")]
        public String DeviceTypeHum { get; set; }
        [JsonPropertyName("Access number")]
        public Byte AccessNumber { get; set; }
        [JsonPropertyName("Status")]
        public String Status { get; set; }
        [JsonPropertyName("Configuration")]
        public String Configuration { get; set; }
        [JsonPropertyName("Encryption")]
        public String Encryption { get; set; }
    }

    public struct InformationResult
    {
        [JsonPropertyName("C field")]
        public String CField { get; set; }
        [JsonPropertyName("Primary address")]
        public Byte? PrimaryAddress { get; set; }
        [JsonPropertyName("CI field")]
        public String CiField { get; set; }
        [JsonPropertyName("Decryption status")]
        public String DecryptionStatus { get; set; }
    }

    public struct DibResult
    {
        [JsonPropertyName("Dif byte")]
        public String DifByte { get; set; }
        [JsonPropertyName("Dife bytes")]
        public String? DifeBytes { get; set; }
        [JsonPropertyName("Storage number")]
        public UInt32? StorageNumber { get; set; }
        [JsonPropertyName("Tariff")]
        public UInt32? Tariff {  get; set; }
        [JsonPropertyName("Subunit")]
        public UInt32? Subunit { get; set; }
        [JsonPropertyName("Function field")]
        public String? FunctionField { get; set; }
        [JsonPropertyName("Data type")]
        public String DataType { get; set; }
    }

    public struct VibResult
    {
        [JsonPropertyName("Vif byte")]
        public String VifByte { get; set; }
        [JsonPropertyName("Vife bytes")]
        public String? VifeBytes { get; set; }
        [JsonPropertyName("Unit")]
        public String? Unit { get; set; }
        [JsonPropertyName("Description")]
        public String? Description { get; set; }
    }

    public struct DataRecordResult
    {
        [JsonPropertyName("Record number")]
        public Byte RecordNumber { get; set; }
        [JsonPropertyName("Dib")]
        public DibResult Dib { get; set; }
        [JsonPropertyName("Vib")]
        public VibResult? Vib { get; set; }
        [JsonPropertyName("Data")]
        public String? Data { get; set; }
        [JsonPropertyName("Numeric value")]
        public Double? NumericValue { get; set; }
        [JsonPropertyName("Text value")]
        public String? TextValue { get; set; }
        [JsonPropertyName("Comment")]
        public String? Comment { get; set; }
    }

    public struct DatagramResult
    {
        [JsonPropertyName("Information")]
        public InformationResult Information { get; set; }
        [JsonPropertyName("Header")]
        public HeaderResult Header { get; set; }
        [JsonPropertyName("Data records")]
        public List<DataRecordResult> DataRecords { get; set; }
    }

    public struct Result
    {
        [JsonPropertyName("Datagram")]
        public DatagramResult? Datagram { get; set; }
        [JsonPropertyName("Error")]
        public String? Error { get; set; }
    }
}