using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;


public class LevelManager : MonoBehaviour
{
    
    
    [SerializeField] private GameObject _loaderCanvas;
    
    private bool transitionReady;

    private AsyncOperation scene;

    public void LoadScene(string sceneNAme)
    {
        
        GetComponent<Animator>().SetTrigger("ExitScene");
        scene = SceneManager.LoadSceneAsync(sceneNAme);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

        

    }


    private void TransitionReady()
    {
        transitionReady = true;
    }

    private void SceneOpened()
    {
        _loaderCanvas.SetActive(false);
    }

    private void Update() {

        if(transitionReady)
        {
        transitionReady = false;
        scene.allowSceneActivation = true;
       
        }
        
    }

   



}
