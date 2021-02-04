/* Autor: Bruno Yusuke */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Classe responsável pelo controle da tela título do jogo*/

public class StartScreenControllerScript : MonoBehaviour
{
    //*Objetos*//

    //Objeto da classe 'LevelChangerScript', Possui referência da cena da tela título
    public LevelChangerScript levelChanger;

    //Start() is called before the first frame update

    //Referência da tela título é carregada 
    void Start()
    {

        levelChanger = FindObjectOfType<LevelChangerScript>();
        Invoke("changeScene", 5.0f);

    }

    //Transição da tela título para o cenário da Cozinha
    void changeScene(){
        levelChanger.FadeToLevel("SampleScene");
        // SceneManager.LoadScene("SampleScene");
    }

    //Update() is called once per frame
    void Update()
    {
        
    }
}
