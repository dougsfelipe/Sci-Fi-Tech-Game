using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject cratedestroyed;

    public void Destroycrate() {

        Instantiate(cratedestroyed, transform.position,transform.rotation);
        Destroy(this.gameObject);


    }
}
