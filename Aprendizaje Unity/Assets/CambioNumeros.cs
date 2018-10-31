using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioNumeros : MonoBehaviour {

    public GameObject Numero;

    Text Texto;

    int Num;

    void Start ()
    {
        Num = 1;

        Texto = Numero.GetComponent<Text>();
    }

    public void Sumar ()
    {
        if (Num > -1 && Num < 100)
        {
            Num ++;
            Texto.text = Num + "";
        }
    }

    public void Restar ()
    {
        if (Num > 0 && Num < 101)
        {
            Num--;
            Texto.text = "" + Num;
        }
    }
}
