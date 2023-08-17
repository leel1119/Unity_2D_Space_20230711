using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 追蹤
    /// </summary>
    public class StateTrack : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }

}
