using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor.Build.Content;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public float _velNau;
    public GameObject _PrefabExplosio;
    // Start is called before the first frame update
    void Start()
    {
        _velNau = 7f;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();

        DispararBala();
       
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        // cuando la nave toque un objeto automaticamente se llamara este metodo
        // El valor del objeto tocado sera el objeto que hemos tocado
        if (objecteTocat.tag == "Numero" || objecteTocat.tag =="Operacion") 
        {
            GameObject explosio = Instantiate(_PrefabExplosio);//hacemos que cuando la nave se destruye sale una explosio
            explosio.transform.position = transform.position;
            //Destroy(gameObject);
            GameObject.Find("GameManagerObj").GetComponent<GameManager>().SetEstatGameManager(GameManager.EstatsGameManager.GameOver);


        }
    }
    private void MovimentNau()
    {
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log("direccioHoritzontal=" + direccioHoritzontal);
        float direccioVertical = Input.GetAxisRaw("Vertical");
        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, direccioVertical).normalized;//mover la nave

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



        transform.position = novaPos;
    }
    private void DispararBala()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Dispara
            GameObject bala = Instantiate(Resources.Load("Prefabs/Bala") as GameObject);//indicamos de que tipo es el objeto
            Vector2 newPos = transform.position;
            newPos.x = newPos.x + 2f;
            bala.transform.position = this.transform.position;
        }
    }

 
}
