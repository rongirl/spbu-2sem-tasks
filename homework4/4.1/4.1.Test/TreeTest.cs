using NUnit.Framework;
using Task4_1;

namespace Task4_1.Test;

public class TreeTests
{
    static object[] Cases =
    {
        new object[] { new Tree("(/ (* (- 10 1001) (+ 191 6)) 197)"), -991 },
        new object[] { new Tree("(* (+ 1 1) 2)"), 4 },
        new object[] { new Tree("(/ ( - 8 3) 5)"), 1 }
    };

    [TestCaseSource(nameof(Cases))]
    public void CalculateTest(Tree tree, int result)
    {
        Assert.AreEqual(tree.Calculate(), result);
    }
}
