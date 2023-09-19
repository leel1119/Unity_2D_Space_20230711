using UnityEngine;

namespace Leo.TwoD
{
    public class Bullet : MonoBehaviour
    {
        [Header("玩家資料")]
        public DataBasic dataPlayer;

        private void Awake()
        {
            Destroy(gameObject,5);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}