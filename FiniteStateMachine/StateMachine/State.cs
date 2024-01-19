using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI
{
    public class State
    {
        public Action<FSM> OnEnter;
        public Action<FSM> OnTick;
        public Action<FSM> OnExit;
    }
}
