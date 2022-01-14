using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gmds
{
    public class DevEventButton : EventButton
    {
        public DevEvent m_Event;
        private void Awake()
        {
            base.Awake();
            
        }
        public void Start()
        {
            m_Text.text = m_Event.m_Title;
        }

        override public void OnEventButtonPressed()
        {
            base.OnEventButtonPressed();
            Debug.Log("添加开发事项");
        }

    }
}
