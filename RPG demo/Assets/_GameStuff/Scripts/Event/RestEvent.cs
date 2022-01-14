using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Event/Create Rest Event")]
    public class RestEvent : BaseEvent
    {
        // 无需判定
        private void Awake()
        {
            base.Awake();
            
        }

        public void Start()
        {
            m_Genre = EventGenre.Rest;

        }
        public override void HandleEvent()
        {
            base.HandleEvent();

            // 无其他效果
        }
    }
}
