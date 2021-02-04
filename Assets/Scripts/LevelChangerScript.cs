/* Autor: Bruno Yusuke */

using UnityEngine;
using UnityEngine.SceneManagement;

/*Classe responsável pelo controle da transição entre cenas*/

public class LevelChangerScript : MonoBehaviour
{
    //*Objetos*//

    //Objeto que define efeitos visuais
    public Animator animator;

    //Recebe a cena a ser carregada
    private string levelToLoad;

    void Update()
    {
        
    }

    //Recebe referencia da cena a ser carregada
    public void FadeToLevel(string level) {
        levelToLoad = level;
        animator.SetTrigger("FadeOut");
    }

    //Transição de cena
    public void onFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }

    //Transição de cena pela tela de fim de jogo
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
