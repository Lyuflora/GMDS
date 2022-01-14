using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Gmds
{

public class PlayerInfoUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text ageText;
    public TMP_Text salaryText;
    void Start()
    {
        UpdatePlayerInfo();
    }
    public void UpdatePlayerInfo()
    {
        nameText.text = PlayerStatus.m_Instance.GetPlayerName();
        ageText.text = PlayerStatus.m_Instance.GetPlayerAge();
        salaryText.text = PlayerStatus.m_Instance.GetPlayerSalary();
    }
}

}