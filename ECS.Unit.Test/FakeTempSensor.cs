using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refac;

namespace ECS.Unit.Test
{
    public class FakeTempSensor : ITempSensor
    {
        public int GetTempNo { get; private set; } = 0;
        public int RunTestNo { get; private set; } = 0;

        public int GetTemp()
        {
            GetTempNo++;
            return 20;
        }

        public bool RunSelfTest()
        {
            RunTestNo++;
            return true;
        }
    }
}
