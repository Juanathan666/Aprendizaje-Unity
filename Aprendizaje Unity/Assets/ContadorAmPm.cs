using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorAmPm : MonoBehaviour {

    public int segundos;
    public int minutos;
    public int horas;

    public float velocidad;

    public GameObject TextoContador;
    Text Texto;
    string MostrarTiempo;

    public GameObject AmPm;
    Text TextoAmPm;

    public GameObject BotonAMPM_24;
    Text TextoAMPM_24;

    public bool AmPm_24H;
    public bool AM;
    public bool PM;


    void Awake()
    {
        velocidad = 1;

        TextoAmPm = AmPm.GetComponent<Text>();
        TextoAmPm.text = "AM";
        AmPm_24H = true;
        AM = true;
        PM = false;
        TextoAmPm.enabled = false;

        TextoAMPM_24 = BotonAMPM_24.GetComponent<Text>();
        TextoAMPM_24.text = "24H";
    }


    void Start()
    {
        Texto = TextoContador.GetComponent<Text>();
        MostrarTiempo = horas.ToString().PadLeft(2, '0') + ":" + minutos.ToString().PadLeft(2, '0') + ":" + segundos.ToString().PadLeft(2, '0');
        Texto.text = MostrarTiempo;

        StartCoroutine(Seg());
    }


    IEnumerator Seg()
    {
        //segundos++;
        minutos++;

        /* if (segundos == 60)
         {
             segundos = 0;
             minutos++;
         }*/

        if (minutos == 60)
        {
            minutos = 0;
            horas++;
        }

        if (AmPm_24H == true)
        {
            if (horas == 24)
            {
                horas = 0;
                TextoAmPm.text = "AM";
            }

            if (horas == 12)
            {
                TextoAmPm.text = "PM";
            }
        }

        else if (AmPm_24H == false)
        {
            if (horas == 12 && AM == true)
            {
                TextoAmPm.text = "PM";
                AM = false;
            }

            if (horas == 13 && AM == false)
            {
                horas = 1;
                PM = true;
            }

            if (horas == 12 && PM == true)
            {
                horas = 0;
                TextoAmPm.text = "AM";
                AM = true;
                PM = false;
            }
        }

        Texto.text = MostrarTiempo;

        yield return new WaitForSeconds(velocidad);
        Start();
    }


    public void x5()
    {
        velocidad = 0.2f;
    }


    public void x10()
    {
        velocidad = 0.1f;
    }


    public void x100()
    {
        velocidad = 0.01f;
    }

    public void AMPM_24H()
    {
        if (AmPm_24H == true)
        {
            AmPm_24H = false;
            TextoAMPM_24.text = "Am/Pm";
            TextoAmPm.enabled = true;

            if (horas > 12)
            {
                horas = horas - 12;
                TextoAmPm.text = "PM";
                PM = true;
            }
        }

        else if (AmPm_24H == false)
        {
            AmPm_24H = true;
            TextoAMPM_24.text = "24H";
            TextoAmPm.enabled = false;

            if (horas < 12 && PM == true)
            {
                horas = horas + 12;
            }
        }
    }
}
