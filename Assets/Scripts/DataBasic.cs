using UnityEngine;

namespace Leo.TwoD
{
    [CreateAssetMenu(menuName = "LEO/Data Basic", fileName = "Data Basic")]
    public class DataBasic : ScriptableObject
    {
        [Header("血量"), Range(0, 1500)]
        public float hp = 100;
    }
}