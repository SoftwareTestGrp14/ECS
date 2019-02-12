﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refac;

namespace ECS.Unit.Test
{
    public class FakeHeater : IHeater
    {
        public int TurnOnNo { get; private set; } = 0;
        public int TurnOffNo { get; private set; } = 0;
        public int RunTestNo { get; private set; } = 0;

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