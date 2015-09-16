using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using NUnit.Framework;

using pokerpalooza.domain;

namespace pokerpalooza.tests.BlindController
{
    [TestFixture]
    class BlindTimerTests
    {
        BlindTimer _timer;
        int _interval = 5;

        [TestFixtureSetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Timer_CanStart()
        {
            _timer = new BlindTimer(10);
            _timer.Start();
            Thread.Sleep(1100);
            Assert.AreEqual(9, _timer.SecondsRemaining());
        }

        [Test]
        public void Timer_CanPause()
        {
            _timer = new BlindTimer(10);
            _timer.Start();
            Thread.Sleep(1050);
            _timer.Stop();
            Thread.Sleep(2000);
            Assert.AreEqual(9, _timer.SecondsRemaining());
        }

        [Test]
        public void Timer_TimeExpires()
        {
            _timer = new BlindTimer(1);
            _timer.Start();
            Thread.Sleep(5000);
            Assert.AreEqual(0, _timer.SecondsRemaining());
        }
    }
}
