using System;

namespace SimulationTest
{
    public class Class2 : Interface1
    {
        void Interface1.Bla()
        {
            throw new NotImplementedException();
        }
    }
}
