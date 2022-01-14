using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{
    
    public class AttribExpSlider : MonoBehaviour
    {   
        Slider expSlider;
        public TMP_Text valText;
        [SerializeField]
        private Attribute attrib;
        public void UpdateSlider()
        {
            expSlider = GetComponent<Slider>();
            expSlider.maxValue = 10;
            while (attrib.m_Exp >= 10)
            {
                attrib.m_Exp -= 10;
                attrib.m_CurrentPoint++;
            }
            expSlider.value = attrib.m_Exp;
            valText.text = "exp " + attrib.m_Exp.ToString() + "/10";
        }
    }
}