// StreamReader/Writer - best for working with plaintext strings.
// BinaryReader/Writer - used for serialization and storing raw binary data.
// FileStream - A kind of stream used for handling files.

string[] carBrands = { "Audi", "Ford", "Honda", "Hyundai", "Porsche" };

using (var streamWriter = new StreamWriter("SomeTextFile.txt"))
{
    foreach (string brand in carBrands)
    {
        streamWriter.WriteLine(brand);
    }
}
Console.WriteLine("Wrote data to txt file.");


Console.WriteLine("Reading data from txt file...");
using (var streamReader = new StreamReader("SomeTextFile.txt"))
{
    while (!streamReader.EndOfStream)
    {
        Console.WriteLine(streamReader.ReadLine());
    }
}
Console.WriteLine("End of file reached.\n");


using (var binaryWriter = new BinaryWriter(new FileStream(
           "SomeBinaryFile.bin", 
           FileMode.Create, 
           FileAccess.Write, 
           FileShare.Write)))
{
    foreach (string brand in carBrands)
    {
        binaryWriter.Write(brand);
    }
}
Console.WriteLine("Wrote data to bin file.");

Console.WriteLine("Reading data from bin file...");
using (var binaryReader = new BinaryReader(new FileStream(
           "SomeBinaryFile.bin",
           FileMode.Open,
           FileAccess.Read,
           FileShare.Read)))
{
    // BinaryReader does not provide the EndOfStream flag therefore the condition
    // used to detect the end of our list is slightly different.
    long fileLength = binaryReader.BaseStream.Length;   // Cache length to avoid slow lookup times.
    while (binaryReader.BaseStream.Position != fileLength)
    {
        Console.WriteLine(binaryReader.ReadString());
    }
}
Console.WriteLine("End of file reached.\n");