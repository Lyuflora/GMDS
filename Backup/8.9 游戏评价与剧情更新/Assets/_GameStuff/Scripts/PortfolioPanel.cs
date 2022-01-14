using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds {
    public class PortfolioPanel : MonoBehaviour
    {
        static public PortfolioPanel m_Instance;
        public int m_CurrentItemId;
        public List<MiniGame> m_Games;

        [Header("UI")]
        public Image m_Screen;
        public TMP_Text m_GameName;
        public TMP_Text m_Credit;
        public TMP_Text m_Points;

        public GameObject m_ThumbnailsParent;

        private void Awake()
        {
            m_Instance = this;
        }
        private void Start()
        {
            m_CurrentItemId = 0;
            for(int i = 0; i < m_Games.Count; i++)
            {
                m_ThumbnailsParent.gameObject.transform.GetChild(i).Find("ItemReview").GetComponent<Image>().sprite = m_Games[i].m_Thumbnail;
            }

        }

        public void SetDisplayItem(int id)
        {
            m_CurrentItemId = id;
            RefreshPortfolioPanel();
        }

        public void RefreshPortfolioPanel()
        {
            int id = m_CurrentItemId;
            if (id >= m_Games.Count) return;

            var game = m_Games[id];

            // Show the No.id element in games list
            // Show Image
            m_Screen.sprite = game.m_Picture;
            
            // Update text
            m_GameName.text = game.m_GameName;
            m_Credit.text = game.m_credit;
            m_Points.text = game.m_Point.ToString()+"   /10";

        }
    }
}