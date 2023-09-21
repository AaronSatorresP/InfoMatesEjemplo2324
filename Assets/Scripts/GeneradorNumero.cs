using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumero : MonoBehaviour
{
    public GameObject _PrefabNumero;

    // Start is called before the first frame update
    void Start()
    {
        //Para invocar el objeto
        // Invoke()
        //InvokeRepeating()
        //CancelInvoke()
        InvokeRepeating("GenerarNumero",1f,3f);//cuando empiece a salir el objeto primo al segungo y luego cada 3s
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void GenerarNumero()
    {
        GameObject numero = Instantiate(_PrefabNumero);
        Vector2 costatSuperiorDret = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1f));
        Vector2 costatInferiorEsquera = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        numero.transform.position = new Vector2(
            Random.Range(costatInferiorEsquera.x, costatSuperiorDret.x), //X
            costatSuperiorDret.y    //Y
            );
        
    }
}
