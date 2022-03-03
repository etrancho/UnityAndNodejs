using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Chat : MonoBehaviour
{
    public GameObject vista;
    public static bool InChat;
    PlayerFPC playerHandler;
    public static TMP_Text userText;
    void Start()
    {
        playerHandler = GameObject.FindObjectOfType<PlayerFPC>();
        vista.SetActive(false);
        userText = gameObject.transform.Find("Canvas/Panel/UserText").gameObject.GetComponent<TMP_Text>();
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("username")))
        {
            userText.text = PlayerPrefs.GetString("username");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (InChat)
            {
                chatting();
            }
            else if (!InChat)
            {
                outOfChat();
            }
        }
    }

    public void chatting()
    {
        InChat = false;
        vista.SetActive(false);
        Time.timeScale = 1f;
    }
    public void outOfChat()
    {
        InChat = true;
        vista.SetActive(true);
        Time.timeScale = 0f;
    }
}
