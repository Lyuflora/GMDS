using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds{

[CreateAssetMenu(menuName = "gmds/Event/Create Dev Event")]
public class DevEvent : BaseEvent
{
    public DevType type;    // �Ĵ��ࣺ��ֵϵͳ����ؿ���Ӱ����Ŀ�����ĸ����Ե÷�

    // ���۵��������鴢��
    public int m_Progress;

    [Header("Fungus Block")]
    public string boolName;
    public string m_DevName;


        void HandleDecideResult(bool resultProj, bool resultAttrib)
        {
            ProjChange(resultProj);
            AttribChange(resultAttrib);
        }

        void ProjChange(bool isSuccess)
        {
            if (isSuccess)
                GameStatus.m_Instance.m_GameFeatures[((int)type)] += GameStatus.m_Instance.m_Difficulty;
            else
                GameStatus.m_Instance.m_GameFeatures[((int)type)] += m_targetSkill[0].skill.m_Points;
        }

        void AttribChange(bool isSuccess)
        {
            if (isSuccess)
                return;
            else
                PlayerStatus.m_Instance.GainLoseMind(-1);   //  ���е��ж�ʧ�ܽ�����Ǿ�����-1
        }


        public override void HandleEvent()
        {
            base.HandleEvent();

            CalendarManager.m_Instance.SetFlowchartVar("DevName", m_DevName);

            int value, difficulty;

            // ��Ŀ�ӷ�    
            value = m_targetSkill[0].skill.m_Points;
            difficulty = GameStatus.m_Instance.m_Difficulty;
            m_Result[0] = Check(value, difficulty);

            // ������
            value = m_targetSkill[1].skill.m_Points;
            difficulty = GameStatus.m_Instance.m_Difficulty;
            m_Result[1] = Check(value*2, difficulty);

            Debug.LogFormat("��Ŀ�ӷ�: {0}\n������: {0}\n", m_Result[0], m_Result[1]);
            CalendarManager.m_Instance.SetFlowchartVar("isSuccess", m_Result[1]);   // ���ñ���
 
            HandleDecideResult(m_Result[0], m_Result[1]);
            Debug.Log("�����¼���� "+ type.ToString()+ m_DevName);



        }
    }
}