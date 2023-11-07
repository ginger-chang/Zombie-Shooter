using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{
    [SerializeField] public InputActionReference controllerActionTrigger;
    private XRDirectInteractor interactor;
    private float prevTrigger = 0.0f;
    private GameObject gun = null;

    // Start is called before the first frame update
    void Start()
    {
        interactor = GetComponent<XRDirectInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerActionTrigger.action.ReadValue<float>() != 0)
        {
            Debug.Log("Trigger from " + this.gameObject.name.ToString());
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            if (interactor.hasSelection)
            {

                float trigger = controllerActionTrigger.action.ReadValue<float>();
                print("Grabbing gun.");
                Debug.Log("Grabbing gun.");
                if (trigger != 0 && prevTrigger == 0.0f)
                {
                    Debug.Log("Fire!");
                    other.gameObject.GetComponent<Gun>().Fire();
                }
                prevTrigger = trigger;
                Debug.Log("Trigger value: " + trigger);
            }
        }
    }
}
