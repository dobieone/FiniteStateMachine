using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex.States
{
    internal class MoveState
    {
        private DateTime _timer;
        private string _stateName = "Moveing";
        private int _seconds = 0;

        private WoodCutterProfile _profile;

        public WoodCutterProfile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }


        public MoveState(WoodCutterProfile profile)
        {
            _profile = profile;
        }
        public void Enter(FSM fsm)
        {
            _seconds = 0;
            SetTimer(1);
            _profile.State = _stateName;
        }
        public void Tick(FSM fsm)
        {
            if (DateTime.Now >= _timer)
            {
                _seconds++;
                _profile.Energy -= _profile.MovementEnergy;
                SetTimer(1);
            }
            if (_seconds >= _profile.MovementSpeed)
            {
                fsm.ChangeState("Chop");
            }
        }


        private void SetTimer(int duration)
        {
            var dt = DateTime.Now;
            _timer = dt.AddSeconds((double)duration);
        }
    }
}
