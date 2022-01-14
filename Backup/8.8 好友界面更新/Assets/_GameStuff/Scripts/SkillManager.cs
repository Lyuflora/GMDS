using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Gmds { 
// ��ʼ������¼��PlayerPref��
// Skill points ������ȡ5�����Ե�����������������4������
public class SkillManager : MonoBehaviour
{  
    static public SkillManager m_Instance;
    
    // ��ʱʹ�õ�class�������ڳ�ʼ����
    [Serializable]
    public class attribute
    {
        public AttributeType name;
        public int points;
        public TMP_Text text;
    }
    public List<attribute> m_InitAttributes = new List<attribute>();

    private void Awake()
    {        
       // DontDestroyOnLoad(gameObject);
        m_Instance = this;
    }
    private void Start()
    {
        // ��ʼ���������Ե��ܵ�����ʾ
        LoadAttributePoints();

    }

    public void EnterGame()
    {
        // Load Next Scene
        SceneManager.LoadScene("4_Chapter1");
    }

    void LoadAttributePoints()
    {
        m_InitAttributes[0].points = PlayerPrefs.GetInt("Attribute_Body");
        m_InitAttributes[0].text.text = PlayerPrefs.GetInt("Attribute_Body").ToString();
        m_InitAttributes[1].points = PlayerPrefs.GetInt("Attribute_Willpower");
        m_InitAttributes[1].text.text = PlayerPrefs.GetInt("Attribute_Willpower").ToString();
        m_InitAttributes[2].points = PlayerPrefs.GetInt("Attribute_Mind");
        m_InitAttributes[2].text.text = PlayerPrefs.GetInt("Attribute_Mind").ToString();
        m_InitAttributes[3].points = PlayerPrefs.GetInt("Attribute_Knowledge");
        m_InitAttributes[3].text.text = PlayerPrefs.GetInt("Attribute_Knowledge").ToString();
        m_InitAttributes[4].points = PlayerPrefs.GetInt("Attribute_Practical");
        m_InitAttributes[4].text.text = PlayerPrefs.GetInt("Attribute_Practical").ToString();
    }
}
}