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
            //去掉已经是好友的NPC
        }
        public bool HaveFriendship(NPC npc)
        {
            var isContain = App.Instance.m_Manifest.m_NPCArray.Contains(npc);
            return isContain;
        }

        // 交友判定：
        // 判定成功：返回NPC序号；判定失败：返回-1
        int MakeFriends()
        {
            // Display Friends
            // Generate random integer
            // get result
            // 随机从池中抽一个好友 概率0.5
            int friendId = 0;
            int maxId = 3;
            friendId = Random.Range(0, maxId); // [0, 5) 左闭右开
            NPC npc = FriendManager.m_Instance.GetNPCByIndex(friendId);

            //// 强行去掉已经成为朋友的NPC
            //while (HaveFriendship(npc))
            //{
            //    friendId = Random.Range(0, maxId); // [0, 5)
            //    npc = FriendManager.m_Instance.GetNPCByIndex(friendId);
            //}
            
            Debug.Log("尝试结交好友" + friendId);
            // 固定概率0.5
            float success = Random.Range(-1f, 1f);
            if (success > 0)
            {
                Debug.Log("添加好友成功");
                FriendManager.m_Instance.AddFriend(npc);
                Debug.Log("与" + npc.NPCname + "成为好友");
                return friendId;
            }
            else
            {
                Debug.Log("添加失败");
                Debug.Log(npc.NPCname + "拒绝了你的好友邀请");
                return -1;
            }

        }

        public override void HandleEvent()
        {
            base.HandleEvent();
            Debug.LogFormat("去{0}", m_Type.ToString());

            // 好友收获
            int result = MakeFriends();
            if (result == -1)
            {
                Debug.Log("判定失败");
                EventManager.m_Instance.m_EventFlowchart.SetBooleanVariable("isSuccess", false);   // 设置变量
            }
            else
            {
                Debug.Log("判定成功");
                EventManager.m_Instance.m_EventFlowchart.SetBooleanVariable("isSuccess", true);   // 设置变量
            }
            Debug.Log("结交朋友结束...");
        }
    }
}