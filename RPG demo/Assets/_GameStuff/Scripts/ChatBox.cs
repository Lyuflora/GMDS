using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Gmds
{
    public class ChatBox : MonoBehaviour
    {

        public InputField chatInput;
        public TMP_Text chatText;
        public ScrollRect scrollRect;
        Animator ani;
        bool appear;
        public GameObject chatframe;
        public TMP_Text m_NPCNameText;
        private string m_PlayerName;

        public TMP_Text textbutton1;
        public TMP_Text textbutton2;
        public TMP_Text textbutton3;
        public TMP_Text textbutton4;

        public string[] m_Replys;

        // Use this for initialization
        void Start()
        {
            ani = chatframe.GetComponent<Animator>();
            chatText.text = "系统消息：你已成功添加好友好友：" + "<color=#f8bcfb>" + m_NPCNameText.text + "</color>" + "\n" + "<color=#f8bcfb>"
                + m_NPCNameText.text + "</color>" 
                + "：好久不见！真是太好了，你也选择了在南门一居住？\n这里很棒的哦，我下了船也没有感觉不适应——等你到了，要不要来我家一趟？妈咪她也很想你。" +
                "\n要是能继续一起学习就好了~ \n你打算选什么学院？\n读什么专业？\n和你父亲一样吗？";
            m_PlayerName = PlayerStatus.m_Instance.GetPlayerName();
        }
        public void RefreshProfile(NPC npc)
        {
            m_NPCNameText.text = npc.name;
            m_PlayerName = "盖姆";
        }
        public void ShowChatPopup()
        {
            appear = !appear;
            if (appear == true)
            {
                ani.SetBool("chat", true);
            }
            else
            {
                ani.SetBool("chat", false);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (chatInput.text != string.Empty)
                {
                    string addText = "<color=#8399cb>" + m_PlayerName + "</color>: " + chatInput.text;
                    chatText.text += "\n" + addText;
                    chatInput.text = string.Empty;
                    chatInput.ActivateInputField();

                }

                Canvas.ForceUpdateCanvases();       //关键代码
                scrollRect.verticalNormalizedPosition = 0f;  //关键代码
                Canvas.ForceUpdateCanvases();   //关键代码
            }


        }
        public void ChoiceBtClick(int i)
        {
            if (i >= m_Replys.Length) return;

            chatInput.text = m_Replys[i];
            chatText.text += "\n" + "<color=#8399cb>" + m_PlayerName + "</color>: " + m_Replys[i];
            chatInput.text = string.Empty;
            chatInput.ActivateInputField();
            Canvas.ForceUpdateCanvases();       //关键代码
            scrollRect.verticalNormalizedPosition = 0f;  //关键代码
            Canvas.ForceUpdateCanvases();   //关键代码

        }

        //public void Clickbutton2()
        //{
        //    if (textbutton2.text == "2")
        //    {
        //        chatInput.text = "2";
        //    }
        //    chatText.text += "\n" + "<color=red>" + m_PlayerNameText.text + "</color>: " + chatInput.text;
        //    chatInput.text = string.Empty;
        //    chatInput.ActivateInputField();
        //    Canvas.ForceUpdateCanvases();       //关键代码
        //    scrollRect.verticalNormalizedPosition = 0f;  //关键代码
        //    Canvas.ForceUpdateCanvases();   //关键代码
        //}

    }
}
