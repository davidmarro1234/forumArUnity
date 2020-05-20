using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVideoOnTouch : MonoBehaviour
{
    string btnName;
      void Start()
    {
        var vp = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        vp.playOnAwake = false;
        vp.url = "https://r5---sn-4g5ednek.googlevideo.com/videoplayback?expire=1586191478&ei=FgiLXs3oD9a1kwac6p5I&ip=107.189.168.93&id=o-AGwPpx0Jrt0BZadpckfhViUa0-RYpLwldWSM2aoScT4S&itag=18&source=youtube&requiressl=yes&vprv=1&mime=video%2Fmp4&gir=yes&clen=35317297&ratebypass=yes&dur=661.048&lmt=1581015760282904&fvip=5&fexp=23882514&c=WEB&txp=5536432&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cvprv%2Cmime%2Cgir%2Cclen%2Cratebypass%2Cdur%2Clmt&sig=AJpPlLswRQIgVA7Zzbjly9UtmysJLtsR7PpPcSn8tHWwgiV_bTYNntkCIQCSagZ5h8I_s0azg46MumZk3F6RDIVDayaMxyrFQrYZgA%3D%3D&title=I+SIMPSON+Italiano+-+Sto+Ballando+Pi%C3%B9+Grasso+Che+Posso+1/2+-+Cartoni+Animati&redirect_counter=1&cm2rm=sn-a5myd76&req_id=1a1a10e28677a3ee&cms_redirect=yes&mh=1z&mip=80.116.225.121&mm=34&mn=sn-4g5ednek&ms=ltu&mt=1586169693&mv=u&mvi=4&pl=17&lsparams=mh,mip,mm,mn,ms,mv,mvi,pl&lsig=ALrAebAwRgIhAJ1lEGUkTdpDvk5ONygCyH0uYsMQIfqr466Rr9dNm5rZAiEAloCHRdP3TO-Uucgvdfjqxt3j2WQLKJqcXFRZKPNO1lI%3D";
        
        vp.isLooping = false;
        vp.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
        vp.targetMaterialRenderer = GetComponent<Renderer>();
        vp.targetMaterialProperty = "_MainTex";
        

     //   vp.Play();
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
                switch(btnName){
                    case "LaVitaEBella":
                        var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
                        if(vp.isPlaying == true){
                            vp.Stop();
                        }else{
                            vp.Play();

                        }
                        
                        
                        break;
                }
            }
        }
    }
}
