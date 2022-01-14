using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds {
    public class FriendManager : MonoBehaviour
    {
        public static FriendManager m_Instance;

        public List<NPC> m_FriendsArray;

        [SerializeField] private List<NPC> m_FriendableArray;
        // ��Ŀϵͳ����
        public GameObject profileObject;
        public GameObject m_ProfileParent;
        // ��Ŀ��������
        public GameObject infoObject;
        public GameObject m_NPCInfoParent;  // ��������б�

        public Vector2 origion;

        private void Awake()
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        private void Start()
        {
            //ReloadFriendPanel(); 
            //ReloadFriendInfoList();

        }
        public void ClearOldNPCProfile()
        {
            Debug.Log("��ʼ����ɵĺ�������");
            PanelManager.m_Instance.ClearOldChilds(m_ProfileParent);
        }

        public void ClearOldNPCList()
        {
            Debug.Log("��ʼ����ɵĺ�������");
            PanelManager.m_Instance.ClearOldChilds(m_NPCInfoParent);
        }

        // ��Ŀ������
        public void ReloadFriendInfoList()
        {
            ClearOldNPCList();
            var rectTransform = infoObject.GetComponent<RectTransform>();
            float yOffset = rectTransform.sizeDelta.y;

            float origionX = m_NPCInfoParent.transform.position.x;
            float origionY = m_NPCInfoParent.transform.position.y;
            for (int i = 0; i < m_FriendsArray.Count; i++)
            {
                Debug.Log("Instantiate friend No." + i);
                var p = Instantiate(infoObject, new Vector3(origionX, origionY + yOffset * i, 0), Quaternion.identity);
                p.transform.parent = m_NPCInfoParent.transform;
                p.GetComponent<NPCProfile>().RefreshNPCProfile(m_FriendsArray[i]);
            }
        }
        public void ReloadFriendPanel()
        {
            ClearOldNPCProfile();
            var rectTransform = profileObject.GetComponent<RectTransform>();
            float yOffset = rectTransform.sizeDelta.y;

            float origionX = m_ProfileParent.transform.position.x;
            float origionY = m_ProfileParent.transform.position.y;
            for (int i = 0; i < m_FriendsArray.Count; i++)
            {
                var p = Instantiate(profileObject, m_ProfileParent.transform.position, Quaternion.identity);
                p.transform.parent = m_ProfileParent.transform;
                p.GetComponent<NPCProfile>().RefreshNPCProfile(m_FriendsArray[i]);
            }
        }
        public void ReloadNPCPanel(int friendID)
        {
            if (m_FriendsArray[friendID])
                NPCPanel.m_Instance.RefreshNPCPanel(friendID);
        }

        public void AddFriend(NPC npc)
        {
            m_FriendsArray.Add(npc);
        }

        public bool HaveFriendship(NPC npc)
        {
            var isContain = m_FriendsArray.Contains(npc);
            return isContain;
        }

        public NPC GetFriendByIndex(int i)
        {
            return m_FriendsArray[i];
        }

        public NPC GetNPCByIndex(int i)
        {
            return App.Instance.m_Manifest.m_NPCArray[i];
        }
    }
}