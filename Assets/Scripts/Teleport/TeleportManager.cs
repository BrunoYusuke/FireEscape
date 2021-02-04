/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*Classe responsável pela funcionalidade de teleporte por foco*/

public class TeleportManager : MonoBehaviour
{
    /*Objetos e Variáveis*/

    //target possui referência do objeto focado
    public GameObject target;

    //holdPosition guarda a posição atual do objeto
    public GameObject holdPosition;

    //radialBar contem uma imagem de uma barra radial
    public Image radialBar;

    //Guarda float pertinente ao tempo necessário de foco para teleporte
    public float timeToTeleport = 2.0f;

    //Guarda tempo atual de foco
    public float timeFocussing = 0.0f;

    //Referência de Layer
    public LayerMask mask;
    public LayerMask obstacle;

    //Guarda referência do ponto atual
    public GameObject currentPoint;

    //Tamanho espacial de Raycast
    public float raycastSize;

    //SFX
    public GameObject step;

    //Start() is called before the first frame update
    //Inicializa Objetos e Variaveis
    private void Start()
    {
        target = GameObject.Find("TeleportSystem");
        currentPoint = GameObject.Find("StartPoint");
        currentPoint.SetActive(false);

        radialBar = GameObject.Find("TeleportBar").GetComponent<Image>();
        radialBar.enabled = false;

        raycastSize = 5f;

        //SFX
        step = GameObject.Find("chao");
    }

    // A cada quadro (frame) processado pela engine, está sendo verificado:
    // Se alguma seta (indicador visual) está sendo focado pela visão do usuário
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInformation;

        if (Physics.Raycast(ray, out hitInformation, raycastSize, mask, QueryTriggerInteraction.Ignore))
        {

            Debug.Log(Physics.Raycast(ray, 10, obstacle));
            if (!Physics.Raycast(ray, 10, obstacle))
            {
                Debug.Log(Physics.Raycast(ray, hitInformation.distance));

                if (target.name != hitInformation.transform.name)
                {
                    target = hitInformation.transform.gameObject;

                    timeFocussing = 0;

                    radialBar.fillAmount = 0;
                    hitInformation.transform.GetChild(0).GetComponent<cakeslice.Outline>().enabled = true;
                }
                else
                {
                    timeFocussing += Time.deltaTime;

                    radialBar.enabled = true;
                    radialBar.fillAmount = timeFocussing / timeToTeleport;
                }

                Debug.DrawLine(ray.origin, hitInformation.point, Color.yellow);
            }
            else
            {
                target = hitInformation.transform.gameObject;

                timeFocussing = 0;

                radialBar.fillAmount = 0;
            }
        }
        else
        {
            if (target.name != "TeleportSystem")
            {
                target.transform.GetChild(0).GetComponent<cakeslice.Outline>().enabled = false;

                target = GameObject.Find("TeleportSystem");
            }

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * raycastSize, Color.blue);
            timeFocussing = 0;

            radialBar.fillAmount = 0;
            radialBar.enabled = false;
        }
    }

    // Caso o indicador seja focado além de 2 segundos, usuário é teleportado para o local
    private void Update()
    {
        if (timeFocussing >= timeToTeleport)
        {
            transform.parent.SetPositionAndRotation(target.transform.position, transform.parent.transform.rotation);
            

            currentPoint.SetActive(true);
            target.SetActive(false);
            currentPoint = target;

            //SFX
            step.GetComponent<AudioSource>().Play();
        }
    }
}
