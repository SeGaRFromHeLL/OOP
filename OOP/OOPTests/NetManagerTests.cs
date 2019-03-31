﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP;
using System.Net;

namespace OOPTests
{
    [TestClass]
    public class NetManagerTests
    {
        [TestMethod]
        public void IsCorrectAddressTest()
        {
            Assert.IsTrue(NetManager.IsCorrectAddress("127.0.0.1:7777"));
        }

        [TestMethod]
        public void IsNotCorrectAddressTest()
        {
            Assert.IsTrue(!NetManager.IsCorrectAddress("ip:port"));
        }


        [TestMethod]
        public void IsCorrectIpTest()
        {
            Assert.IsTrue(NetManager.IsCorrectIp("127.0.0.1"));
        }

        [TestMethod]
        public void IsNotCorrectIpCommaTest()
        {
            Assert.IsTrue(!NetManager.IsCorrectIp("127,0,0,1"));
        }

        [TestMethod]
        public void IsCorrectPortTest()
        {
            Assert.IsTrue(NetManager.IsCorrectPort("7777"));
        }

        [TestMethod]
        public void IsNotCorrectPortTest()
        {
            Assert.IsTrue(!NetManager.IsCorrectPort("a2359"));
        }

        [TestMethod]
        public void ParseIpTest()
        {
            IPAddress ip = new IPAddress(new byte[] { 192, 168, 0, 1 });
            Assert.AreEqual(new IPEndPoint(ip, 2277), NetManager.ParseIp("192.168.0.1:2277"));
        }

    }
}
