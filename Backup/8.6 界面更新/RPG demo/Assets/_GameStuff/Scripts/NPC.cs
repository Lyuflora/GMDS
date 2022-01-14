using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Player/Create NPC")]
    public class NPC : ScriptableObject
    {
        public string NPCname;
        public int age;
        public Sprite img;
        public Sprite portrait;
        public string description;
        public NPCJob job;
        public int level;   //  ����ȼ�
        public DevStage stage;  // �����׶�

        public NpcAttribute status;

        public Tech[] techs;

        [Header("Dialog")]
        public string[] dialogs;

        [Header("Techs Item")]
        public GameObject techUI;
    }
}