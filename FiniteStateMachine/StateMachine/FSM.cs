using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI
{
    public class FSM
    {
        private Dictionary<string, State> _states;
        private State _currentState;

        private Blackboard<string> _blackboard;

        public Blackboard<string> Blackboard
        {
            get { return _blackboard; }
            set { _blackboard = value; }
        }


        public FSM() 
        {
            _states = new Dictionary<string, State>();
            _blackboard = new Blackboard<string>();
        }

        public FSM(Blackboard<string> blackboard)
        {
            _states = new Dictionary<string, State>();
            _blackboard = blackboard;
        }

        public FSM AddState(string id, State state)
        {
            _states[id] = state;
            return this;
        }

        public FSM RemoveState(string id)
        {
            _states.Remove(id);
            return this;
        }

        public void ChangeState(string id)
        {
            if (_currentState?.OnExit != null)
            {
                _currentState?.OnExit(this);
            }
            _currentState = _states[id];
            if (_currentState?.OnEnter != null)
            {
                _currentState?.OnEnter(this);
            }
        }

        public void Start(string id)
        {
            ChangeState(id);
        }

        public void Tick()
        {
            _currentState.OnTick(this);
        }

    }
}
