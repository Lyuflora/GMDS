using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Create MiniGame")]
    public class MiniGame : ScriptableObject
    {
        public string m_GameName;
        public string m_credit;

        public float m_Point;
        public Sprite m_Picture;
        public Sprite m_Thumbnail;

    }
}

