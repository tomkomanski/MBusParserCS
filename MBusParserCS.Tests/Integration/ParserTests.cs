using MBusParserCS;
using MBusParserCS.Models;
using System;
using System.Text.Json;

namespace MBusParserCS.Tests.Integration
{
    [TestClass]
    public class ParserTests
    {
        public IEnumerable<String> Reader(String testFile)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(basePath, "Integration/Files", testFile);
            IEnumerable<String> lines = File.ReadAllLines(filePath);
            return lines;
        }

        [TestMethod]
        public void T_001()
        {
            String testFile = "001_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_002()
        {
            String testFile = "002_gavazzi_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_003()
        {
            String testFile = "003_apator_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_004()
        {
            String testFile = "004_apator_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_005()
        {
            String testFile = "005_apator_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_006()
        {
            String testFile = "006_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_007()
        {
            String testFile = "007_apator_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_008()
        {
            String testFile = "008_apator_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_009()
        {
            String testFile = "009_rel_gas.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_010()
        {
            String testFile = "010_hyd_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_011()
        {
            String testFile = "011_nzr_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_012()
        {
            String testFile = "012_acw_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }
        [TestMethod]
        public void T_013()
        {
            String testFile = "013_gwf_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_014()
        {
            String testFile = "014_fin_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }
        [TestMethod]
        public void T_015()
        {
            String testFile = "015_gmc_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_016()
        {
            String testFile = "016_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_017()
        {
            String testFile = "017_apator_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_018()
        {
            String testFile = "018_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_019()
        {
            String testFile = "019_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }
        [TestMethod]
        public void T_020()
        {
            String testFile = "020_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_021()
        {
            String testFile = "021_kam_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_022()
        {
            String testFile = "022_apator_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_023()
        {
            String testFile = "023_kamstrup_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_024()
        {
            String testFile = "024_kamstrup_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_025()
        {
            String testFile = "025_kamstrup_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_026()
        {
            String testFile = "026_acw_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_027()
        {
            String testFile = "027_apt_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_028()
        {
            String testFile = "028_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_029()
        {
            String testFile = "029_efe_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_030()
        {
            String testFile = "030_bmeters_room_sensor.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_031()
        {
            String testFile = "031_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_032()
        {
            String testFile = "032_emu_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_033()
        {
            String testFile = "033_maddalena_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_034()
        {
            String testFile = "034_efe_heat_cooling.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_035()
        {
            String testFile = "035_abb_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_036()
        {
            String testFile = "036_schneider_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_037()
        {
            String testFile = "037_gavazzi_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_038()
        {
            String testFile = "038_apator_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_039()
        {
            String testFile = "039_apator_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_040()
        {
            String testFile = "040_efe_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_041()
        {
            String testFile = "041_els_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_042()
        {
            String testFile = "042_els_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_043()
        {
            String testFile = "043_emh_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_044()
        {
            String testFile = "044_pad_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_045()
        {
            String testFile = "045_edc_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_046()
        {
            String testFile = "046_efe_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_047()
        {
            String testFile = "047_abb_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_048()
        {
            String testFile = "048_abb_electricity.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_049()
        {
            String testFile = "049_abb_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_050()
        {
            String testFile = "050_acw_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_051()
        {
            String testFile = "051_acw_water.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_052()
        {
            String testFile = "052_slb_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_053()
        {
            String testFile = "053_amt_heat.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }

        [TestMethod]
        public void T_054()
        {
            String testFile = "054_cs_error.txt";
            IEnumerable<String> lines = Reader(testFile);
            String frame = lines.ElementAt(0);
            String key = lines.ElementAt(1);
            String jsonString = lines.ElementAt(2);
            IParser parser = new Parser();
            String result = parser.Parse(frame, key);
            Assert.IsTrue(String.Equals(result, jsonString, StringComparison.Ordinal));
        }
    }
}