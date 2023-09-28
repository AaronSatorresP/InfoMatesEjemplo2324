using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{
    private float _vel;
    private int _valorNumero;
    public Sprite[] _spritesNumeros = new Sprite[10];
    // Start is called before the first frame update
    void Start()
    {
        _vel = 2f;

        //cargamos una imagen de numero aleatorio.
        System.Random aleatori = new System.Random();
        _valorNumero = aleatori.Next(0,10);//Aleatorio entre 0 y 9.
        //Acceder al componente Sprite Renderer Y dentro de este a latributo Sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = _spritesNumeros[_valorNumero];
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos= transform.position;
        novaPos.y = novaPos.y - _vel * Time.deltaTime;
        //Debug.Log(Time.deltaTime);
        transform.position = novaPos;

        DestrueixSiSurtFora();


    }
    private void OnTriggerEnter2D(Collider2D objetotocado)
    {
        if(objetotocado.tag == "Bala" || objetotocado.tag == "NauJugador")
        {
            Destroy(gameObject);
        }
    }

    private void DestrueixSiSurtFora()
    {
        Vector2 costatInferiorEsquerra = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        if(transform.position.y <= costatInferiorEsquerra.y)
        {
            Destroy(gameObject);
        }
    }
}
