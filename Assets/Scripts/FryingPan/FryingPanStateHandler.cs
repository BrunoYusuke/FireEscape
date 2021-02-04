/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe utilizada para testagem dos níveis das chamas*/

public class FryingPanStateHandler : MonoBehaviour
{
    //Estados das chamas
    enum States
    {
        lowFire = 1,
        mediumFire = 2,
        lidPlaced = 3,
        extinguished = 4,
        exploded = 5
    }

    //Objeto que representa um State
    States states;

    //Referencia da classe 'FryingPanInteraction'
    public FryingPanInteraction lowFireState;

    //Carrega atributos do objeto 'frigideira'
    private void Start()
    {
        lowFireState = gameObject.GetComponent<FryingPanInteraction>();
    }

    //Maquina de estados da chama
    void Update()
    {
        switch(states)
        {
            case States.lowFire:
                lowFireState.enabled = true;
                break;
            case States.mediumFire:
                break;
            case States.lidPlaced:
                break;
            case States.extinguished:
                break;
            case States.exploded:
                break;
        }

    }
}
