namespace MBusParserCS
{
    public interface IParser
    {
        String Parse(String? frame, String? key);
    }
}