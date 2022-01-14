using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gmds
{
    public class EventGrid : MonoBehaviour  // 排布事件按钮
    {
        static public EventGrid m_Instance;
        public List<GameObject> m_AvailableEventBts;    // 加载显示的事件按钮
        public List<BaseEvent> m_AvailableEvents;    // 加载显示的事件按钮
        public GameObject CalenderParent;   //   事件按钮的parent

        public GameObject m_EventButtonPrac;
        public GameObject m_EventButtonDev;
        public GameObject m_EventButtonSocial;
        public GameObject m_EventButtonRest;

        public GameObject m_DevEvParent;
        public GameObject m_PracEvParent;
        public GameObject m_SocialEvParent;
        public GameObject m_RestEvParent;

        public List<GameObject> m_EventButtonList;
        public List<GameObject> m_DevEventButtonList;
        public List<GameObject> m_PracticeEventButtonList;
        public List<GameObject> m_SocialEventButtonList;
        public List<GameObject> m_RestEventButtonList;

        public List<GameObject> m_ResultEventButtonList;

        public void ReloadCalender()
        {
            CalenderParent = this.gameObject;

            //m_DevEvParent = GameObject.Find("Canvas/Calendar/Schedule/Devs");
            //m_PracEvParent = GameObject.Find("Canvas/Calendar/Schedule/Practices");
            //m_SocialEvParent = GameObject.Find("Canvas/Calendar/Schedule/Socials");
            //m_RestEvParent = GameObject.Find("Canvas/Calendar/Schedule/Rest");
        }

        private void Awake()
        {
            m_Instance = this;
            DontDestroyOnLoad(this);
            ReloadCalender();
        }

        private void Start()
        {
            
        }


        public void LoadEventButtonArray(EventGenre searchGenre)
        {

            switch (searchGenre)
            {
                case EventGenre.Practice:
                    var pracEvents = App.Instance.m_Manifest.m_PracticeEvents;
                    for (int i = 0; i < pracEvents.Length; i++)
                    {
                        var newItem = Instantiate(m_EventButtonPrac, new Vector3(0, 0, 0), Quaternion.identity);
                        newItem.GetComponent<PracticeEventButton>().SetButtonProperties(pracEvents[i]);
                        newItem.GetComponent<PracticeEventButton>().m_Event = pracEvents[i];

                        if (m_PracEvParent.transform)
                        {
                            newItem.transform.parent = m_PracEvParent.transform;
                        }
                    }
                    break;
                case EventGenre.Dev:
                    var devEvents = App.Instance.m_Manifest.m_DevEvents;
                    for (int i = 0; i < devEvents.Length; i++)
                    {
                        var newItem = Instantiate(m_EventButtonDev, new Vector3(0, 0, 0), Quaternion.identity);
                        newItem.GetComponent<DevEventButton>().SetButtonProperties(devEvents[i]);
                        newItem.GetComponent<DevEventButton>().m_Event = devEvents[i];
                        if (m_DevEvParent.transform)
                        {
                            newItem.transform.parent = m_DevEvParent.transform;
                        }
                    }
                    break;
                case EventGenre.Social:
                    var socialEvents = App.Instance.m_Manifest.m_SocialEvents;
                    for (int i = 0; i < socialEvents.Length; i++)
                    {
                        var newItem = Instantiate(m_EventButtonSocial, new Vector3(0, 0, 0), Quaternion.identity);
                        newItem.GetComponent<SocialEventButton>().SetButtonProperties(socialEvents[i]);
                        newItem.GetComponent<SocialEventButton>().m_Event = socialEvents[i];

                        if (m_SocialEvParent.transform)
                        {
                            newItem.transform.parent = m_SocialEvParent.transform;
                        }
                    }
                    break;
                case EventGenre.Rest:
                    var restEvents = App.Instance.m_Manifest.m_RestEvents;
                    for (int i = 0; i < restEvents.Length; i++)
                    {
                        var newItem = Instantiate(m_EventButtonRest, new Vector3(0, 0, 0), Quaternion.identity);
                        newItem.GetComponent<RestEventButton>().SetButtonProperties(restEvents[i]);
                        newItem.GetComponent<RestEventButton>().m_Event = restEvents[i];

                        if (m_RestEvParent.transform)
                        {
                            newItem.transform.parent = m_RestEvParent.transform;
                        }
                    }
                    break;
            }
}

        // todo
        public void ReloadEventButton(EventGenre searchGenre)
        {
            PanelManager.m_Instance.ClearOldChilds(m_DevEvParent);    
            PanelManager.m_Instance.ClearOldChilds(m_PracEvParent);    
            PanelManager.m_Instance.ClearOldChilds(m_SocialEvParent);    
            PanelManager.m_Instance.ClearOldChilds(m_RestEvParent);    

            //// 初始化时默认显示练习项目
            //for(int i = 0; i < 3; i++)
            //{
                
            //    int prac_id = PracticeManager.m_Instance.m_WeekPractice[i];
            //    Debug.Log("显示练习" + prac_id);
            //    GameObject pracBt = m_PracticeEventButtonList[prac_id];
            //    var newItem = Instantiate(pracBt, m_ResultEventButtonList[i].gameObject.transform.position, Quaternion.identity);
            //    newItem.transform.parent = m_PracEvParent.transform;
            //}

            float x = CalenderParent.transform.position.x;
            float y = CalenderParent.transform.position.y;
            float Xanchor = 60f;
            float Yoffset = 40f;


            LoadEventButtonArray(searchGenre);

            // load event array
            /*
            for (int i = 0; i < m_AvailableEvents.Count; i++)
                //for (int i = 0; i < m_AvailableEventBts.Count; i++)
            {
                //var newItem = Instantiate(m_AvailableEventBts[i], new Vector3(x + Xanchor, y - Yoffset * (i - 1), 0), Quaternion.identity);
                var newItem = Instantiate(m_EventButton, new Vector3(x + Xanchor, y - Yoffset * (i - 1), 0), Quaternion.identity);
                  
                //var genre = newItem.GetComponent<EventButton>().m_Genre;
                var genre = m_AvailableEvents[i].m_Genre;

                Transform itemParent = CalenderParent.transform;

                if (genre != searchGenre) continue;
                if (genre == EventGenre.Dev)
                {
                    itemParent = m_DevEvParent.transform;
                    // 
                    newItem.AddComponent<DevEventButton>();
                    newItem.GetComponent<DevEventButton>().SetButtonProperties(m_AvailableEvents[i]);
                }
                else if(genre == EventGenre.BaseDev)
                {
                    itemParent = m_DevEvParent.transform;
                }
                else if (genre == EventGenre.Practice)
                {
                    itemParent = m_PracEvParent.transform;
                    newItem.AddComponent<PracticeEventButton>();
                    newItem.GetComponent<PracticeEventButton>().SetButtonProperties(m_AvailableEvents[i]);
                }
                else if (genre == EventGenre.Social)
                {
                    itemParent = m_SocialEvParent.transform;
                }
                else if (genre == EventGenre.Rest)
                {
                    itemParent = m_RestEvParent.transform;
                }
                else
                {
                    continue;
                }

                if (itemParent)
                {
                    newItem.transform.parent = itemParent;
                }
                //newItem.transform.position = new Vector3(x + Xanchor + itemParent.transform.position.x, y - Yoffset * (i - 1), 0);
            }
            */

        }

        void RefreshButtonProperties()
        {
            //for (int i = 0; i < m_EventButtons.Length; i++)
            //{

            //int numBrushesInBrushList = EventCatalog.m_Instance.m_GuiEventList.Count;
            // int iEventIndex = i;
            //if (iEventIndex < numBrushesInBrushList)
            //{
            //if (!m_EventButtons[i].IsHover())
            //{
            //BaseEvent rEvent = EventCatalog.m_Instance.m_GuiEventList[iEventIndex];
            //m_EventButtons[i].SetButtonProperties(rEvent);
            //m_EventButtons[i].SetButtonSelected(rBrush == BrushController.m_Instance.ActiveBrush);
            //m_EventButtons[i].gameObject.SetActive(true);
            //}
            //}

            //}
        }
    }
}