using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.TryGetComponent(out ObjectGrabbable objectGrabbable))
        {
            if (objectGrabbable.foodItem)
            {
                objectGrabbable.StartCook();
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.TryGetComponent(out ObjectGrabbable objectGrabbable))
        {
            if (objectGrabbable.foodItem)
            {
                objectGrabbable.StopCook();
            }
        }
    }
}
