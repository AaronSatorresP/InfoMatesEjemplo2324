using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOperacions : MonoBehaviour
{
    public GameObject _PrefabOperacions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerarOperacions()
    {
        GameObject operacions = Instantiate(_PrefabOperacions);
    }
}
