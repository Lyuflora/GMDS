using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds { 
[CreateAssetMenu(menuName ="gmds/Player/Create Skill")]
public class Skill : ScriptableObject
{
    public string m_Title;
    public string m_Description;
    public SkillType m_Type;
    public SkillGenre m_Genre;  // Generic or Expertise
    public Sprite m_SkillTexture;
    public int m_Points;
    public Attribute m_AffectedAttrib;

    // √ª…∂”√
    public SkillType GetSkillType()
    {
        return m_Type;
    }

    public Attribute GetAffectedAttrib()
    {
        return m_AffectedAttrib;
    }

    public void SetSkillValues(GameObject SkillDesplayObject)
    {
        if (SkillDesplayObject)
        {
            SkillDisplay SD = SkillDesplayObject.GetComponent<SkillDisplay>();
            
            if(SD.m_SkillName)
                SD.m_SkillName.text = m_Title;
            //if (SD.skillDescription)
            //    SD.skillDescription.text = description;
            if (SD.m_BtSprite)
            {
                var button = SD.GetComponent<Button>();
                button.image.sprite = m_SkillTexture;
            }
            if (SD.m_SkillPointNum)
                SD.m_SkillPointNum.text = m_Points.ToString();

        }
    }

}
}