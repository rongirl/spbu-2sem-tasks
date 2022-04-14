using NUnit.Framework;
using ControlWork;

namespace VectorTest;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ScalarTestTest()
        {
            Vector oneVector = new Vector();
            oneVector = oneVector.Inital("576 0 0");
            Vector twoVector = new Vector();
            twoVector = twoVector.Inital("1 1 1");
            //Assert.AreEqual(Vector.ScalarProduct(oneVector, twoVector), 576);
        }
    }
