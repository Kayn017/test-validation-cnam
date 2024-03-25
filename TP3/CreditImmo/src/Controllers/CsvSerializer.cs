using CreditImmo.Controllers.Interfaces;

namespace CreditImmo.Controllers;

public class CsvSerializer : ISerializer
{
    public string Path { get; set; }
    private StreamWriter writer;
    
    public CsvSerializer(string path, string[] headers, bool append = false)
    {
        this.Path = path;
        
        if(!File.Exists(this.Path))
        {
            this.writer = File.CreateText(this.Path);
        }
        else
        {
            this.writer = new(this.Path, append);
        }
        
        this.Serialize(headers);
    }
    
    ~CsvSerializer()
    {
        this.writer.Close();
    }
    
    public void Serialize(params string[] values)
    {
        writer.WriteLine(String.Join(";", values));
        writer.Flush();
    }
}