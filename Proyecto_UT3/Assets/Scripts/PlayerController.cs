using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float SpeedForce;
    public float JumpForce;
    public CharacterController playerController;
    public float gravityScale;

    private Vector3 moveDirection;
    private float yStore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yStore = moveDirection.y;

        // Movimieneto del personaje, lateral
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = moveDirection * SpeedForce;

        moveDirection.y = yStore;

        // Salto del personaje
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = JumpForce;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        playerController.Move(moveDirection * Time.deltaTime);

    }
}
