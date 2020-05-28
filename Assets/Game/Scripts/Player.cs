using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controler;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _gravity = 9.8f;
    // Start is called before the first frame update
    void Start()
    {
        _controler = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();

    }

    void calculateMovement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direciton = new Vector3(horizontalInput,0,verticalInput);
        Vector3 velocity = direciton * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _controler.Move(velocity * Time.deltaTime);

    }
}
