/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe responsável pelo sistema de controle de partículas de chamas*/

public class FireController : MonoBehaviour
{

    /*Objetos*/

    //Referências dos objetos que representam chamas
    public GameObject lowFire;
    public GameObject mediumFire;

    //Inicializa partículas de chama 
    private void Start()
    {
        lowFire.GetComponent<ParticleSystem>().startLifetime = 1;
        mediumFire.GetComponent<ParticleSystem>().startLifetime = 1;
    }

    //Reduz emissão de partículas
    public void reduceFire()
    {
        lowFire.GetComponent<ParticleSystem>().startLifetime -= 0.1f;
        mediumFire.GetComponent<ParticleSystem>().startLifetime -= 0.1f;
    }

    //Elimina partículas de chamas
    public void disableFire()
    {
        lowFire.SetActive(false);
        mediumFire.SetActive(false);
    }

    //Altera a cena para tela de fim de jogo
    public void winScreen()
    {
        LevelChangerScript levelChanger;
        levelChanger = FindObjectOfType<LevelChangerScript>();
        levelChanger.FadeToLevel("Screen_Win");
    }
}