using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocity = 5f;
    void Start()
    {
        
    }

  
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y += Velocity * Time.deltaTime;
        transform.position = novaPos;

        //Lo que hace este codigo es cuando la bala llegue al limite se borre directamente
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();//tenemos toda la informacion del componente
        float Altura = spriteRenderer.bounds.size.y / 2;
        float limitArribaY = Camera.main.orthographicSize;
        transform.position = novaPos;
        if (novaPos.y >= limitArribaY) {
            Destroy(gameObject);
        }
   
    }
}
