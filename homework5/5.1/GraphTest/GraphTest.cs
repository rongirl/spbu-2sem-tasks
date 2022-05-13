using NUnit.Framework;
using Task5_1;

namespace GraphTest;

public class Tests
{
    private string filePath = "homework5/5.1/GraphTest/InputTest.txt";
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestMatrixAfterParsing()
    {
        Graph graph = new Graph(filePath);
        int[,] CorrectMatrix = { { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 9, 5, 0, 0, 0 }, 
            { 0, 9, 0, 1, 0, 0, 0 }, 
            { 0, 5, 1, 0, 8, 0, 0 }, 
            { 0, 0, 0, 8, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 7},
            { 0, 0, 0, 0, 0, 7, 0} };
        for (int i = 0; i < CorrectMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < CorrectMatrix.GetLength(1); j++)
            {
                Assert.AreEqual(CorrectMatrix[i, j], graph.Matrix[i, j]);
            }
        }
    }

    [Test]
    public void TestCheckConnectedness()
    {
        Graph graph = new Graph(filePath);
        Assert.IsTrue(graph.CheckConnectedness(1, 1));
        Assert.IsTrue(graph.CheckConnectedness(1, 2));
        Assert.IsTrue(graph.CheckConnectedness(1, 3));
        Assert.IsTrue(graph.CheckConnectedness(1, 4));
        Assert.IsFalse(graph.CheckConnectedness(4, 5));
        Assert.IsFalse(graph.CheckConnectedness(3, 5));
    }
}
