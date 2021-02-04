/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe responsável pelas interações dos extintores A e K */

public class ExtintorScript : MonoBehaviour
{
    //Objeto da classe 'ParticleSystem', possui referencia sobre as particulas visuais de um objeto
    public ParticleSystem particle;

    //Referências dos objetos que representam chamas
    public GameObject lowFire;
    public GameObject mediumFire;
    public GameObject explosion;

    //Objeto que possui referencia de SFX (Efeito sonoro)
    public AudioSource hitsound;

    //Por padrão as particulas do extintor estarão desativadas
    void onAwake()
    {
        particle.Stop();
    }

    void Start()
    {
        
    }


    void Update()
    {

    }

    //Elimina animação e particulas do extintor
    public void interrompe() {
        particle.Stop();
    }

    //Aciona animação e particulas do extintor
    public void dispara() {
        particle.Play();

    }

    //Executa SFX
    public void playSound(){
        GetComponent<AudioSource>().Play();
    }

    //Termina SFX
    public void stopSoud(){
        GetComponent<AudioSource>().Stop();
    }

    //Diminui o nível das chamas
    public void activeExplosion(){
        lowFire.SetActive(false);
        explosion.SetActive(true);
        particle.Stop();
    }

    //Aumenta o nível das chamas
    void ActivateFireExplosion()
    {
        // explosion.SetActive(false);
        mediumFire.SetActive(true);
        // this.stopSoud();
        // gameObject.SetActive(false);
    }

    //Desativa extintor
    public void retiraExtintor(){
        gameObject.SetActive(false);
    }

    //Executa SFX uma vez
    public void hitSoundPlay(){
        hitsound.Play();
    }
}
