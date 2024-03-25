using System.IO;
using CreditImmo.Controllers;
using Xunit;

namespace TP3.Controllers;

public class CsvSerializerTest
{
    [Fact]
    public void TestCsvSerializer()
    {
        string path = "test.csv";
        string[] headers = { "header1", "header2", "header3" };
        CsvSerializer csvSerializer = new CsvSerializer(path, headers);

        csvSerializer.Serialize("value1", "value2", "value3");

        Assert.True(File.Exists(path));
        
        string[] lines = File.ReadAllLines(path);
        
        Assert.Equal("header1;header2;header3", lines[0]);
        
        File.Delete(path); // Delete file for other tests
    }
}