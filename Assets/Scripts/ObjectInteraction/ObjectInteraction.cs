/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*Classe responsável pelo controle de posse de objetos ao usuário*/

public class ObjectInteraction : MonoBehaviour
{

    /*Objetos e Variáveis*/

    //target possui referência do objeto focado
    public GameObject target;

    //holdPosition guarda a posição atual do objeto
    public GameObject holdPosition;

    //radialBar contem uma imagem de uma barra radial
    public Image radialBar;

    //timeToHold tempo para foco
    public float timeToHold = 3.0f;

    //timeFocussing tempo atual de foco
    public float timeFocussing = 0.0f;

    //Referência da camada
    public LayerMask mask;

    //Boleano usado para verificar se o usuário tem posse de algum objeto
    public bool isHolding;

    //Guarda a referência do objeto em mãos
    public GameObject objectInHand;

    //Tamanho espacial de Raycast
    public float raycastSize;

    //SFX
    public GameObject pickupSFX;

    //Start() is called before the first frame update
    //Inicializa atributos de objetos
    private void Start()
    {
        target = new GameObject("emptyReference");
        isHolding = false;

        radialBar = GameObject.Find("RadialBar").GetComponent<Image>();
        radialBar.enabled = false;

        raycastSize = 0.5f;

        //SFX
        pickupSFX = GameObject.Find("relogio");
    }


    // A cada quadro (frame) processado pela engine, está sendo verificado:
    // Se algum objeto está sendo focado pela visão do usuário
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInformation;

        if (Physics.Raycast(ray, out hitInformation, raycastSize, mask, QueryTriggerInteraction.Ignore) && !isHolding)
        {
            if (target.name != hitInformation.transform.name)
            {
                if(target.name != "emptyReference")
                {
                    target.GetComponent<cakeslice.Outline>().enabled = false;
                }

                target = hitInformation.transform.gameObject;
                
                
                timeFocussing = 0;

                radialBar.fillAmount = 0;
            }
            else
            {
                target.GetComponent<cakeslice.Outline>().enabled = true;
                timeFocussing += Time.deltaTime;

                radialBar.enabled = true;
                radialBar.fillAmount = timeFocussing / timeToHold;
            }

            Debug.DrawLine(ray.origin, hitInformation.point, Color.green);
        }
        else
        {
            if (target.name != "emptyReference")
            {
                target.GetComponent<cakeslice.Outline>().enabled = false;
                target = GameObject.Find("emptyReference");
            }

            

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * raycastSize, Color.red);
            timeFocussing = 0;

            radialBar.fillAmount = 0;
            radialBar.enabled = false;
        }
    }


    // A cada quadro (frame) processado pela engine, está sendo verificado:
    // Se o tempo em que o usuário focou o olhar no objeto é maior ou igual ao 'timeToHold'
    private void Update()
    {
        if (timeFocussing >= timeToHold)
        {
            pickupItem();

            //SFX
            pickupSFX.GetComponent<AudioSource>().Play();
        }

        if(isHolding && Input.GetMouseButtonDown(0))
        {
            releaseItem();
        }
    }

    // Função responsável pela posse do objeto ao usuário
    // Objeto é posicionado à frente do usuário, simulando um utensílio nas mãos do usuário
    public void pickupItem()
    {
        isHolding = true;
        objectInHand = target;
        objectInHand.transform.GetComponent<Collider>().enabled = false;
        objectInHand.transform.GetComponent<Rigidbody>().useGravity = false;
        objectInHand.transform.position = holdPosition.transform.position;
        objectInHand.transform.parent = this.transform;
        objectInHand.GetComponent<cakeslice.Outline>().enabled = false;
        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        timeFocussing = 0;
    }

    //Função usado para testar interação entre objetos usando botão de mouse
    //Disponível apenas durante testes pela Unity
    public void releaseItem()
    {
        isHolding = false;
        objectInHand.transform.GetComponent<Collider>().enabled = true;
        objectInHand.transform.GetComponent<Rigidbody>().useGravity = true;
        objectInHand.GetComponent<cakeslice.Outline>().enabled = true;
        objectInHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        objectInHand.transform.parent = null;
        target = GameObject.Find("emptyReference");
    }

}
