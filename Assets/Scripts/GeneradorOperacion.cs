using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOperacion : MonoBehaviour
{
    public GameObject _PrefabOperacions;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarOperacion", 1f, 3f);//Nos gerena el primer objeto 1s y luego saldra cada 3s
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerarOperacion()
    {
        GameObject numero = Instantiate(_PrefabOperacions);
        Vector2 costatSuperiorDret = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1f));
        Vector2 costatInferiorEsquera = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        numero.transform.position = new Vector2(
            Random.Range(costatInferiorEsquera.x, costatSuperiorDret.x), //X
            costatSuperiorDret.y    //Y
            );
    }
}

