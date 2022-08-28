using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using HandicraftApp;

namespace HandicraftAppTest
{
    [TestClass]
    public class UnitTest1
    {
        //Does CollectData.AskForDouble return a double if string is passed in as a parameter.
        [TestMethod]
        public void TestAskForDouble()
        {
            string testValue = "2.2";
            double expectedValue = 2.2;

            var input = new StringReader(testValue);
            Console.SetIn(input);

            var valueFromFunction = CollectData.AskForInt("Hello");

            Assert.AreEqual(expectedValue, valueFromFunction);
        }
    }
}
