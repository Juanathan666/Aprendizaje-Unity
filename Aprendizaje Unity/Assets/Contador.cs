using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour {

    public GameObject contador;

    public int segundos;
    public int minutos;
    public int horas;
    public string turnohorario = "AM";
    public int rango_de_velocidad = 0;
    public bool iniciado = false;
    Text contadort;
    void Start() {
        contadort = contador.GetComponent<Text>();
        InvokeRepeating("contar", 0, 1F);
    }

    void contar()
    {

        //Llama a la funcion que cambia de am a pm y viceversa
        segundos++;
        iniciar();

        if (segundos >= 60)
        {

            minutos++;
            segundos = 0;

        }

        if (minutos >= 60)
        {
            horas++;
            minutos = 0;
        }
    }



    public void iniciar()
    {
        if (iniciado == false)
        {
            am();
        }
        else if (iniciado == true)
        {
            pm();
        }

    }

    public void am()
    {
        if (horas == 12 && turnohorario == "AM")
        {

            turnohorario = "PM";

        }

        if (horas == 13 && turnohorario == "PM")
        {

            horas = 1;
            iniciado = true;
        }

    }

    public void pm()
    {

        if (horas == 12 && turnohorario == "PM")
        {

            turnohorario = "AM";
        }

        if (horas == 12 && turnohorario == "AM")
        {
            horas = 0;
            iniciado = false;
        }
    }

    void Update () {

        contadort.text = horas.ToString().PadLeft(2, '0') + ":" + minutos.ToString().PadLeft(2, '0') + ":" + segundos.ToString().PadLeft(2, '0') + " " + turnohorario;
       
    }

}