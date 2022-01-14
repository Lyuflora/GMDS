using System.Collections.Generic;
using UnityEngine;
namespace Gmds { 
[CreateAssetMenu(menuName = "gmds/Player/Create Attribute")]

public class Attribute : ScriptableObject
{
    // ���������������µļ��ܵ���������ϸ�ּ��ܣ�4�
    public AttributeType m_type;
    public string m_Description;
    public int m_CurrentPoint;   // ��ǰ���Ե�
    public int m_Exp;   // EXPֵ���ۻ���10��+1
    public Sprite m_Icon;

    public List<Skill> m_Skills = new List<Skill>();

}
}