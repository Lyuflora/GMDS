using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gmds
{

    // Character Creator�� 5�����Ե������䣬��������PlayerPref��
    public class AttribManager : MonoBehaviour
    {

        [Serializable]
        public struct Attribute
        {
            // ���������������µļ��ܵ���
            // ��Ϊ����Debug
            public string name;
            public int points;
        }
        public Attribute[] m_Attribs;

        static public AttribManager m_Instance;

        [SerializeField]
        private int m_TotalPoints = 15;  // ��ʼ�ܵ�����15
        [SerializeField]
        private int m_UsedPoints = 0;
        private int m_RemainedPoints = 15;

        public TMP_Text m_RemainedPointsText;
        public TMP_Text[] m_AttribPointsText;

        public AttribExpSlider[] attribSliders; //size��˳�� ��������ͬ


        private void Awake()
        {
            m_Instance = this;
        }
        private void Start()
        {
            // initialize skills for each attribute
            // InitializeAttribs();
        }

        void InitializeAttribs()
        {
            Debug.Log(m_Attribs.Length);
            for (int i = 0; i < m_Attribs.Length; i++)
            {
                m_Attribs[i].points = 0;
                
            }
        }

        // ���µ�����ʾ
        void UpdatePointsDisplay()
        {
            if(m_RemainedPointsText)
                m_RemainedPointsText.text = m_RemainedPoints.ToString();

            for (int i = 0; i < m_AttribPointsText.Length; i++)
            {
                //m_AttribPointsText[i].text = m_Attribs[i].points.ToString();
                m_AttribPointsText[i].text = PlayerStatus.m_Instance.m_Attributes[i].m_CurrentPoint.ToString();
                //var AttribObj = PlayerStatus.m_Instance.m_Attributes[i];
                //for (int j = 0; j < AttribObj.m_Skills.Count; j++)
                //{

                //}
            }
        }

        public void RefreshAttribPanel()
        {
            for(int i=0;i< m_Attribs.Length; i++)
            {
                m_Attribs[i].points = PlayerStatus.m_Instance.m_Attributes[i].m_CurrentPoint;
                attribSliders[i].UpdateSlider();
            }
            UpdatePointsDisplay();
        }

        public void OnPointsIncreaseButtonClick(int attribID)
        {
            if (m_UsedPoints >= m_TotalPoints || m_Attribs[attribID].points >= m_TotalPoints)
            {
                // ��ִ��
                return;
            }
            // Debug.Log(attribID);
            m_Attribs[attribID].points++;
            m_UsedPoints++;
            m_RemainedPoints--;
            UpdatePointsDisplay();
        }

        public void OnPointsDecreaseButtonClick(int attribID)
        {
            if (m_UsedPoints <= 0 || m_Attribs[attribID].points <= 0)
            {
                // ��ִ��
                return;
            }
            // Debug.Log(attribID);
            m_Attribs[attribID].points--;
            m_UsedPoints--;
            m_RemainedPoints++;
            UpdatePointsDisplay();
        }

    }
}