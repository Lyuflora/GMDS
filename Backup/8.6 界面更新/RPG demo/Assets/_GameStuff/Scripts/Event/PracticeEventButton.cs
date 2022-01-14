using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gmds
{
    public class PracticeEventButton : EventButton
    {
        public PracticeEvent m_Event;
        private void Awake()
        {
            base.Awake();
            
        }
        public void Start()
        {
            m_Text.text = m_Event.name;
        }
        override public void OnEventButtonPressed()
        {
            base.OnEventButtonPressed();
            Debug.Log("�����ϰ����");
        }
    }
}
