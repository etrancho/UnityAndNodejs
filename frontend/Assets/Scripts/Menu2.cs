using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class Menu2 : MonoBehaviour
{
    public GameObject SettingsMenuObject;
    public GameObject Login;
    public static bool InLogin;
    PlayerFPC playerHandler;
    public string user;
    public string pass;
    public string url = "http://localhost:4000/users/signin";
    public TMP_InputField usuario;
    public TMP_InputField contraseña;
    public void active()
    {
        playerHandler = GameObject.FindObjectOfType<PlayerFPC>();
        SettingsMenuObject.SetActive(false);
        Login.SetActive(true);
        Time.timeScale = 0f;
        InLogin = true;
    }
    public void ChangeToMenu()
    {
        Login.SetActive(false);
        SettingsMenuObject.SetActive(true);
        InLogin = false;
    }
    public void mensaje()
    {
        StartCoroutine(abc());

    }
    public void readUser(string s)
    {
        user = s;
    }
    public void readPass(string s)
    {
        pass = s;
    }
    public IEnumerator abc()
    {
        string basicAuthUser = user + ":" + pass;
        basicAuthUser = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(basicAuthUser));
        basicAuthUser = "Basic " + basicAuthUser;

        UnityWebRequest request = UnityWebRequest.Post(url, basicAuthUser);
        request.SetRequestHeader("Authorization", basicAuthUser);

        using (UnityWebRequest loginUser = request)
        {
            yield return loginUser.SendWebRequest();

            if (loginUser.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Encountered error: " + loginUser.error);
            }
            else
            {
                string username = user;
                Menu.userText.text = "User: " + username;
                usuario.text = "";
                contraseña.text = "";
                PlayerPrefs.SetString("username", username);
                
            }
        }
    }
}
