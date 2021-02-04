/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe responsável pelas interações da 'caneca' */

public class WaterCup : MonoBehaviour
{

    /*Objetos*/

    //Referência do objeto que representa água (filho do obj 'caneca')
    public GameObject water;

    //Referências dos objetos que representam chamas
    public GameObject lowFire;
    public GameObject mediumFire;
    public GameObject explosion;

    //Objeto que possui referencia de SFX (Efeito sonoro)
    public AudioSource hitSound;

    //Torna ativo os atributos do objeto 'agua'
    void ActivateWater()
    {
        water.SetActive(true);
    }

    //Aumenta bastante o nível das chamas
    void ActivateExplosion()
    {
        lowFire.SetActive(false);
        explosion.SetActive(true);
        hitSound.PlayDelayed(0.5f);
    }

    //Aumenta o nível das chamas
    void ActivateFire()
    {
        explosion.SetActive(false);
        mediumFire.SetActive(true);
        gameObject.SetActive(false);
        
    }
}
