using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinpick;

   
    //check for collision
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player"){
            if(Input.GetKeyDown(KeyCode.E)){
                Player player = other.GetComponent<Player>();
                if(player != null){
                    player.hascoin = true;
                    AudioSource.PlayClipAtPoint(_coinpick,transform.position,1f);
                    UIManager uimanager = GameObject.Find("Canvas").GetComponent<UIManager>(); 
                    if(uimanager != null){
                        uimanager.CollectCoin();
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
