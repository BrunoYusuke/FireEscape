/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe responsável pelo posicionamento aleatório de objetos*/

public class ObjectSpawn : MonoBehaviour
{
    /*Objetos*/

    //tag1 e tag2 possuem referência dos objetos com etiqueta 'tag1' e 'tag2'
    public GameObject[] tag1;
    public GameObject[] tag2;

    //rng guarda um número aleatório entre 1 e 3
    private int rng;

    //Função inicializada uma única vez
    //A partir do inteiro 'rng', apenas um grupo de objetos será carregado na cena.
    public void StartObject()
    {
        rng = Random.Range(1, 3);
        print(rng);

        tag1 = GameObject.FindGameObjectsWithTag("Tag1");
        tag2 = GameObject.FindGameObjectsWithTag("Tag2");  

        if (rng == 1)
        {
            foreach (GameObject obj in tag1)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in tag2)
            {
                obj.SetActive(false);
            }
        }
    }
}
