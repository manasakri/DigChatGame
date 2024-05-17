using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeInput : MonoBehaviour
{
    EventSystem system;
    public Selectable firstInput;
    void Start() {
        system = EventSystem.current;
        firstInput.Select();
        
                
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) ) {
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (previous != null) {
                previous.Select() ;
            }
        }
    }
}
