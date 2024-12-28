using System.Text;
using System.Text.Json.Serialization;

namespace Cli.Models
{
    public class HeaderResult
    {
        [JsonPropertyName("Identification number")]
        public required UInt32 IdentificationNumber { get; set; }
        [JsonPropertyName("Manufacturer")]
        public required String Manufacturer { get; set; }
        [JsonPropertyName("Version")]
        public required Byte Version { get; set; }
        [JsonPropertyName("Device type")]
        public required Byte DeviceType { get; set; }
        [JsonPropertyName("Device type hum")]
        public required String DeviceTypeHum { get; set; }
        [JsonPropertyName("Access number")]
        public required Byte AccessNumber { get; set; }
        [JsonPropertyName("Status")]
        public required String Status { get; set; }
        [JsonPropertyName("Configuration")]
        public required String Configuration { get; set; }
        [JsonPropertyName("Encryption")]
        public required String Encryption { get; set; }

        public override string ToString() 
        {
            StringBuilder sb = new();

            sb.Append("Identification number:".PadRight(30, ' '));
            sb.Append(this.IdentificationNumber);
            sb.Append(Environment.NewLine);

            sb.Append("Manufacturer:".PadRight(30, ' '));
            sb.Append(this.Manufacturer);
            sb.Append(Environment.NewLine);

            sb.Append("Version:".PadRight(30, ' '));
            sb.Append(this.Version);
            sb.Append(Environment.NewLine);

            sb.Append("Device type:".PadRight(30, ' '));
            sb.Append(this.DeviceTypeHum);
            sb.Append(Environment.NewLine);

            sb.Append("Access number:".PadRight(30, ' '));
            sb.Append(this.AccessNumber);
            sb.Append(Environment.NewLine);

            sb.Append("Status:".PadRight(30, ' '));
            sb.Append(this.Status);
            sb.Append(Environment.NewLine);

            sb.Append("Configuration:".PadRight(30, ' '));
            sb.Append(this.Configuration);
            sb.Append(Environment.NewLine);

            sb.Append("Encryption:".PadRight(30, ' '));
            sb.Append(this.Encryption);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }

    public class InformationResult
    {
        [JsonPropertyName("C field")]
        public required String CField { get; set; }
        [JsonPropertyName("Primary address")]
        public Byte? PrimaryAddress { get; set; }
        [JsonPropertyName("CI field")]
        public required String CiField { get; set; }
        [JsonPropertyName("Decryption status")]
        public required String DecryptionStatus { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append("C field:".PadRight(30, ' '));
            sb.Append(this.CField);
            sb.Append(Environment.NewLine);

            if (this.PrimaryAddress != null)
            {
                sb.Append("Primary address:".PadRight(30, ' '));
                sb.Append(this.PrimaryAddress);
                sb.Append(Environment.NewLine);
            }

            sb.Append("CI field:".PadRight(30, ' '));
            sb.Append(this.CiField);
            sb.Append(Environment.NewLine);

            sb.Append("Decryption status:".PadRight(30, ' '));
            sb.Append(this.DecryptionStatus);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }

    public class DibResult
    {
        [JsonPropertyName("Dif byte")]
        public required String DifByte { get; set; }
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
        public required String DataType { get; set; }
    }

    public class VibResult
    {
        [JsonPropertyName("Vif byte")]
        public required String VifByte { get; set; }
        [JsonPropertyName("Vife bytes")]
        public String? VifeBytes { get; set; }
        [JsonPropertyName("Unit")]
        public String? Unit { get; set; }
        [JsonPropertyName("Description")]
        public String? Description { get; set; }
    }

    public class DataRecordResult
    {
        [JsonPropertyName("Record number")]
        public required Byte RecordNumber { get; set; }
        [JsonPropertyName("Dib")]
        public required DibResult Dib { get; set; }
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

    public class DatagramResult
    {
        [JsonPropertyName("Information")]
        public required InformationResult Information { get; set; }
        [JsonPropertyName("Header")]
        public required HeaderResult Header { get; set; }
        [JsonPropertyName("Data records")]
        public required List<DataRecordResult> DataRecords { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(this.Information.ToString());
            sb.Append(this.Header.ToString());
            sb.Append(Environment.NewLine);

            foreach (DataRecordResult dataRecord in this.DataRecords)
            {
                sb.Append("Record number: ");
                sb.Append(dataRecord.RecordNumber);
                sb.Append(Environment.NewLine);

                sb.Append("Dif byte: ");
                sb.Append(dataRecord.Dib.DifByte);
                sb.Append("     ");

                if (!String.IsNullOrEmpty(dataRecord.Dib.DifeBytes))
                {
                    sb.Append("Dife bytes: ");
                    sb.Append(dataRecord.Dib.DifeBytes);
                    sb.Append("     ");
                }

                if (dataRecord.Vib != null)
                {
                    sb.Append("Vif byte: ");
                    sb.Append(dataRecord.Vib.VifByte);
                    sb.Append("     ");

                    if (!String.IsNullOrEmpty(dataRecord.Vib.VifeBytes))
                    {
                        sb.Append("Vife bytes: ");
                        sb.Append(dataRecord.Vib.VifeBytes);
                        sb.Append("     ");
                    }
                }

                if (!String.IsNullOrEmpty(dataRecord.Data))
                {
                    sb.Append("Data: ");
                    sb.Append(dataRecord.Data);
                    sb.Append("     ");
                }

                sb.Append(Environment.NewLine);

                sb.Append("Data type: ");
                sb.Append(dataRecord.Dib.DataType);
                sb.Append("     ");

                if (dataRecord.Dib.StorageNumber != null)
                {
                    sb.Append("Storage number: ");
                    sb.Append(dataRecord.Dib.StorageNumber);
                    sb.Append("     ");
                }

                if (dataRecord.Dib.Tariff != null)
                {
                    sb.Append("Tariff: ");
                    sb.Append(dataRecord.Dib.Tariff);
                    sb.Append("     ");
                }

                if (dataRecord.Dib.Subunit != null)
                {
                    sb.Append("Subunit: ");
                    sb.Append(dataRecord.Dib.Subunit);
                    sb.Append("     ");
                }

                sb.Append(Environment.NewLine);

                if (dataRecord.NumericValue != null)
                {
                    sb.Append("Value: ");
                    sb.Append(dataRecord.NumericValue);
                    sb.Append(" ");
                }
                else if (!String.IsNullOrEmpty(dataRecord.TextValue))
                {
                    sb.Append("Value: ");
                    sb.Append(dataRecord.TextValue);
                    sb.Append(" ");
                }

                if (dataRecord.Vib != null)
                {
                    if (!String.IsNullOrEmpty(dataRecord.Vib.Unit))
                    {
                        sb.Append(dataRecord.Vib.Unit);
                        sb.Append(" ");
                    }

                    if (!String.IsNullOrEmpty(dataRecord.Vib.Description))
                    {
                        sb.Append(dataRecord.Vib.Description);
                        sb.Append(" ");
                    }
                }

                if (!String.IsNullOrEmpty(dataRecord.Comment))
                {
                    sb.Append(dataRecord.Comment);
                    sb.Append(" ");
                }

                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }

    public class Result
    {
        [JsonPropertyName("Datagram")]
        public DatagramResult? Datagram { get; set; }
        [JsonPropertyName("Error")]
        public String? Error { get; set; }

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(this.Error))
            {
                return $"{this.Error}" + Environment.NewLine;
            }
            else if (Datagram == null)
            {
                return "Parser fatal error" + Environment.NewLine;
            }
            else
            {
                return $"{Datagram.ToString()}";
            }
            
        }
    }
}