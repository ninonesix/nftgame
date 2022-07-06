using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC1155BalanceOfExample : MonoBehaviour
{
    //public GameObject flappy;
    async public void CheckNFT()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0xF92F1D9dB56b9d2De197Ec0B1B1Ed673421a8c4d";
        string account = PlayerPrefs.GetString("Account");
        string tokenId = "1";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(balanceOf);

        if (balanceOf > 0)
        {
            //flappy.SetActive(true);
        }
    }
}
