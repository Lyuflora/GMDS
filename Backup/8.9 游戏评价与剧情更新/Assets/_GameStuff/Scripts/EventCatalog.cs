using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds{

public class EventCatalog : MonoBehaviour
{
    public static EventCatalog m_Instance;

    public List<BaseEvent> m_GuiEventList;
    void Awake()
    {
        m_Instance = this;

        m_GuiEventList = new List<BaseEvent>(); // �ܵ��б�
    }
    // ��app��ȡ�¼�button�����ص����棬���������б����غ����¼���button
    void Reload()
    {

    }

}
}