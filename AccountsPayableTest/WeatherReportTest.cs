using System;
using AccountsPayable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AccountsPayableTest
{
    [TestClass]
    public class WeatherReportTest
    {
        private WeatherReport _sut;

        [TestMethod]
        public void TestMockData()
        {
            var wxs = new Mock<IWeatherService>();
            wxs.Setup(w => w.GetCurrentTemp()).Returns(75);
            WeatherReport subject = new WeatherReport(wxs.Object);
            Assert.AreEqual(75, subject.GetWeatherReport("123456"));
        }

        [TestMethod]
        public void TestMockControl()
        {
            var wxs = new Mock<WeatherService>();
            WeatherReport subject = new WeatherReport(wxs.Object);

            subject.GetWeatherReport("12345");

            wxs.VerifySet(wx => wx.ZipCode = "12345");
            wxs.Verify(wx => wx.GetCurrentTemp());
        }
    }
}
