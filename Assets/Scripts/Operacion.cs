using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOperacions : MonoBehaviour
{
    private float _velo;
    private int _valorOperacion;
    public Sprite[] _spritesOperaciones = new Sprite[5];
    // Start is called before the first frame update
    void Start()
    {
        _velo = 5f;
        //cargamos una imagen de numero aleatorio.
        System.Random aleatori = new System.Random();
        _valorOperacion = aleatori.Next(0, 5);//Aleatorio entre 0 y 4.
        //Acceder al componente Sprite Renderer Y dentro de este a latributo Sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = _spritesOperaciones[_valorOperacion];
    }

    // Update is called once per frame
    void Update()
    {
        //Aqui lo que hacemos es ponerle en la posicion que queremos una velocidad
        Vector2 novaPos = transform.position;
        novaPos.y = novaPos.y - _velo * Time.deltaTime;
        transform.position = novaPos;

        Destrueix();
    }
    private void Destrueix()//Aqui lo que hecemos es que cuando el objeto operacion toque con el limite se destruya
    {
        Vector2 costatInferiorEsquerra = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y <= costatInferiorEsquerra.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D objetotocado)
    {
        if (objetotocado.tag == "Bala" || objetotocado.tag == "NauJugador")
        {
            if (objetotocado.tag == "Bala")
            {
                switch (_valorOperacion) 
                { 
                    case 0:

                        break; 
                    case 1:

                        break;
                    case 2:
                        break;

                    case 3:
                        break; 

                    case 4:
                        break;

                }
                GameObject.Find("NumText").GetComponent<NumText>().AfegirOp(_valorOperacion);
            }
            Destroy(gameObject);
        }
    }
}
