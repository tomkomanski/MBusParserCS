using MBusParserCS.Models;

namespace MBusParserCS.Messages
{
    internal class Message : ErrorsContainer
    {
    }

    internal class HeaderMessage : ErrorsContainer
    {
        private Header header = new();

        public Header Header
        {
            get
            {
                return this.header;
            }
        }

        public void SetHeader(Header header)
        {
            if (header != null)
            {
                this.header = header;
            }
        }
    }

    internal class TelegramFormatMessage : ErrorsContainer
    {
        private TelegramFormat telegramFormat;

        public TelegramFormat TelegramFormat
        {
            get
            {
                return this.telegramFormat;
            }
        }

        public void SetTelegramFormat(TelegramFormat telegramFormat)
        {
            this.telegramFormat = telegramFormat;
        }
    }

    internal class DibCalculatorMessage : ErrorsContainer
    {
        private Dib dib = new();

        public Dib Dib
        {
            get
            {
                return this.dib;
            }
        }

        public void SetDib(Dib dib)
        {
            if (dib != null)
            {
                this.dib = dib;
            }
        }
    }

    internal class VibCalculatorMessage : ErrorsContainer
    {
        private Vib vib = new();

        public Vib Vib
        {
            get
            {
                return this.vib;
            }
        }

        public void SetVib(Vib vib)
        {
            if (vib != null)
            {
                this.vib = vib;
            }
        }
    }

    internal class ManufacturerCalculatorMessage : ErrorsContainer
    {
        private String manufacturerCode = String.Empty;
        private Manufacturer manufacturer;

        public String ManufacturerCode
        {
            get
            {
                return this.manufacturerCode;
            }
        }

        public Manufacturer Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
        }

        public void SetManufacturerCode(String manufacturerCode)
        {
            if (!String.IsNullOrEmpty(manufacturerCode))
            {
                this.manufacturerCode = manufacturerCode;
            }
        }

        public void SetManufacturer(Manufacturer manufacturer)
        {
            this.manufacturer = manufacturer;
        }
    }

    internal class DataRecordCalculatorMessage : ErrorsContainer
    {
        private DataRecord dataRecord = new();

        public Boolean ShouldProcess { get; set; } = true;
        public DataRecord DataRecord 
        { 
            get
            {
                return this.dataRecord;
            }
        }

        public void SetDataRecord(DataRecord dataRecord)
        {
            this.dataRecord = dataRecord;
        }
    }

    internal class ValueDataRecordCalculatorMessage : ErrorsContainer
    {
        private Double? value;

        public Double? Value 
        { 
            get
            {
                return this.value;
            }
        }

        public void SetValue(Double? value)
        {
            this.value = value;
        }
    }

    internal class LvarCalculatorMessage : ErrorsContainer
    {
        private Lvar lvar = new();

        public Lvar Lvar
        {
            get
            {
                return this.lvar;
            }
        }

        public void SetLvar(Lvar lvar)
        {
            if (lvar != null)
            {
                this.lvar = lvar;
            }
        }
    }

    internal class ParserMessage : ErrorsContainer
    {
        private Datagram datagram = new();

        public Datagram Datagram
        {
            get
            {
                return this.datagram;
            }
        }

        public void SetDatagram(Datagram datagram)
        {
            if (datagram != null)
            {
                this.datagram = datagram;
            }
        }
    }

    internal class ExtendedLinkLayerMessage : ErrorsContainer
    {
        private ExtendedLinkLayer extendedLinkLayer = new();

        public ExtendedLinkLayer ExtendedLinkLayer
        {
            get
            {
                return this.extendedLinkLayer;
            }
        }

        public void SetExtendedLinkLayer(ExtendedLinkLayer extendedLinkLayer)
        {
            if (extendedLinkLayer != null)
            {
                this.extendedLinkLayer = extendedLinkLayer;
            }
        }
    }
}