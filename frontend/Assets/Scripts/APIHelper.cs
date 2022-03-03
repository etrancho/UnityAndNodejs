using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using System.Collections;
using TMPro;
public class APIHelper : MonoBehaviour
{
    public Regalo regalo;
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI des;
    public string url = "http://localhost:4000/regalos";
    private void Start()
    {
        StartCoroutine(GetNewRegalo());
    }
    IEnumerator GetNewRegalo()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");
        using (UnityWebRequest response = request)
        {
            yield return response.SendWebRequest();
            if (response.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Hey! Couldn't get the images: " + response.error);
            }
            else
            {
                string json = response.downloadHandler.text;
                regalo = JsonUtility.FromJson<Regalo>(json);
                nombre.text = regalo.nombreR;
                des.text = regalo.descripcionR;
            }
        }

    }

}
