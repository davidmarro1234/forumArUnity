using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour {

    private bool aVideoIsPlaying=false;
    // Don't create/size the Array in Start() - that makes an empty
    // array, discarding the clips you assigned in the Inspector.
    public VideoClip[] vids = new VideoClip[3];
    public GameObject cornice0;
    public GameObject cornice1;
    public GameObject cornice2;
    public GameObject cornice3;
    public GameObject cornice4;

  //  private Color coloreCornice;
     Color color = new Color32(14, 14, 14, 255);

    private VideoPlayer vp;
string btnName;
    void Start () {
    var vp = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
    }

void Update()
    {
        
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray,out Hit)){
                btnName = Hit.transform.name;
                switch(btnName){
                    case "Video0":
                        aVideoIsPlaying=true;
                         vp = GetComponent<UnityEngine.Video.VideoPlayer>();
                        //cornice = GameObject.Find("Video0/Cornice");
                        var corniceRenderer0 = cornice0.GetComponent<Renderer>();
                        var corniceRenderer1 = cornice1.GetComponent<Renderer>();
                        var corniceRenderer2 = cornice2.GetComponent<Renderer>();
                        var corniceRenderer3 = cornice3.GetComponent<Renderer>();
                        var corniceRenderer4 = cornice4.GetComponent<Renderer>();
                        corniceRenderer0.material.SetColor("_Tint", Color.red);
                        corniceRenderer1.material.SetColor("_Tint", color);
                        corniceRenderer2.material.SetColor("_Tint", color);
                        corniceRenderer3.material.SetColor("_Tint", color);
                        corniceRenderer4.material.SetColor("_Tint", color);
                        //coloreCornice = corniceRenderer.material.GetColor("_Tint");
                        //Debug.Log(coloreCornice);
                       vp.clip = vids[0];
                       Debug.Log(btnName);
                       vp.Play();
                        if(vp.isPlaying == true){
                            vp.Stop();
                            aVideoIsPlaying=false;
                            corniceRenderer0.material.SetColor("_Tint", color);
                        }else{
                            vp.Play();

                        }
                        
                        
                        break;
                
                        case "Video1":
                        aVideoIsPlaying=true;

                         vp = GetComponent<UnityEngine.Video.VideoPlayer>();
                        //cornice = GameObject.Find("Video0/Cornice");
                         corniceRenderer0 = cornice0.GetComponent<Renderer>();
                         corniceRenderer1 = cornice1.GetComponent<Renderer>();
                         corniceRenderer2 = cornice2.GetComponent<Renderer>();
                         corniceRenderer3 = cornice3.GetComponent<Renderer>();
                         corniceRenderer4 = cornice4.GetComponent<Renderer>();
                        corniceRenderer0.material.SetColor("_Tint", color);
                        corniceRenderer1.material.SetColor("_Tint", Color.red);
                        corniceRenderer2.material.SetColor("_Tint", color);
                        corniceRenderer3.material.SetColor("_Tint", color);
                        corniceRenderer4.material.SetColor("_Tint", color);
                        //coloreCornice = corniceRenderer.material.GetColor("_Tint");
                        //Debug.Log(coloreCornice);
                       vp.clip = vids[1];
                       Debug.Log(btnName);
                       vp.Play();
                        if(vp.isPlaying == true){
                            vp.Stop();
                                                        aVideoIsPlaying=false;

                            corniceRenderer1.material.SetColor("_Tint", color);
                        }else{
                            vp.Play();

                        }
                        
                        
                        break;
                            case "Video2":
                        aVideoIsPlaying=true;

                         vp = GetComponent<UnityEngine.Video.VideoPlayer>();
                        //cornice = GameObject.Find("Video0/Cornice");
                         corniceRenderer0 = cornice0.GetComponent<Renderer>();
                         corniceRenderer1 = cornice1.GetComponent<Renderer>();
                         corniceRenderer2 = cornice2.GetComponent<Renderer>();
                         corniceRenderer3 = cornice3.GetComponent<Renderer>();
                         corniceRenderer4 = cornice4.GetComponent<Renderer>();
                        corniceRenderer0.material.SetColor("_Tint", color);
                        corniceRenderer1.material.SetColor("_Tint", color);
                        corniceRenderer2.material.SetColor("_Tint", Color.red);
                        corniceRenderer3.material.SetColor("_Tint", color);
                        corniceRenderer4.material.SetColor("_Tint", color);
                        //coloreCornice = corniceRenderer.material.GetColor("_Tint");
                        //Debug.Log(coloreCornice);
                       vp.clip = vids[2];
                       Debug.Log(btnName);
                       vp.Play();
                        if(vp.isPlaying == true){
                            vp.Stop();
                                                        aVideoIsPlaying=false;

                            corniceRenderer2.material.SetColor("_Tint", color);
                        }else{
                            vp.Play();

                        }
                        
                        
                        break;
                        
                }
            }
        }

        if(aVideoIsPlaying){
        if((vp.frameCount == (ulong)vp.frame+1))
    //Video has finshed playing!
   {
            vp.Stop();
            Debug.Log("Eccallà");
        }}
    }
 /*   // Call this method when it's time to play a particular video.
    // Pass a number from 0 to 25 inclusive to choose which video.
    public PlayVideo(int id) {
        // To be safe, let's bounds-check the ID 
        // and throw a descriptive error to catch bugs.
        if(id < 0 || id >= vids.Length) {
            Debug.LogErrorFormat(
               "Cannot play video #{0}. The array contains {1} video(s)",
                                   id,                 vids.Length);
            return;
        }

        // If we get here, we know the ID is safe.
        // So we assign the (id+1)th entry of the vids array as our clip.
        vp.clip = vids[id];

        vp.Play();
    }*/
}