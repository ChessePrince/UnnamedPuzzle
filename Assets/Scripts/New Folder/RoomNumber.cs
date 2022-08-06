using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomNumber : MonoBehaviour
{
    TextMeshProUGUI roomText;
    public static int roomNum;
    public PlayerHealth playerHealth;
    void Start()
    {
        roomText = GetComponent<TextMeshProUGUI>();
        roomNum = 1;
        NextRoom();
    }
    public void NextRoom()
    {
        roomText.text = roomNum + "/8";
    }
    public void HPtoMax()
    {
        playerHealth.GainHealth();
    }
}
