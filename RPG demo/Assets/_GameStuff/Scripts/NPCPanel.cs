using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{
    public class NPCPanel : MonoBehaviour
    {
        public static NPCPanel m_Instance;

        public TMP_Text m_NameText;
        public TMP_Text m_JobText;
        public TMP_Text m_PrevText;
        public TMP_Text m_NextText;
        //public TMP_Text m_JobText;
        //public TMP_Text m_DevStage;

        [Header("Attributes Text")]
        public TMP_Text m_BodyText;
        public TMP_Text m_WillpowerText;
        public TMP_Text m_MindText;
        public TMP_Text m_KnowledgeText;
        public TMP_Text m_PracticalText;

        public Image m_Portrait;
        public int m_CurrentID = 0;
        private NPC npc;
        public GameObject techParent;

        private void Awake()
        {
            m_Instance = this;
        }

        private void Start()
        {
            if (FriendManager.m_Instance.m_FriendsArray.Count > 0)
            {
                npc = FriendManager.m_Instance.m_FriendsArray[0];
                RefreshNPCPanel(0);
            }
            else
            {
                Debug.Log("�����б��");
            }  
        }
        public void RefreshNPCPanel(int id)
        {
            NPC npc = FriendManager.m_Instance.m_FriendsArray[id];
            
            // ������Ϣ�ĸ���
            m_NameText.text = npc.NPCname;
            m_JobText.text = npc.job.ToString();
            m_Portrait.sprite = npc.img;

            m_BodyText.text = npc.status.Body.ToString();
            m_MindText.text = npc.status.Mind.ToString();
            m_WillpowerText.text = npc.status.Willpower.ToString();
            m_KnowledgeText.text = npc.status.Knowledge.ToString();
            m_PracticalText.text = npc.status.Practical.ToString();

            PanelManager.m_Instance.ClearOldChilds(techParent);
            GameObject techUI = npc.techUI;
            var newItem = Instantiate(techUI, techParent.transform.position, Quaternion.identity);
            newItem.transform.parent = techParent.transform;

            // �����л���һ��/��һ��NPC
            int total = FriendManager.m_Instance.m_FriendsArray.Count;
            // name list
            int prev = id - 1;
            int next = id + 1;

            if (prev < 0)
                prev += total;
            if (next > total-1)
                next -= total;

            m_PrevText.text = FriendManager.m_Instance.m_FriendsArray[prev].name;
            m_NextText.text = FriendManager.m_Instance.m_FriendsArray[next].name;

            // todo
            // ����2�˵����
            if (total <= 1)
            {
                // ����prev��next
            }

            for (int i = 0; i < npc.techs.Length; i++)
            {

            }

            ShowNPCTechs(npc);
        }
        public void ShowNPCTechs(NPC npc)
        {

        }

        public void PrevButtonClick()
        {
            int total = FriendManager.m_Instance.m_FriendsArray.Count;
            m_CurrentID -= 1;
            if (m_CurrentID < 0)
                m_CurrentID += total;

            RefreshNPCPanel(m_CurrentID);
        }

        public void NextButtonClick()
        {
            int total = FriendManager.m_Instance.m_FriendsArray.Count;
            m_CurrentID += 1;
            if (m_CurrentID > total-1)
                m_CurrentID -= total;

            

            RefreshNPCPanel(m_CurrentID);
        }
    }
}
