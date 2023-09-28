using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumero : MonoBehaviour
{
    public GameObject _PrefabNumero;

    public void IniciaGeneracioNums()
    {
        InvokeRepeating("GenerarNumero", 1f, 1f);//cuando empiece a salir el objeto primo al segungo y luego cada 3s
    }
    public void AturaGeneracioNums()
    {
        CancelInvoke("GenerarNumero");
    }
    // Start is called before the first frame update
    void Start()
    {
        //Para invocar el objeto
        // Invoke()
        //InvokeRepeating()
        //CancelInvoke()
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void GenerarNumero()
    {
        GameObject numero = Instantiate(_PrefabNumero);
        Vector2 costatSuperiorDret = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        Vector2 costatInferiorEsquera = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        numero.transform.position = new Vector2(
            Random.Range(costatInferiorEsquera.x, costatSuperiorDret.x), //X
            costatSuperiorDret.y    //Y
            );
        
    }
}
