using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gmds { 
// ������Ϸ�������ڲ���destroy

[Serializable]
class State
{
    public string PlayerName;
    public int PlayerAge;
    public int PlayerSalary;
    public int PlayerCoin = 0;
    public int PlayerExp = 0;
    public int PlayerLvl = 0;
    
    // 5��������, ��ò���
    public int Strength = 0;    // ����
    public int StrengthExp = 0; //  ����EXP

    public int Mental = 0;  //  ��־
    public int MentalExp = 0;   //  ��־EXP

    public int Mind = 0;   //  ˼ά
    public int MindExp = 0;   //  ˼άEXP

    public int Knowledge = 0;   //  ����
    public int KnowledgeExp = 0;   //  ����EXP

    public int Practical = 0;   //  ʵ��
    public int PracticalExp = 0;   //  ʵ��EXP
}   

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus m_Instance;

    [SerializeField]
    [Header("Main Player Stats")]
    private State m_BasicData;

    [Header("Player Attributes")]
    public List<Attribute> m_Attributes = new List<Attribute>();


    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadInitialData();
    }

    void LoadInitialData()
    {
            //PlayerPrefs.GetString("Name");

            // ��PlayerPrefs���س�ʼ����������
            // ˳����������־��˼ά�����ۣ�ʵ��
            //m_Attributes[0].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Body");
            //m_Attributes[1].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Willpower");
            //m_Attributes[2].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Mind");
            //m_Attributes[3].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Knowledge");
            //m_Attributes[4].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Practical");

            m_Attributes[0].m_CurrentPoint = 2;
            m_Attributes[1].m_CurrentPoint = 3;
            m_Attributes[2].m_CurrentPoint = 5;
            m_Attributes[3].m_CurrentPoint = 4;
            m_Attributes[4].m_CurrentPoint = 1;

        }

    // ����һ�����ܰ�ť���ҵ���Ӧ������
    Attribute FindAttrib(SkillDisplay SD)
    {
        return SD.m_Skill.GetAffectedAttrib();
    }

    // �ӵ�
    public void AddInitPointOnSkill(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            Attribute attrib = FindAttrib(SD);
            // �ж��Ƿ񳬹�����
            int usedPoint = SumPoint(attrib);
            Debug.Log(usedPoint);
            if (usedPoint < attrib.m_CurrentPoint&& SD.m_Skill.m_Points < attrib.m_CurrentPoint)
            {
                SD.m_Skill.m_Points++;
            }
        }
    }

    // ����
    public void DropInitPointOnSkill(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            Attribute attrib = FindAttrib(SD);
            // �ж��Ƿ��������
            int usedPoint = SumPoint(attrib);
            Debug.Log(usedPoint);
            if (usedPoint > 0 && SD.m_Skill.m_Points>0)
            {
                SD.m_Skill.m_Points--;
            }
        }
    }

    // ����ͬһ���Եļ��ܣ������Ѽӵ�
    int SumPoint(Attribute attrib)
    {
        int currentPoint = 0;
        for(int i = 0; i < attrib.m_Skills.Count; i++)
        {
            var skill = attrib.m_Skills[i];
            currentPoint += skill.m_Points;
        }

        return currentPoint;
    }

    // ���Ļ��ý�Ǯ
    public void GainLoseCoin(int coinNum)
    {
        m_BasicData.PlayerCoin += coinNum;
    }

    // ���Ļ�������
    // ������or��������
    public void GainLoseStrength(int strengthNum)
    {
        m_BasicData.Strength += strengthNum;
        m_Attributes[0].m_CurrentPoint+= strengthNum;
    }

    public void GainLoseMental(int mentalNum)
    {
        m_BasicData.Mental += mentalNum;
        m_Attributes[1].m_CurrentPoint += mentalNum;
    }

    public void GainLoseMind(int mindNum)
    {
        m_BasicData.Mind += mindNum;
        m_Attributes[2].m_CurrentPoint += mindNum;
    }
    public void GainLoseKnowledge(int knowNum)
    {
        m_BasicData.Knowledge += knowNum;
        m_Attributes[3].m_CurrentPoint += knowNum;
    }
    public void GainLosePract(int practNum)
    {
        m_BasicData.Mental += practNum;
        m_Attributes[4].m_CurrentPoint += practNum;
    }

    // playerĳһ��ר����ֵ�ı仯
    public void AttribChange(Skill skill, int value)
    {
        skill.m_Points += value;
        if (skill.m_Points < 0)
            skill.m_Points = 0;
    }

    public string GetPlayerName()
    {
        return m_BasicData.PlayerName;
    }

    public string GetPlayerAge()
    {
        return m_BasicData.PlayerAge.ToString();
    }

    public string GetPlayerSalary()
    {
        return m_BasicData.PlayerSalary.ToString();
    }
    }
}