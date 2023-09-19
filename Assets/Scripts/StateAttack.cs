﻿using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 攻擊
    /// </summary>
    public class StateAttack : State
    {
        [SerializeField, Header("送出攻擊檢測的時間點"), Range(0, 5)]
        private float timeSendAttackCheck = 0.3f;
        [SerializeField, Header("攻擊結束的時間點"), Range(0, 5)]
        private float timeAttackEnd = 0.5f;
        [SerializeField, Header("追蹤狀態")]
        private StateTrack stateTrack;
        [SerializeField, Header("敵人資料")]
        private DataBasic data;


        private string parAttack = "觸發攻擊";
        private float timer;
        private bool canSendAttack = true;
        private DamageSystem damageSystem;

        private void Start()
        {
            damageSystem = GameObject.Find("太空員").GetComponent<DamageSystem>();
        }
        public override State RunCurrentState()
        {
            if (timer == 0)
            {
                ani.SetTrigger(parAttack);
            }
            else
            {
                if (timer >= timeSendAttackCheck && canSendAttack)
                {
                    canSendAttack = false;
                    if (stateTrack.AttackTarget())
                    {
                        //print("<color=#69f>擊中玩家!</color>");
                        damageSystem.Damage(data.attack);
                    }
                }
                else if (timer >= timeAttackEnd)
                {
                    canSendAttack = true;
                    timer = 0;
                    return stateTrack;
                }
            
            }
            timer += Time.deltaTime;
            return this;
        }
    }

}
