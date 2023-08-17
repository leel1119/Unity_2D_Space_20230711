using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 攻擊
    /// </summary>
    public class StateAttack : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }

}
