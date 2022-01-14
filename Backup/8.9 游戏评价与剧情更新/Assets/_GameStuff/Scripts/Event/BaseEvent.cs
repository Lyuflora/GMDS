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

        public EventGenre m_Genre;    // ��������ϰ����Ϣ�����
        public EventType m_Type;
        public string m_Title;
        public Sprite cg;
        public Image icon;
        public Texture2D m_ButtonTexture;
        public string m_DialogBlock;
        public int m_difficulty;

        [Header("�ж�")]
        public CheckItem[] m_targetSkill;        //  �춨��صļ��ܵ�
        public bool m_isSuccess;
        public bool[] m_Result;

        [Header("��������")]
        [SerializeField]
        public int dCoin;  // ��Ǯ
        [SerializeField]
        public int dStrength;  // ������
        [SerializeField]
        public int dMental;    // ����

        [Header("��������")]
        [SerializeField]
        public int dStrengthExp;  // ������EXP
        [SerializeField]
        public int dMentalExp;    // ����EXP

        // �춨:
        // ����ԱȵĲ�����������
        // ����bool����/��ͨ���춨
        public bool Check(int value, int difficulty)
        {
            if (value >= difficulty)
            {
                Debug.Log("�춨�ɹ�");
                return true;
            }

            // 2/6 
            float[] probsArray = new float[3];
            probsArray[0] = 0;
            probsArray[1] = (float)(value/difficulty);    //  (0,1]
            probsArray[2] = 1.0f - probsArray[1];
            int result = Choose(probsArray);

            Debug.LogFormat("value: {0}\ndifficulty: {0}\nresult: {0}\n", value, difficulty, result);

            if (result == 1)    // �ж��ɹ�
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
            // �������ж���������ֵ�仯
            Debug.Log("Start Today's event...");

            // ��ʾCG
            EventManager.m_Instance.DisplayEventCG(cg);

            // �����̶�����ֵ�仯
            PlayerStatus.m_Instance.GainLoseCoin(dCoin);
            PlayerStatus.m_Instance.GainLoseStrength(dStrength);
            PlayerStatus.m_Instance.GainLoseMental(dMental);

            Debug.LogFormat("coin: {0}\nstrength: {0}\nmental: {0}\n", dCoin, dStrength, dMental);
        }
    }
}