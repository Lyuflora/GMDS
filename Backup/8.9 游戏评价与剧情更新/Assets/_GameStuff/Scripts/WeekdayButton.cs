using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Gmds
{ 
public class WeekdayButton : MonoBehaviour
{
    public int weekday;    // 0-6
    public Image image;
        private void Start()
        {
            image.gameObject.SetActive(false);
        }
    public void OnWeekdayButtonClick()
    {
        //SetTargetDay(weekday);

    }
    public void SetTargetDay(int weekday)
    {
        CalendarManager.m_Instance.m_CurrentScheduleDay = (CalendarManager.m_Instance.GetCurrentWeek()-1 ) * 7 + weekday;
    }
    public void SetTexture(Sprite mark)
    {
            image.gameObject.SetActive(true);
            image.sprite = mark;
    }
    public void ResetTexture()
    {
        Sprite mark = App.Instance.m_Manifest.m_WeekMarks[4];
        image.sprite = mark;
    }
}
}