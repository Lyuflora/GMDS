using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds
{
    public class EventTypeButton : MonoBehaviour
    {
        public void SearchEventButtonClick(int genre)
        {
            // Practice = 0, Dev, Social, Rest, //BaseDev,
            EventManager.m_Instance.RefreshAvailableEvent((EventGenre)genre);
            PanelManager.m_Instance.ShowAvailableEvent((EventGenre)genre);
            PanelManager.m_Instance.SetResultTitle(genre);
        }
    }
}