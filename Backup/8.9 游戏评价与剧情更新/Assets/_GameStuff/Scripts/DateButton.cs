using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateButton : MonoBehaviour
{
    public Image image;
    int day;
    int month;
    private void Start()
    {
        image.gameObject.SetActive(false);
    }
    public void SetTexture(Sprite mark)
    {
        image.gameObject.SetActive(true);
        image.sprite = mark;
    }

    // todo
    // Reset mark
}
