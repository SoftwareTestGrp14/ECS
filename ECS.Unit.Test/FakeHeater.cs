using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refac;

namespace ECS.Unit.Test
{
    public class FakeHeater : IHeater
    {
        public int TurnOnNo { get; private set; }
        public int TurnOffNo { get; private set; }
        public int RunTestNo { get; private set; }

        public FakeHeater()
        {
            TurnOnNo = 0;
            TurnOffNo = 0;
            RunTestNo = 0;
        }

        public void TurnOn()
        {
            ++TurnOnNo;
        }

        public void TurnOff()
        {
            ++TurnOffNo;
        }

        public bool RunSelfTest()
        {
            ++RunTestNo;
            return true;
        }    
    }




}
