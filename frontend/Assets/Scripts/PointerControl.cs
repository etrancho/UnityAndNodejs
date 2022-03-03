using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;

public class PointerControl : MonoBehaviour
{
    public Camera PlayerCamera;
    public float RayLength;
    string currentObject;

    void Start()
    {
        currentObject = "";
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Menu.InSettings && !Menu2.InLogin && !Menu3.InRegister && !Chat.InChat)
        {
            CurrentObjectHandler();
            Cursor.lockState = CursorLockMode.Locked;
        } else if (Input.GetMouseButtonDown(0)){
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void CurrentObjectHandler()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, RayLength))
        {
            currentObject = hit.transform.name;
        }
        

        switch (currentObject)
        {
            case "buttonCountryRoad":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonCountryRoadExit";
                break;
            case "buttonContests":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonContestsExit";
                break;
            case "buttonCountryBack":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonCountryBackExit";
                break;
            case "buttonContestsBack":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonContestsExit";
                break;
            case "buttonSitting":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonSittingExit";
                break;
            case "buttonGetUp":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonGetUpExit";
                break;
            case "buttonPP":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonPPExit";
                break;
            case "buttonStop":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonStopExit";
                break;
            case "buttonVideo1":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonVideo1Exit";
                break;
            case "buttonVideo2":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonVideo2Exit";
                break;
            case "buttonVideo3":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonVideo3Exit";
                break;
            case "buttonReport":
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                currentObject = "buttonReportExit";
                break;
        }
        
    }

    public string GetCurrentObject()
    {
        return currentObject;
    }

    public void SetCurrentObject(string str)
    {
        this.currentObject = str;
    }
}
