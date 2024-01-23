using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex.States
{
    internal class ChopState
    {
        private DateTime _timer;
        private int _duration = 5;
        private string _stateName = "Chopping";

        private WoodCutterProfile _profile;

        public WoodCutterProfile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }


        public ChopState(WoodCutterProfile profile)
        {
            _profile = profile;
            _duration = profile.ChoppingSpeed;
        }

        public void Enter(FSM fsm)
        {
            SetTimer(_duration);
            _profile.State = _stateName;
            _profile.Carrying = 0;
        }
        public void Tick(FSM fsm)
        {
            if (DateTime.Now >= _timer)
            {
                _profile.Carrying++;
                _profile.Chopped++;
                _profile.Energy -= _profile.ChoppingEnergyCost;
                if (_profile.Carrying >= _profile.MaxCarryAmount)
                {
                    fsm.ChangeState("Transport");
                }
                SetTimer(_duration);
            }
        }

        private void SetTimer(int duration)
        {
            var dt = DateTime.Now;
            _timer = dt.AddSeconds((double)duration);
        }
    }
}
