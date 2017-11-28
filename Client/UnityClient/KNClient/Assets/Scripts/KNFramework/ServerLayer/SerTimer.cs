using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{
    /// <summary>
    /// 计时器模块
    /// </summary>
    public class SerTimer : ServiceModule<SerTimer>
    {
        public override int Priority
        {
            get { return 100; }
        }

        /// <summary>
        /// 所有计时器的管理
        /// </summary>
        private Dictionary<int, TimerTaskItem> _timerTaskItemDic = new Dictionary<int, TimerTaskItem>();

        /// <summary>
        /// 真实流逝时间计时器
        /// </summary>
        private LinkedList<SerTimerItem> _realTimerTaskCheckList = new LinkedList<SerTimerItem>();

        /// <summary>
        /// 
        /// </summary>
        private int _realTimerTaskNum = 0;

        /// <summary>
        /// 游戏内流逝时间计时器
        /// </summary>
        private LinkedList<SerTimerItem> _gameTimerTaskCheckList = new LinkedList<SerTimerItem>();

        /// <summary>
        /// 
        /// </summary>
        private int _gameTimerTaskNum = 0;

        /// <summary>
        /// 
        /// </summary>
        private bool _gameTimerNeedCheckAgain = false;

        /// <summary>
        /// 
        /// </summary>
        private int _gameTimerNeedRemoveNum = 0;

        /// <summary>
        /// 游戏内计时器
        /// </summary>
        private float _gameTimer = 0f;

        public override void OnUpdate()
        {
            _gameTimer += Time.deltaTime;
            if (_realTimerTaskNum > 0)
            {

            }   
        }

        public void DoGameTimerTask()
        {
            if (_gameTimerTaskNum == 0)
            {
                return;
            }
            foreach(var timerItem in _gameTimerTaskCheckList)
            {
                _gameTimerTaskCheckList.RemoveFirst();
            }
        }

        public void AddGameTimer(float waitTime)
        {

        }
    }

    public class SerTimerItem
    {
        public int loopTime = 0;

        public float _checkTime;

        public Action _ac = null;
    }
}