﻿using UnityEngine;

namespace Leo.TwoD
{
    /// <summary>
    /// 待機
    /// </summary>
    public class StateIdle : State
    {
        [SerializeField, Header("遊走狀態")]
        private StateWander stateWander;
        [SerializeField, Header("是否開始游走")]
        private bool startWander;
        [SerializeField, Header("等待狀態的隨機時間範圍")]
        private Vector2 rangeIdleTime = new Vector2(0,3);
        [SerializeField, Header("追蹤狀態")]
        private StateTrack stateTrack;

        private float timeIdle;
        private float timer;

        private void Start()
        {
            timeIdle = Random.Range(rangeIdleTime.x, rangeIdleTime.y);
            //print($"<color=#d6f>隨機等待時間</color>");
        }
        public override State RunCurrentState()
        {
            timer += Time.deltaTime;
            //print($"<color=#69f>計時器：{timer}</color>");

            if (timer >= timeIdle) startWander = true;

            if (stateWander.TrackTarget())
            {
                ResetState();
                return stateTrack;
            }
            else if (startWander)
            {
                ResetState();
                return stateWander;
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 重設狀態資料
        /// </summary>
        private void ResetState()
        {
            timer = 0;
            startWander = false;
            timeIdle = Random.Range(rangeIdleTime.x, rangeIdleTime.y);
        }
    }

}
