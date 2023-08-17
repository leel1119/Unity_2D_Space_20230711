using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 走路
    /// </summary>
    public class StateWander : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }

}
