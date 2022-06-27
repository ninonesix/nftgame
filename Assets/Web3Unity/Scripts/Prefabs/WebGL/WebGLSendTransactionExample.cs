using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_WEBGL
public class WebGLSendTransactionExample : MonoBehaviour
{
    public async void OnSendTransaction()
    {
        // account to send to
        string to = "0x814220bA2E552Db82615980966220C5c3f67d3b0";
        // amount in wei to send
        string value = "10000000000000000";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
            string response = await Web3GL.SendTransaction(to, value, gasLimit, gasPrice);
            Debug.Log(response);
            hash.text = response;
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }
    
    public TextMeshProUGUI hash;

    public void Update()
    {
        if (hash.text.Contains("0"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
#endif