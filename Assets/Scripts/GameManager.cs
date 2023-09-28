using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nauJugador;
    public GameObject textGameOver;
    public GameObject titulJoc;
    public GameObject bottoInici;
    public GameObject generadornumeros;
    public GameObject generadoroperacions;
    public enum EstatsGameManager
    {
        Inici,
        Jugant,
        GameOver
    }
    
    private EstatsGameManager _estatsGameManager;
    // Start is called before the first frame update
    void Start()
    {
        _estatsGameManager = EstatsGameManager.Inici; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualizaEstatGameManager()
    {
        switch (_estatsGameManager) 
        {
         case EstatsGameManager.Inici:
                nauJugador.SetActive(false);
                textGameOver.SetActive(false);
                titulJoc.SetActive(true);
                bottoInici.SetActive(true);
                
                


                break;
         case EstatsGameManager.Jugant:
                nauJugador.SetActive(true);
                textGameOver.SetActive(false);
                titulJoc.SetActive(false);
                bottoInici.SetActive(false);
                generadornumeros.GetComponent<GeneradorNumero>().IniciaGeneracioNums();
                generadoroperacions.GetComponent<GeneradorOperacion>().IniciaGeneracioOps();
                break;
         case EstatsGameManager.GameOver:
                nauJugador.SetActive(false);
                textGameOver.SetActive(true);
                titulJoc.SetActive(false);
                bottoInici.SetActive(false);
                generadornumeros.GetComponent<GeneradorNumero>().AturaGeneracioNums();
                generadoroperacions.GetComponent<GeneradorOperacion>().AturaGeneracioOps();


                break;

        }
    }

    public void SetEstatGameManager(EstatsGameManager estat)
    {
        _estatsGameManager = estat;
        ActualizaEstatGameManager();
    }
    public void PassarAEstatJugant()
    {
        _estatsGameManager = EstatsGameManager.Jugant;
        ActualizaEstatGameManager();
    }

}
