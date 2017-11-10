using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{
    /// <summary>
    /// 计时器模块
    /// </summary>
    public class TimerModule : MonoSingleton<TimerModule>
    {
        /// <summary>
        /// 游戏内时间检测间隔
        /// </summary>
        public float m_gameTimerCheckInterval = 0.05f;

        /// <summary>
        /// 真实时间检测间隔
        /// </summary>
        public float m_realTimerCheckInterval = 0.5f;

        /// <summary>
        /// 所有计时器的管理
        /// </summary>
        private Dictionary<int, TimerTaskItem> _timerTaskItemDic = new Dictionary<int, TimerTaskItem>();

        /// <summary>
        /// 真实流逝时间计时器
        /// </summary>
        private List<TimerTaskItem> _realTimerTaskCheckList = new List<TimerTaskItem>();

        /// <summary>
        /// 游戏内流逝时间计时器
        /// </summary>
        private List<TimerTaskItem> _gameTimerTaskCheckList = new List<TimerTaskItem>();

        /// <summary>
        /// 游戏内计时器
        /// </summary>
        private float _gameTimer = 0f;

        private void Update()
        {
            _gameTimer += Time.deltaTime;
          
        }
    }

    public class TimerTaskItem
    {

    }
}