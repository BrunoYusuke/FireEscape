/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe responsável pelas interações do 'bicarbonato_sodio' */

public class SodaBox : MonoBehaviour
{

    /*Objetos*/

    //Referência do objeto 'bicarbonato_sodio'
    public GameObject soda;

    //Referências dos objetos que representam chamas
    public GameObject lowFire;
    public GameObject mediumFire;
    public GameObject explosion;

    //Torna ativo os atributos do objeto 'bicarbonato_sodio'
    void ActivatePowder()
    {
        soda.SetActive(true);
    }

    //Diminui o nível das chamas
    void DeactivateFire()
    {
        explosion.SetActive(false);
        mediumFire.SetActive(false);
        lowFire.SetActive(false);
        gameObject.SetActive(false);
    }
}
