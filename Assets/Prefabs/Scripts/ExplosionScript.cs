using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private ParticleSystem par;
    private Light lightComp;
    // Start is called before the first frame update
    void Start()
    {
        // Make a game object
        GameObject lightGameObject = new GameObject("The Light");

        // Add the light component
        lightComp = lightGameObject.AddComponent<Light>();

        // Set color and position
        // lightComp.color = Color.blue;
        lightComp.intensity = 0;
        

        // Set the position (or any transform property)
        lightGameObject.transform.position = new Vector3(0, 0, 0);
        // ParticleSystem p= GetComponent<ParticleSystem>();

        par = GetComponent<ParticleSystem>();
    }
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        // if(par.isPlaying){
        //     lightComp.intensity = 5;
        // }else{
        //     if(lightComp.intensity == 5){
        //         lightComp.intensity = 0;
        //     }
        // }
        if(par.isPlaying){
            float luz = 5;
            if(par.time > 0.2f){
                Debug.Log(par.time);
                Debug.Log((par.time-0.2f)/0.3f);
                lightComp.intensity = luz * Mathf.SmoothStep(1.0f,0.0f,(par.time-0.2f)/0.3f);
            }
        }
    }
}