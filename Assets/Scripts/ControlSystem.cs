using UnityEngine;


namespace Leo_2D
{   
    /// <summary>
    /// 2D ��V���b������t�ΡG���ʡB���D�P�ʵe
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        [SerializeField, Header("���ʳt��"), Range(0, 500)]
        private float movespeed = 3.5f;

        private Rigidbody2D rig;

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            print("<color=yellow>����ƥ�</color>");
        }
        private void Start()
        {
            print("<color=green>�}�l�ƥ�</color>");
        }
        private void Update()
        {
            //print("<color=red>��s�ƥ�</color>");
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            float j = Input.GetAxis("Jump");
            print(v+h+j);
            rig.velocity = new Vector2(h * movespeed, rig.velocity.y);
        }
    }

}
