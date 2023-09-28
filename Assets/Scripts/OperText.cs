using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AfegirOp(int OpRebut)
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text += OpRebut.ToString();
    }
}
