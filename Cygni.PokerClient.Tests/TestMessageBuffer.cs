using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cygni.PokerClient.Communication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cygni.PokerClient.Tests
{
    [TestClass]
    public class TestMessageBuffer
    {
        [TestMethod]
        public void TestHalfReceivedMessages()
        {
            var buffer = new MessageBuffer("_");
            buffer.Input("Foxtrot_Unicorn_Ch");
            CollectionAssert.AreEqual(new String[]{"Foxtrot","Unicorn"},buffer.ReadMessages().ToArray());
            Assert.AreEqual(0, buffer.ReadMessages().Count());
            buffer.Input("arlie_Kilo_");
            CollectionAssert.AreEqual(new String[] { "Charlie", "Kilo" }, buffer.ReadMessages().ToArray());
        }
    }
}
