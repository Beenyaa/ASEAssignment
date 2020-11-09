using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLanguageEnvironment;
using System;

namespace TurtleUnitTest
{
    /// <summary>Defines test class TurtleTests.</summary>
    [TestClass]
    public class TurtleTests
    {

        /// <summary>Defines the test method TestParseCommadMoveToValid.</summary>
        [TestMethod]
        public void TestParseCommadMoveToValid()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);
            ErrorHandler eh = new ErrorHandler();
            p.ParseCommands("moveto 100,200", "command line", eh);
            Assert.AreEqual(100, c.GetX(), 0.01);
            Assert.AreEqual(200, c.GetY(), 0.01);

        }

        [TestMethod]
        public void TestParseCommadMoveToInvalid()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);
            ErrorHandler eh = new ErrorHandler();
            String s = "";
            try
            {
                p.ParseCommands("moveto 100", "command line", eh);
            }

            catch (ArgumentNullException ex)
            {
                s = ex.Message;
            }

            Assert.AreNotEqual("hundred", c.GetX());
            Assert.AreEqual("Missing parameter at line: " + "command line", s);
        }

        [TestMethod]
        public void TestParseCommadNonNumericParam()
        {
            Canvas c = new Canvas();
            Parser p = new Parser(c);
            ErrorHandler eh = new ErrorHandler();
            String s = "";
            try
            {
                p.ParseCommands("moveto hundred,100", "command line", eh);
            }

            catch (ArgumentNullException ex)
            {
                s = ex.Message;
            }

            Assert.AreNotEqual("hundred", c.GetX());
            Assert.AreEqual("Invalid parameter at line: " + "command line", s);
        }
    }
}
