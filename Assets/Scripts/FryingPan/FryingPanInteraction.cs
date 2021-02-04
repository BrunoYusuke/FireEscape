/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe responsável pela interação dos utensílios domésticos com a 'frigideira'*/

public class FryingPanInteraction : MonoBehaviour
{

    /*Objetos e Variáveis*/

    ///Referências dos objetos que representam chamas
    public GameObject lowFire;
    public GameObject mediumFire;
    public GameObject highFire;

    //Objeto da Classe 'ObjectInteraction' 
    public ObjectInteraction itemHandleScript;

    //Referência dos objetos interativos da cena
    public GameObject tampaInvisivel;
    public GameObject canecaInvisivel;
    public GameObject extintorKInvisivel;
    public GameObject extintorAInvisivel;
    public GameObject bicarbonatoInvisivel;

    //Nível da chama
    public int state; 

    //Tempo para fim de jogo
    public float timeUntilGameOver;

    //Lista que contem tempos referentes ao aumento das chamas
    public float[] timeUntilFireLevels;

    //Nível atual das chamas
    public int currentFireLevel;

    //Tempo atual (deltaatime)
    public float currentTime;

    //Referencia dos objetos que representam a chama
    public GameObject fire;
    public GameObject smoke;

    //Boleano pertinente a condição de vitória ou derrota do usuário
    public bool clear;

    //SFX
    public GameObject lid;
    public GameObject cup;
    public GameObject fryingPan;
    public GameObject ceiling;

    //Controle de cena
    public LevelChangerScript levelChanger;

    //Objeto da Classe 'ObjectSpawn' 
    public ObjectSpawn objectSpawn;

    //Start() is called before the first frame update
    //Inicializa Objetos e Variaveis
    void Start()
    {
        state = 0;
        
        itemHandleScript = GameObject.Find("Camera").GetComponent<ObjectInteraction>();
        
        mediumFire.SetActive(false);

        currentTime = 0f;
        currentFireLevel = 0;

        clear = false;

        //SFX
        lid = GameObject.Find("tampa");
        cup = GameObject.Find("caneca_agua");
        fryingPan = GameObject.Find("frigideira");
        ceiling = GameObject.Find("Teto");

        levelChanger = FindObjectOfType<LevelChangerScript>();

        objectSpawn = new ObjectSpawn();
        objectSpawn.StartObject();
    }

    // A cada quadro (frame) processado pela engine, está sendo verificado:
    // Se o tempo atual ultrapassou algum dos tempos referente à lista 'timeUntilFireLevels'
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timeUntilFireLevels[currentFireLevel] && !clear)
            Explode(currentFireLevel);

        if (currentTime >= timeUntilFireLevels[2] + timeUntilGameOver)
        {

            levelChanger.FadeToLevel("Screen_GameOver");
        }

    }

    // Aumenta o nível das chamas
    private void Explode(int index)
    {
        fire.transform.GetChild(index).gameObject.SetActive(true);
        smoke.transform.GetChild(index).gameObject.SetActive(true);
        state = 2;
        
        fryingPan.GetComponent<AudioSource>().volume = 0.7f;

        if (currentFireLevel < 2)
            currentFireLevel++;

    }

    // A partir do utensílio utilizado para interagir com a frigideira,
    // Os níveis das chamas serão alteradas conforme o switchcase abaixo
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("pickable") && state != 2)
        {
            print(itemHandleScript.objectInHand.name);

            //Pega o nome do objeto que está na mão.
            string item = itemHandleScript.objectInHand.name;

            switch (item)
            {
                case "tampa":
                    itemHandleScript.releaseItem();
                    Destroy(collider.gameObject);
                    //lowFire.SetActive(false);
                    tampaInvisivel.SetActive(true);
                    clear = true;

                    //SFX
                    lid.GetComponent<AudioSource>().Play();
                    fryingPan.GetComponent<AudioSource>().Stop();
                    break;

                case "caneca_agua":
                    if (state == 0)
                    {
                        itemHandleScript.releaseItem();
                        Destroy(collider.gameObject);
                        canecaInvisivel.SetActive(true);
                        currentTime = 39;

                        //SFX
                        cup.GetComponent<AudioSource>().Play();
                    }
                    break;
                    case "extintor_A":
                    if (state == 0)
                    {
                        itemHandleScript.releaseItem();
                        Destroy(collider.gameObject);
                        extintorAInvisivel.SetActive(true);
                        currentTime = 39;
                       
                    }
                    break;
                    case "extintor_K":
                    if (state == 0)
                    {
                        itemHandleScript.releaseItem();
                        Destroy(collider.gameObject);
                        extintorKInvisivel.SetActive(true);
                        fryingPan.GetComponent<AudioSource>().Stop();
                    }
                    break;
                    case "bicarbonato_sodio":
                    if (state == 0)
                    {
                        itemHandleScript.releaseItem();
                        Destroy(collider.gameObject);
                        bicarbonatoInvisivel.SetActive(true);

                        //SFX
                        cup.GetComponent<AudioSource>().Play();
                    }
                    break;
                default:
                    print("none");
                    break;
            }
        }
    }
}
