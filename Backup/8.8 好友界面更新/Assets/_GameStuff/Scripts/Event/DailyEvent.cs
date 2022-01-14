using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds
{
    [CreateAssetMenu(menuName = "gmds/Event/Create Daily Event")]
    public class DailyEvent : BaseEvent
    {

        [Header("Fungus Block")]
        public bool Success = false;
        public string boolName;

        //protected override void Decide()
        //{
        //    base.Decide();
        //}
        public override void HandleEvent()
        {
            base.HandleEvent();

            // todo
            Debug.Log("开发完成");

        }
    }

}

