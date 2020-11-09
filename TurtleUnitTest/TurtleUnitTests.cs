using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLanguageEnvironment;
using System;

namespace TurtleUnitTest
{
    /// <summary>Defines test class TurtleTests.</summary>
    [TestClass]
    public class TurtleTests
    {

        Canvas c = new Canvas();

        /// <summary>Defines the test method TestParseCommadMoveToValid.</summary>
        [TestMethod]
        public void TestParseCommadMoveToValid()
        {
            Parser p = new Parser(c);
            ErrorHandler eh = new ErrorHandler();
            p.ParseCommands("moveto 100,200", 0, eh);
            Assert.AreEqual(100, c.GetX(), 0.01);
            Assert.AreEqual(200, c.GetY(), 0.01);

        }

        [TestMethod]
        public void TestParseCommadMoveToInvalid()
        {
            Parser p = new Parser(c);
            ErrorHandler eh = new ErrorHandler();
            p.ParseCommands("moveto hundred,twohundred", 0, eh);
            Assert.AreNotEqual("hundred", c.GetX());
            Assert.AreNotEqual("twohundred", c.GetY());

        }
    }
}
