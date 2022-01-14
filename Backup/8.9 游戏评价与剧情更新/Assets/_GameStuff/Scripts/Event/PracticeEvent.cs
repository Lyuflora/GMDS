using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Event/Create Practice Event")]
    public class PracticeEvent : BaseEvent
    {
        // ������ж�

        [SerializeField]
        private int difficulty; // ��ϰ��Ŀ�Ѷȣ������exp��أ�
        [SerializeField]
        private PlayerMode mode;    // ���������

        private int level;  //  봽�

        [SerializeField]
        private int tech_R_No = 0;  // ϡ�м������
        [SerializeField]
        private int tech_N_No = 0; // ��ͨ�������
        [SerializeField]
        private float success_N = 1.0f;
        [SerializeField]
        private float success_R = (float)(1.0f/6.0f);

        // ����exp
        // ������Ϊ�����֡����ܡ����ջ�
        // ���ȴ�����PracticeManager��Exp�����У�ͨ��PracticeId����
        int PracticeId;

        private void Awake()
        {
            base.Awake();
            m_Genre = EventGenre.Practice;
        }

        public int GenerateTech(float prop_N,float prop_R)
        {
            float[] probsArray = new float[3];
            probsArray[0] = 0;
            probsArray[1] = prop_R;
            probsArray[2] = 1 - 0 - prop_R;

            int result = Choose(probsArray);
            PracticeManager.m_Instance.LearnTech(tech_R_No);    // ��ѧ��
            if (result == 1)
            {
                Debug.Log("ѧ��ϡ�м���");
                PracticeManager.m_Instance.LearnTech(tech_N_No);
            }
            else
            {
                Debug.Log("ֻѧ����ͨ����");
            }
            return result;
        }



        //// �����¼�
        //public int Choose(float[] probs)
        //{
        //    float total = 0;
        //    foreach (float elem in probs)
        //    {
        //        total += elem;
        //    }
        //    float randomPoint = Random.value * total;
        //    for (int i = 0; i < probs.Length; i++)
        //    {
        //        if (randomPoint < probs[i])
        //        {
        //            return i;
        //        }
        //        else
        //        {
        //            randomPoint -= probs[i];
        //        }
        //    }
        //    return probs.Length - 1;
        //}

        int JudgePractice()
        {
            float prop_0 = 9f / 16f;
            float prop_1 = 23f / 16f;
            float prop_2 = 23f / 16f;
            float prop_3 = 9f / 16f;
            float[] probsArray = new float[4];
            probsArray[0] = prop_0;
            probsArray[1] = prop_1;
            probsArray[2] = prop_2;
            probsArray[3] = prop_3;

            int result = Choose(probsArray);
            PracticeManager.m_Instance.LearnTech(tech_R_No);    // ��ѧ��
            if (result == 1)
            {
                Debug.Log("+1");
                CalendarManager.m_Instance.SetFlowchartVar("isSuccess", false);   // ���ñ���

            }
            else if (result == 2)
            {
                Debug.Log("+2");
                CalendarManager.m_Instance.SetFlowchartVar("isSuccess", true);   // ���ñ���

            }
            else if (result == 3)
            {
                Debug.Log("+3");
                CalendarManager.m_Instance.SetFlowchartVar("isSuccess", true);   // ���ñ���


            }
            return result;

        }

        public override void HandleEvent()
        {
            base.HandleEvent();            

            // �жϽ���
            // 봽�Ļ����������ɻ�Ǯ������
            if (PracticeManager.m_Instance.m_Exp[PracticeId] >= 10)
            {
                // ϰ�ü���, �ж�ѧϰ�ļ�������ͨ����/ϡ�м���
                GenerateTech(success_N, success_R);
                Debug.Log("ϰ�ü��ܽ���...");
                PracticeManager.m_Instance.m_Exp[PracticeId] -= 10;
            }
            else
            {
                int result = JudgePractice();
                PracticeManager.m_Instance.m_Exp[PracticeId]+=result;
            }

            
        }
    }

}