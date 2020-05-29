using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text ammotext;
    [SerializeField] private GameObject _coin;
    public void UpdateAmmo(int count){
        ammotext.text = "Ammo: " + count;
    }

    public void CollectCoin(){
        _coin.SetActive(true);
    }
}
