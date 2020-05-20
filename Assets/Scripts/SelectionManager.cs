using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]  private Material highlightMaterial;
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField]  private Material standardMaterial;

    private Transform _selection;
    private Transform _start;

    private bool isScalable = false;
    public GameObject SferaFirma;
    public GameObject Cornice;

    private bool wasIn = false;
    private Transform selectionScale; 

        private int scalingFramesLeft = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if(_selection != null){
            var selectionRender = _selection.GetComponent<Renderer>();

            selectionRender.material = standardMaterial;
           // _selection.transform.localScale = new Vector3 (1.3f,1.3f,1.3f);
           scalingFramesLeft = 100;
            _selection = null;
    
            
        }
      var ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

      RaycastHit hit;
      if(Physics.Raycast(ray,out hit)){
          var selection = hit.transform;
          if(selection.CompareTag(selectableTag)){
              wasIn = true;
              

          var selectionRender = selection.GetComponent<Renderer>();
           selectionScale = selection.GetComponent<Transform>();

          if(selectionRender != null)
          {
              selectionRender.material = highlightMaterial;
              if (scalingFramesLeft > 0) {
            hit.transform.localScale = new Vector3( Mathf.Lerp (selection.transform.localScale.x, 1.8f, Time.deltaTime *10),Mathf.Lerp (selection.transform.localScale.y, 1.8f, Time.deltaTime *10 ),Mathf.Lerp (selection.transform.localScale.z, 1.8f, Time.deltaTime * 10 ));
            scalingFramesLeft--;
        
        }

          }
          _selection = selection;
          }
          else if(wasIn == true){
              selectionScale.localScale = new Vector3 (1.3f,1.3f,1.3f);
              wasIn = false;
          } 
          

    }
}
    
}