using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Event/Create Social Event")]
    public class SocialEvent : BaseEvent
    {
        [Header("Fungus Block")]
        public bool Success = false;
        public string boolName;
        
        private void Awake()
        {
            base.Awake();
            m_Genre = EventGenre.Social;
        }

        void UpdateFriendableNPCs()
        {
            // todo
            //ȥ���Ѿ��Ǻ��ѵ�NPC
        }
        public bool HaveFriendship(NPC npc)
        {
            var isContain = App.Instance.m_Manifest.m_NPCArray.Contains(npc);
            return isContain;
        }

        // �����ж���
        // �ж��ɹ�������NPC��ţ��ж�ʧ�ܣ�����-1
        int MakeFriends()
        {
            // Display Friends
            // Generate random integer
            // get result
            // ����ӳ��г�һ������ ����0.5
            int friendId = 0;
            int maxId = 3;
            friendId = Random.Range(0, maxId); // [0, 5) ����ҿ�
            NPC npc = FriendManager.m_Instance.GetNPCByIndex(friendId);

            //// ǿ��ȥ���Ѿ���Ϊ���ѵ�NPC
            //while (HaveFriendship(npc))
            //{
            //    friendId = Random.Range(0, maxId); // [0, 5)
            //    npc = FriendManager.m_Instance.GetNPCByIndex(friendId);
            //}
            
            Debug.Log("���Խύ����" + friendId);
            // �̶�����0.5
            float success = Random.Range(-1f, 1f);
            if (success > 0)
            {
                Debug.Log("��Ӻ��ѳɹ�");
                FriendManager.m_Instance.AddFriend(npc);
                Debug.Log("��" + npc.NPCname + "��Ϊ����");
                return friendId;
            }
            else
            {
                Debug.Log("���ʧ��");
                Debug.Log(npc.NPCname + "�ܾ�����ĺ�������");
                return -1;
            }

        }

        public override void HandleEvent()
        {
            base.HandleEvent();
            Debug.LogFormat("ȥ{0}", m_Type.ToString());

            // �����ջ�
            int result = MakeFriends();
            if (result == -1)
            {
                Debug.Log("�ж�ʧ��");
                EventManager.m_Instance.m_EventFlowchart.SetBooleanVariable("isSuccess", false);   // ���ñ���
            }
            else
            {
                Debug.Log("�ж��ɹ�");
                EventManager.m_Instance.m_EventFlowchart.SetBooleanVariable("isSuccess", true);   // ���ñ���
            }
            Debug.Log("�ύ���ѽ���...");
        }
    }
}