using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 受傷
    /// </summary>
    public class StateHit : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }

}
