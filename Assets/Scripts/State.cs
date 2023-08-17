using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 狀態抽象類別
    /// </summary>
    public abstract class State : MonoBehaviour
    {
        /// <summary>
        /// 執行當前的狀態
        /// </summary>
        public abstract State RunCurrentState();
    }

}
