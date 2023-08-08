using UnityEngine;


namespace Leo_2D
{   
    /// <summary>
    /// 2D 橫向捲軸的控制系統：移動、跳躍與動畫
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 500)]
        private float movespeed = 3.5f;

        private Rigidbody2D rig;

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            print("<color=yellow>喚醒事件</color>");
        }
        private void Start()
        {
            print("<color=green>開始事件</color>");
        }
        private void Update()
        {
            //print("<color=red>更新事件</color>");
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            float j = Input.GetAxis("Jump");
            print(v+h+j);
            rig.velocity = new Vector2(h * movespeed, rig.velocity.y);
        }
    }

}
