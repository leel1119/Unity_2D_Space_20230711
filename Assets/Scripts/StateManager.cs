using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 狀態管理
    /// </summary>
    public class StateManager : MonoBehaviour
    {

        [SerializeField, Header("狀態控制管理器")]
        public State stateDefault;

        private void Update()
        {
            RunStateMachine();
        }
        /// <summary>
        /// 執行狀態機
        /// </summary>
        private void RunStateMachine()
        {
            State nextState = stateDefault?.RunCurrentState();

            if (nextState != null) 
            {
                stateDefault = nextState;
            }
        }
    }

}
