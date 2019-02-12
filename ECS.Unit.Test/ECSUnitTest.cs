using System;
using NUnit.Framework;
using ECS.Refac;


namespace ECS.Unit.Test
{
    [TestFixture]
    public class ECSUnitTest
    {
        public IHeater heater;
        public ITempSensor tempSensor;
        private Refac.ECS _uut;

        [SetUp]
        public void Setup()
        {
            heater = new FakeHeater();
            tempSensor = new FakeTempSensor();
            _uut = new Refac.ECS(21, tempSensor, heater);
        }

        [TestCase(1)]
        [TestCase(17)]
        [TestCase(58)]
        [TestCase(79)]
        [TestCase(117)]
        public void Regulate_ThresholdIsOverTemp_TurnOnIsCalled(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _uut.Regulate();
            }
            FakeHeater heaterCheck=(FakeHeater)heater;
            Assert.That(heaterCheck.TurnOnNo, Is.EqualTo(times));
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(78)]
        [TestCase(46)]
        [TestCase(48)]
        public void Regulate_ThresholdIsUnderTemp_TurnOffIsCalled(int times)
        {
            _uut.SetThreshold(18);
            for (int i = 0; i < times; i++)
            {
                _uut.Regulate();
            }
            FakeHeater heaterCheck = (FakeHeater)heater;
            Assert.That(heaterCheck.TurnOffNo, Is.EqualTo(times));
        }


        [TestCase(1)]
        [TestCase(17)]
        [TestCase(58)]
        [TestCase(79)]
        [TestCase(117)]
        public void Regulate_RegulateIsCalled_GetTempIsCalledOnce(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _uut.Regulate();
            }
            FakeTempSensor tempSensorCheck = (FakeTempSensor) tempSensor;
            Assert.That(tempSensorCheck.GetTempNo, Is.EqualTo(times));
        }

        [TestCase(20)]
        [TestCase(5)]
        [TestCase(38)]
        [TestCase(17)]
        [TestCase(40)]
        public void SetThreshold_ChangeThreshold_ReturnTheNewThreshold(int thr)
        {
            _uut.SetThreshold(thr);
            Assert.That(_uut.GetThreshold(), Is.EqualTo(thr));
        }

        [TestCase(1)]
        [TestCase(8)]
        [TestCase(17)]
        [TestCase(89)]
        [TestCase(103)]
        public void GetCurTemp_GetCurTempIsCalled_GetTempGetsCalled(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _uut.GetCurTemp();
            }

            FakeTempSensor tempSensorCheck = (FakeTempSensor)tempSensor;
            Assert.That(tempSensorCheck.GetTempNo, Is.EqualTo(times));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(33)]
        [TestCase(145)]
        [TestCase(45)]
        public void RunSelfTest_RunSelfTestIsCalled_tempSensorSelfTestIsCalled(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _uut.RunSelfTest();
            }

            FakeTempSensor tempSensorCheck = (FakeTempSensor)tempSensor;
            Assert.That(tempSensorCheck.RunTestNo, Is.EqualTo(times));
        }

        [TestCase(3)]
        [TestCase(56)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(45)]
        public void RunSelfTest_RunSelfTestIsCalled_heaterSelfTestIsCalled(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _uut.RunSelfTest();
            }

            FakeHeater heaterCheck = (FakeHeater)heater;
            Assert.That(heaterCheck.RunTestNo, Is.EqualTo(times));
        }


    }
}
