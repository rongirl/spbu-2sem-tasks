using NUnit.Framework;
using System.IO;
using Task5_1;

namespace RouterTopologyTest;

public class Tests
{
    private string fileInputPath = "InputTest.txt";
    private string fileOutputPath = "OutputTest.txt";
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestMakeTopology()
    {
        RouterTopology topology = new RouterTopology();  
        topology.MakeTopology(fileInputPath, fileOutputPath);
        StreamReader reader = new StreamReader(fileOutputPath);
        Assert.AreEqual(reader.ReadLine(), "1: 2(9) 3(5)");
        Assert.AreEqual(reader.ReadLine(), "3: 4(8)");
    }
}
