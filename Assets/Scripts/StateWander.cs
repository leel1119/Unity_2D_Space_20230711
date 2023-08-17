﻿using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 走路
    /// </summary>
    public class StateWander : State
    {
        [SerializeField, Header("角色的初始座標")]
        private Vector3 pointOriginal;
        [SerializeField, Header("左邊座標位移")]
        private float offsetLeft = -2;
        [SerializeField, Header("右邊座標位移")]
        private float offsetRight = 2;
        [SerializeField, Header("移動速度"), Range(0, 5)]
        private float speed = 2f;
        [SerializeField, Header("等待狀態")]
        private StateWander stateIdle;
        [SerializeField, Header("是否開始等待")]
        private bool startIdle;
        [SerializeField, Header("等待狀態的隨機時間範圍")]
        private Vector2 rangeIdleTime = new Vector2(0, 10);

        private float timeWander;
        private float timer;

        private int direction = 1;

        private Vector3 pointLeft => pointOriginal + Vector3.right * offsetLeft;
        private Vector3 pointRight => pointOriginal + Vector3.right * offsetRight;


        private string parWalk = "開關走路";
        private Rigidbody2D rig;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0.8f, 0.9f, 0.5f);
            Gizmos.DrawSphere(pointLeft, 0.1f);
            Gizmos.DrawSphere(pointRight, 0.1f);

        }

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            timeWander = Random.Range(rangeIdleTime.x, rangeIdleTime.y);
        }

        public override State RunCurrentState()
        {
            if (Vector3.Distance(transform.position, pointRight) < 0.5f)
            { 
                direction = -1;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Vector3.Distance(transform.position, pointLeft) < 0.5f)
            {
                direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
            rig.velocity = new Vector2(direction * speed, rig.velocity.y);
            ani.SetBool(parWalk, true);

            timer += Time.deltaTime;
            //print($"<color=#69f>計時器：{timer}</color>");

            if (timer >= timeWander) startIdle = true;

            if (startIdle)
            {
                return stateIdle;
            }
            else
            {
                return this;
            }
        }

        [ContextMenu("取得角色原始座標")]
        private void GetOriginalPoint()
        {
            pointOriginal = transform.position;
        }
    }

}