using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gmds
{
    public class TechItemButton : MonoBehaviour
    {
        public TMP_Text m_NameText;
        private Tech m_Tech;

        // 按下技能按钮更新文本
        public void RefreshTechInfo(int techID)
        {
            Tech tech = App.Instance.m_Manifest.m_Techs[techID];
            PanelManager.m_Instance.m_TitleText.text = tech.techname;
            PanelManager.m_Instance.m_EffectText.text = tech.effect;
            PanelManager.m_Instance.m_RequirementText.text = tech.requirement;
            PanelManager.m_Instance.m_TechImage.sprite = tech.icon;
        }
        public void SetTech(Tech rTech)
        {
            m_Tech = rTech;
            m_NameText.text = m_Tech.techname;
        }
        public void RefreshTechItem()
        {
            m_NameText.text = m_Tech.techname;
        }
    }
}