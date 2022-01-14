using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{
    public class PanelManager : MonoBehaviour
    {
        public static PanelManager m_Instance;

        public GameObject m_PopupPanel;
        public GameObject m_AttribPanel;
        public GameObject m_AttribContainer;
        public GameObject m_FriendsPanel;
        public GameObject m_TechsPanel;
        public GameObject m_ProjPanel;
        public GameObject m_ProjInfoPanel;


        [Header("Calendar")]
        public GameObject m_ResultWindow;
        public TMP_Text m_ResultWindowTitle;

        [Header("Techs Panel")]
        public TMP_Text m_TitleText;
        public TMP_Text m_EffectText;
        public TMP_Text m_RequirementText;
        public Image m_TechImage;

        private int m_CurrentDisplayedFriend;

        private void Awake()
        {
            m_Instance = this;
            // 关闭好友界面显示
            Animator animator = m_FriendsPanel.GetComponent<Animator>();
            animator.SetBool("isOpen", false);
        }
        private void Start()
        {
            m_CurrentDisplayedFriend = 0;
        }
        public void RefreshPopup(GameObject Panel, BaseEvent rEvent)
        {
            string popupText = string.Format("Coin: {0:D}\nStrength: {1:D}\nMental: {2:D}\nStrengthExp: {3:D}\nMentalExp: {4:D}", rEvent.dCoin, rEvent.dStrength, rEvent.dMental, rEvent.dStrengthExp, rEvent.dMentalExp);
            m_PopupPanel.GetComponentInChildren<TMP_Text>().text = popupText;
        }
        public void TriggerPanelAnim(GameObject Panel, string varName)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if (animator)
            {
                bool isOpen = animator.GetBool(varName);
                animator.SetBool(varName, !isOpen);
            }
        }
        public void OpenPanel(GameObject Panel)
        {
            //TriggerPanelAnim(Panel, "isOpen");
            Animator animator = Panel.GetComponent<Animator>();
            if (animator)
            {
                bool isOpen = animator.GetBool("isOpen");
                animator.SetBool("isOpen", !isOpen);
            }
        }
        public void ClosePanel(GameObject Panel)
        {
            //TriggerPanelAnim(Panel, "isOpen");
            Animator animator = Panel.GetComponent<Animator>();
            if (animator)
            {
                bool isOpen = animator.GetBool("isOpen");
                animator.SetBool("isOpen", false);
            }
        }

        public void OpenProjInfoPanel()
        {            
            FriendManager.m_Instance.ReloadFriendInfoList();
            GameStatus.m_Instance.UpdateProjInfo();
            
            OpenPanel(PanelManager.m_Instance.m_ProjInfoPanel);
        }

        public void OpenFriendsPanel()
        {
            
            FriendManager.m_Instance.ReloadNPCPanel(m_CurrentDisplayedFriend);
            OpenPanel(PanelManager.m_Instance.m_FriendsPanel);
        }
        public void OpenPopupPanel()
        {
            OpenPanel(PanelManager.m_Instance.m_PopupPanel);
        }

        public void OpenAttribPanel()
        {
            AttribManager.m_Instance.RefreshAttribPanel();
            OpenPanel(PanelManager.m_Instance.m_AttribPanel);
        }

        public void CloseAllPanel()
        {
            ClosePanel(m_AttribPanel);
            ClosePanel(m_PopupPanel);
        }

        public void AttribPanelSlideDown(GameObject Panel)
        {
            TriggerPanelAnim(Panel, "isDown");
        }
        public void AttribPanelSlideUp(GameObject Panel)
        {
            TriggerPanelAnim(Panel, "isUp");
        }

        public void OpenProjPanel()
        {
            FriendManager.m_Instance.ReloadFriendPanel();
            GameStatus.m_Instance.UpdateProjRatings();
            OpenPanel(PanelManager.m_Instance.m_ProjPanel);
        }
        public void OpenTechPanel()
        {
            PracticeManager.m_Instance.ReloadTechPanel();
            // for debug
            Debug.Log(App.Instance.m_Manifest.m_Techs.Length);

            OpenPanel(PanelManager.m_Instance.m_TechsPanel);
        }



        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                OpenFriendsPanel();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                OpenPopupPanel();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                OpenProjPanel();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                OpenTechPanel();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                OpenProjInfoPanel();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                OpenAttribPanel();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                AttribPanelSlideDown(PanelManager.m_Instance.m_AttribContainer);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                AttribPanelSlideUp(PanelManager.m_Instance.m_AttribContainer);
            }
        }
        public void ClearOldChilds(GameObject parent)
        {
            int evCount = parent.transform.childCount;
            List<GameObject> childList = new List<GameObject>();
            for (int i = 0; i < evCount; i++)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                childList.Add(child);
            }
            for (int i = 0; i < childList.Count; i++)
            {
                Destroy(childList[i]);
            }
        }

        // todo
        public void ShowAvailableEvent(EventGenre genre)
        {
            m_ResultWindow.SetActive(true);
            EventGrid.m_Instance.ReloadEventButton(genre);
        }

        public void SetResultTitle(int genre)
        {
            m_ResultWindowTitle.text = App.Instance.m_Manifest.m_WindowTitles[genre];
        }
    }
}