using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerFPC : MonoBehaviour
{
    public Camera cam;
    public float speedH;
    public float speedV;
    float ejeV, ejeH;
    public float rotmax;
    public float rotMin;

    //Para controlar al jugador
    CharacterController cc;

    public float speedMov;
    public float jump;
    public float gravity;

    Vector3 mov = Vector3.zero;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!Menu.InSettings && !Menu2.InLogin && !Menu3.InRegister && !Chat.InChat)
        {
            //Para controlar la cam
            ejeH = speedH * Input.GetAxis("Mouse X");
            ejeV += speedV * Input.GetAxis("Mouse Y");

            cam.transform.localEulerAngles = new Vector3(-ejeV, 0, 0);
            transform.Rotate(0, ejeH, 0);
            ejeV = Mathf.Clamp(ejeV, rotMin, rotmax);

            //Para controlar el movimiento
            if (cc.isGrounded)
            {
                mov = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                mov = transform.TransformDirection(mov) * speedMov;

                if (Input.GetKey(KeyCode.Space))
                {
                    mov.y = jump;
                }
            }

            mov.y -= gravity * Time.deltaTime;
            cc.Move(mov * Time.deltaTime);
        }
    }
    public void sitting()
    {
        speedMov = 0;
        transform.position = new Vector3(12.5f, 3, 10.1f);
        transform.localScale = new Vector3(1, 2, 1);
    }
    public void getUp()
    {
        if (transform.localScale == new Vector3(1, 2, 1))
        {
            speedMov = 8;
            transform.position = new Vector3(12.5f, 3, 10.5f);
            transform.localScale = new Vector3(1, 4, 1);
        }

    }
}
