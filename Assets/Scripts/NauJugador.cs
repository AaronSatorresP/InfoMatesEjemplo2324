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
        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, direccioVertical).normalized;
       
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();//tenemos toda la informacion del componente
        float anchura = spriteRenderer.bounds.size.x / 2;
        float Altura = spriteRenderer.bounds.size.y / 2;

        float limitEsquerraX = -Camera.main.orthographicSize * Camera.main.aspect + anchura;//el aspect se utiliza solamente para la anchura
        float limitDretaX = Camera.main.orthographicSize * Camera.main.aspect - anchura;

        float limitAbajoY = -Camera.main.orthographicSize + Altura;
        float limitArribaY = Camera.main.orthographicSize - Altura;

        Vector2 novaPos = transform.position; // Ens retorna la posicion actual de la nau.
        novaPos += direccioIndicada * _velNau * Time.deltaTime;


        //Para ponerlimites  y clamp pones el valor que quieras para poner los limites
        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);
        novaPos.y = Mathf.Clamp(novaPos.y, limitAbajoY, limitArribaY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Dispara
            shoot();
        }

        transform.position = novaPos;
    }

    private void shoot()
    {
        GameObject bala = Instantiate(Resources.Load("Prefabs/Bala") as GameObject);//indicamos de que tipo es el objeto
        bala.transform.position = this.transform.position;
    }
}
