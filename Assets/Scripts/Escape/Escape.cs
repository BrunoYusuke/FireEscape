/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*Classe responsável pelo evento de fuga*/

public class Escape : MonoBehaviour
{

    //*Objetos e Variaveis*//

    //Nível da chama
    public int state;

    //Objeto da classe 'FryingPanInteraction'
    public FryingPanInteraction fireReference;

    //Referência de Layer
    public LayerMask mask;

    //Tamanho espacial de Raycast
    public float raycastSize;

    //radialBar contem uma imagem de uma barra radial
    public Image radialBar;

    //Tempo atual de foco
    public float timeFocussing;

    //Tempo de foco necessario para fuga
    public float timeToEscape;

    //Objeto da classe 'LevelChangerScript'
    public LevelChangerScript levelChanger;

    //Inicializa Objetos e Variaveis
    void Start()
    {
        radialBar = GameObject.Find("EscapeBar").GetComponent<Image>();
        radialBar.enabled = false;

        state = 0;
        raycastSize = 0.35f;

        timeFocussing = 0;

        levelChanger = FindObjectOfType<LevelChangerScript>();
    }

    //Verifica-se, a partir do estado da chama, se a fuga pela porta é possível.
    //Obs: A fuga é possível apenas se o nível das chamas é o mais alto.
    void Update()
    {
        state = fireReference.state;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInformation;

        if (Physics.Raycast(ray, out hitInformation, raycastSize, mask, QueryTriggerInteraction.Ignore) && state == 2)
        {
            timeFocussing += Time.deltaTime;

            radialBar.enabled = true;
            radialBar.fillAmount = timeFocussing / timeToEscape;
        }
        else
        {
            radialBar.enabled = false;
            radialBar.fillAmount = 0;
            timeFocussing = 0;
        }

        if(timeFocussing >= timeToEscape)
        {
            Debug.Log("Fuga concluída!");
            
            levelChanger.FadeToLevel("Screen_Win_v2");
        }
    }
}
