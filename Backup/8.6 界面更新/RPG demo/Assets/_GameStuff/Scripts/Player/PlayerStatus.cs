using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gmds { 
// 伴随游戏整个周期不被destroy

[Serializable]
class State
{
    public string PlayerName;
    public int PlayerAge;
    public int PlayerSalary;
    public int PlayerCoin = 0;
    public int PlayerExp = 0;
    public int PlayerLvl = 0;
    
    // 5个大属性, 最好不用
    public int Strength = 0;    // 体力
    public int StrengthExp = 0; //  体力EXP

    public int Mental = 0;  //  意志
    public int MentalExp = 0;   //  意志EXP

    public int Mind = 0;   //  思维
    public int MindExp = 0;   //  思维EXP

    public int Knowledge = 0;   //  积累
    public int KnowledgeExp = 0;   //  积累EXP

    public int Practical = 0;   //  实践
    public int PracticalExp = 0;   //  实践EXP
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

            // 从PlayerPrefs加载初始点数分配结果
            // 顺序：体力，意志，思维，积累，实践
            //m_Attributes[0].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Body");
            //m_Attributes[1].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Willpower");
            //m_Attributes[2].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Mind");
            //m_Attributes[3].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Knowledge");
            //m_Attributes[4].m_CurrentPoint = PlayerPrefs.GetInt("Attribute_Practical");

            m_Attributes[0].m_CurrentPoint = 6;
            m_Attributes[1].m_CurrentPoint = 8;
            m_Attributes[2].m_CurrentPoint = 3;
            m_Attributes[3].m_CurrentPoint = 2;
            m_Attributes[4].m_CurrentPoint = 1;

        }

    // 对于一个技能按钮，找到对应的属性
    Attribute FindAttrib(SkillDisplay SD)
    {
        return SD.m_Skill.GetAffectedAttrib();
    }

    // 加点
    public void AddInitPointOnSkill(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            Attribute attrib = FindAttrib(SD);
            // 判断是否超过上限
            int usedPoint = SumPoint(attrib);
            Debug.Log(usedPoint);
            if (usedPoint < attrib.m_CurrentPoint&& SD.m_Skill.m_Points < attrib.m_CurrentPoint)
            {
                SD.m_Skill.m_Points++;
            }
        }
    }

    // 减点
    public void DropInitPointOnSkill(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            Attribute attrib = FindAttrib(SD);
            // 判断是否低于下限
            int usedPoint = SumPoint(attrib);
            Debug.Log(usedPoint);
            if (usedPoint > 0 && SD.m_Skill.m_Points>0)
            {
                SD.m_Skill.m_Points--;
            }
        }
    }

    // 遍历同一属性的技能，返回已加点
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

    // 消耗或获得金钱
    public void GainLoseCoin(int coinNum)
    {
        m_BasicData.PlayerCoin += coinNum;
    }

    // 消耗或获得属性
    // （体力or精神力）
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

    // player某一个专精数值的变化
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