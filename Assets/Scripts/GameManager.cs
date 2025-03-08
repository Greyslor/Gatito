using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public string id;
    public int box;
    public string json;
    public GatoData data;

    public GameObject playerSelection;
    public GameObject game;
    void Start()
    {
        playerSelection.SetActive(true);
        game.SetActive(false);
    }

    IEnumerator ResetInfo()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/gato/gato.php?action=1");
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            print("Database reset");


            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetInfo()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/gato/gato.php?action=2&id="+id);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            json = www.downloadHandler.text;
            data = JsonUtility.FromJson<GatoData>(json);
            print(data);


            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator PlayerMove()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/gato/gato.php?action=3&id=" + id + "&pos=" + box);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            print(www.downloadHandler.text);


            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    public void SelectId(string idInput)
    {
        id = idInput;
        playerSelection.SetActive(false);
        game.SetActive(true);

    }

    public void PlayerMove(int boxInput)
    {
        box = boxInput;
        StartCoroutine(PlayerMove());
    }
    [ContextMenu("reset")]
    public void ResetGame()
    {
        StopAllCoroutines();
        StartCoroutine(ResetInfo());
    }

    [ContextMenu("getinfo")]
    public void GetInfoFunc()
    {
        StartCoroutine(GetInfo());
    }
}
