using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusicOnTouch : MonoBehaviour
{
    public AudioClip[] aClips;
    public AudioSource myAudioSource;
    string btnName;
    bool box015isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray,out Hit)){
                btnName = Hit.transform.name;
                Debug.Log(btnName);
                switch(btnName){
                    case "Box015":
                        myAudioSource.clip = aClips[0];
                        if(box015isPlaying == true){
                            myAudioSource.Stop();
                            box015isPlaying = false;
                        }else{
                            myAudioSource.Play();
                            box015isPlaying = true;
                        }
                        
                        
                        break;
                }
            }
        }
    }
}
