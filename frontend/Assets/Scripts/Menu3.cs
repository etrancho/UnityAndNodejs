using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class Menu3 : MonoBehaviour
{
    public GameObject SettingsMenuObject;
    public GameObject Login;
    public GameObject Register;
    public static bool InRegister;
    PlayerFPC playerHandler;

    public string user;
    public string pass;
    public string url = "http://localhost:4000/users/create";
    public TMP_InputField usuario;
    public TMP_InputField contraseña;
    public TMP_InputField contraseña2;
    public void active()
    {
        playerHandler = GameObject.FindObjectOfType<PlayerFPC>();
        SettingsMenuObject.SetActive(false);
        Login.SetActive(false);
        Register.SetActive(true);
        Time.timeScale = 0f;
        InRegister = true;
    }
    public void ChangeToMenu()
    {
        Register.SetActive(false);
        SettingsMenuObject.SetActive(true);
        InRegister = false;
    }
    public void ChangeToMenu2()
    {
        Register.SetActive(false);
        Login.SetActive(true);
        InRegister = false;
    }
    public void mensaje()
    {
        Debug.Log("Info usuario: " + user + pass);
        StartCoroutine(abc());
    }
    public void readUser(string s)
    {
        user = s;
        Debug.Log(user);
    }
    public void readPass(string s)
    {
        pass = s;
        Debug.Log(pass);
    }
    public IEnumerator abc()
    {
        string basicAuthUser = user + ":" + pass;
        basicAuthUser = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(basicAuthUser));
        basicAuthUser = "Basic " + basicAuthUser;

        UnityWebRequest request = UnityWebRequest.Post(url, basicAuthUser);
        request.SetRequestHeader("Authorization", basicAuthUser);

        using (UnityWebRequest createUser = request)
        {
            yield return createUser.SendWebRequest();

            if (createUser.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Encountered error: " + createUser.error);
            }
            else
            {
                string username = user;
                Menu.userText.text = "User: " + username;
                usuario.text = "";
                contraseña.text = "";
                contraseña2.text = "";
            }
        }
    }
}
