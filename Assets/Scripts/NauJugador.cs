using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public float _velNau;

    // Start is called before the first frame update
    void Start()
    {
        _velNau = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log("direccioHoritzontal=" + direccioHoritzontal);
        float direccioVertical = Input.GetAxisRaw("Vertical");
        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, direccioVertical);
        Vector2 Limit = new Vector2(direccioHoritzontal,direccioVertical);
        Vector2 novaPos = transform.position; // Ens retorna la posicion actual de la nau.
        novaPos += direccioIndicada * _velNau * Time.deltaTime;
        Mathf.Clamp(novaPos.x,11,-11);
        Mathf.Clamp(novaPos.y, 5, -5);

        transform.position = novaPos;
    }
}
