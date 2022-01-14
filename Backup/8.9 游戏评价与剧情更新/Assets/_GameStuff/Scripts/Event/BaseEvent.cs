using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{
    public class BaseEvent : ScriptableObject
    {
        [Serializable]
        public class CheckItem
        {
            public CheckType type;
            public Skill skill;
        }

        public EventGenre m_Genre;    // 可能是练习，休息，外出
        public EventType m_Type;
        public string m_Title;
        public Sprite cg;
        public Image icon;
        public Texture2D m_ButtonTexture;
        public string m_DialogBlock;
        public int m_difficulty;

        [Header("判定")]
        public CheckItem[] m_targetSkill;        //  检定相关的技能点
        public bool m_isSuccess;
        public bool[] m_Result;

        [Header("基本消耗")]
        [SerializeField]
        public int dCoin;  // 金钱
        [SerializeField]
        public int dStrength;  // 精神力
        [SerializeField]
        public int dMental;    // 体力

        [Header("属性收益")]
        [SerializeField]
        public int dStrengthExp;  // 精神力EXP
        [SerializeField]
        public int dMentalExp;    // 体力EXP

        // 检定:
        // 输入对比的参数（两个）
        // 返回bool，是/否通过检定
        public bool Check(int value, int difficulty)
        {
            if (value >= difficulty)
            {
                Debug.Log("检定成功");
                return true;
            }

            // 2/6 
            float[] probsArray = new float[3];
            probsArray[0] = 0;
            probsArray[1] = (float)(value/difficulty);    //  (0,1]
            probsArray[2] = 1.0f - probsArray[1];
            int result = Choose(probsArray);

            Debug.LogFormat("value: {0}\ndifficulty: {0}\nresult: {0}\n", value, difficulty, result);

            if (result == 1)    // 判定成功
                return true;
            else
                return false;

        }



        public int Choose(float[] probs)
        {
            float total = 0;
            foreach (float elem in probs)
            {
                total += elem;
            }
            float randomPoint = UnityEngine.Random.value * total;
            for (int i = 0; i < probs.Length; i++)
            {
                if (randomPoint < probs[i])
                {
                    return i;
                }
                else
                {
                    randomPoint -= probs[i];
                }
            }
            return probs.Length - 1;
        }
        virtual protected void Awake()
        {

        }
        
        virtual public void HandleEvent()
        {
            // 不包含判定的其他数值变化
            Debug.Log("Start Today's event...");

            // 显示CG
            EventManager.m_Instance.DisplayEventCG(cg);

            // 基本固定的数值变化
            PlayerStatus.m_Instance.GainLoseCoin(dCoin);
            PlayerStatus.m_Instance.GainLoseStrength(dStrength);
            PlayerStatus.m_Instance.GainLoseMental(dMental);

            Debug.LogFormat("coin: {0}\nstrength: {0}\nmental: {0}\n", dCoin, dStrength, dMental);
        }
    }
}