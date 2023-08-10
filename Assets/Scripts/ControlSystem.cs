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
        [SerializeField, Header("檢查地板尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;
        [SerializeField, Header("檢查地板位移")]
        private Vector3 v3CheckGroundOffset = Vector3.zero;
        [SerializeField, Header("要偵測地板的圖層")]
        private LayerMask lyaerCheckGround;
        [SerializeField, Header("跳躍力道")]
        float jumpPower;

        private Rigidbody2D rig;
        private Animator ani;
        private string parRun = "開關跑步";

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f,0f,0.3f,0.5f);
            Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
            
        }

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
           // print("<color=yellow>喚醒事件</color>");
            ani = GetComponent<Animator>();
        }
        private void Start()
        {
            //print("<color=green>開始事件</color>");
        }
        private void Update()
        {
            MoveAndFlip();
            //CheckGround();
            Jump();
        }

        private void MoveAndFlip()
        {
            //print("<color=red>更新事件</color>");
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            float j = Input.GetAxis("Jump");
            //print(v+h+j);

            rig.velocity = new Vector2(h * movespeed, rig.velocity.y);

            /// <summary>
            /// float v = Input.GetAxis("Vertical")
            /// </summary>
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                //print("按下A");
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //print("按下D");
                transform.eulerAngles = Vector3.zero;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                //print("按下S");
            }

            ani.SetBool(parRun, h != 0);
        }

        private void Jump()
        {
            if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector2(0, jumpPower));
                print("001");
            }
        }
        private bool CheckGround()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0, lyaerCheckGround);
            print($"<color=#69f>碰到的物件{hit.name}</color>");
            return hit;
        }
    }

}
