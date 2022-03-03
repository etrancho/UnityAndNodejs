using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Menu : MonoBehaviour
{
	public static TMP_Text userText;
    public GameObject SettingsMenuObject;
    public static bool InSettings;
    PlayerFPC playerHandler;

    void Start()
    {
        playerHandler = GameObject.FindObjectOfType<PlayerFPC>();
        SettingsMenuObject.SetActive(false);
		userText = gameObject.transform.Find("ajustes/Canvas/Panel/UserText").gameObject.GetComponent<TMP_Text>();
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("username"))) {
			userText.text = "User: " + PlayerPrefs.GetString("username");
		}
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (InSettings)
				{
					ResumeGame();
				}
				else if(!InSettings && !Menu2.InLogin && !Menu3.InRegister)
				{
					PauseGame();
				} 
            }
    }
    public void PauseGame()
	{
		SetState(SettingsMenuObject, true);
		Time.timeScale = 0f;
		InSettings = true;
	}

	public void ResumeGame()
	{
		SetState(SettingsMenuObject, false);
		Time.timeScale = 1f;
		InSettings = false;
	}
    void SetState(GameObject g, bool state)
	{
		g.SetActive(state);
	}
	public void logOut(){
		if (!string.IsNullOrEmpty(PlayerPrefs.GetString("username"))) {
			userText.text = "User: ...";
			PlayerPrefs.DeleteKey("username");
		}
	}
	void OnApplicationQuit() {
		PlayerPrefs.DeleteKey("username");
	}
	public void closeApp(){
        Application.Quit();	
	}
}
