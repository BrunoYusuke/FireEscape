/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe para testes*/

public class StateManager : MonoBehaviour
{

    //Níveis da chama
    public enum States
    {
        lowFire,
        mediumFire,
        highFire
    }

    //Referências de objetos da cena
    public GameObject fireContainer;
    public GameObject smokeContainer;
    public GameObject fryingPan;

    //State atual
    public States currentState;

    //Inicialização de objetos
    void Start()
    {
        currentState = States.lowFire;

        fireContainer = GameObject.Find("Fogo");
        smokeContainer = GameObject.Find("Fumaça");
        smokeContainer = GameObject.Find("frigideira");

    }

    void Update()
    {
        
    }
}
