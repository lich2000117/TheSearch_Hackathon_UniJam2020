
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InCamViewDisableFollow : MonoBehaviour
{

    private NPCfollow followScript;
    private Renderer renderer;

    public GameObject player;
    public GameObject monster;
    //public int lifeNum = 3;
    private bool closeEnough = false;
    private float timer = 0;
    //private int deathCount = 0;
    private UnityEngine.AI.NavMeshAgent nav;
    private GameObject soundEffect;

     void Start () {
        followScript = this.GetComponent<NPCfollow>();
        renderer = GameObject.Find("173Body").GetComponent<Renderer>();
        followScript.enabled = false;
        soundEffect = GameObject.Find("AudioManager");
        this.GetComponent<InCamViewDisableFollow>().enabled = false;
     }
 
     void Update () 
     {
         if (renderer.isVisible){
             //if inside the camera range, disable follow script and set current destination to local self
            followScript.enabled = false;
         }
         else{
             //if too close, player died
            if (Vector3.Distance(monster.transform.position, player.transform.position)<1.6f) {
                closeEnough = true;
                monster.transform.LookAt(player.transform);
                player.transform.LookAt(monster.transform);
                player.GetComponent<MoveCam>().enabled = false;
                soundEffect.GetComponent<AudioSource>().clip = soundEffect.GetComponent<AudioManager>().audioClips[4];
                soundEffect.GetComponent<AudioSource>().Play();
            }
            followScript.enabled = true;
         }

         //timer before switch scene
        if (closeEnough){
            timer += Time.deltaTime;
        }
        if (timer >= 3){
                SceneManager.LoadScene("BadEnd");
            }
     }

}
