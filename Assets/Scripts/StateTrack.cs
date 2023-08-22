using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 追蹤
    /// </summary>
    public class StateTrack : State
    {

        [SerializeField, Header("移動速度"), Range(0, 5)]
        private float speed = 3.5f;

        [SerializeField, Header("遊走狀態")]
        private StateWander stateWander;

        [Header("攻擊區域")]
        [SerializeField]
        private Vector3 attackSize = Vector3.one;
        [SerializeField]
        private Vector3 attackoffset;
        [SerializeField, Header("攻擊狀態")]
        private StateAttack stateAttack;

        private Rigidbody2D rig;
        private string parWalk = "開關走路";

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.3f, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(attackoffset), attackSize);
        }

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }
        public override State RunCurrentState()
        {
            if (stateWander.TrackTarget())
            {
                if (!AttackTarget())
                {
                    ani.SetBool(parWalk, true);
                    ani.speed = 2.5f;
                    rig.velocity = new Vector2(speed * stateWander.direction, rig.velocity.y);
                    return this;
                }
                else 
                {
                    ResetState();
                    return stateAttack;
                }
            }
            else
            {
                ResetState();
                return stateWander;
            }
        }
        private void ResetState()
        {
            ani.SetBool(parWalk, false);
            ani.speed = 1f;
            rig.velocity = Vector3.zero;
        }
        public bool AttackTarget()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(attackoffset), attackSize, 0, layerTarget);
            return hit;
        }
    }

}
