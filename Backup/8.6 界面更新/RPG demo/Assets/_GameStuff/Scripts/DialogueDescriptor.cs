using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds 
{
    [CreateAssetMenu(menuName = "gmds/Create Dialogue")]

    public class DialogueDescriptor : ScriptableObject
    {
        // ʱ�䣨�� �գ����Ի�flowchart
        public string m_BlockName;  // �����ĶԻ���Ӧ��block
        public Sprite m_CG;
    }
}