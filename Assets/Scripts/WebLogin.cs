using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

public class WebLogin : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account;

    public void OnLogin()
    {
        //IEnumerator GetRequest(string uri)
        //{
        //    using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        //    {
        //        // Request and wait for the desired page.
        //        yield return webRequest.SendWebRequest();

        //        var data = JsonUtility.FromJson<dataplayer>(webRequest.downloadHandler.text);

        //        Debug.Log(data);
        //    }
        //}
        //StartCoroutine(GetRequest("https://ar-shop-datn.herokuapp.com/api/scores"));

#if UNITY_WEBGL && !UNITY_EDITOR
        Web3Connect();
        OnConnected();
#else 
        SceneController.instance.ShowMenu();
#endif

    }

    async private void OnConnected()
    {
        account = ConnectAccount();
        while (account == "") {
            await new WaitForSeconds(1f);
            account = ConnectAccount();
        };
        // save account for next scene
        PlayerPrefs.SetString("Account", account);
        // reset login message
        SetConnectAccount("");
        // load next scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneController.instance.ShowMenu();

    }

    [Serializable]
    public class dataplayer
    {
        List<SendReward.HighScore> scores;
    }
}
