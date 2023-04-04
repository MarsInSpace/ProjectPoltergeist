using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSphere : MonoBehaviour
{
    bool isDespawnable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DespawnVisitor() {
        isDespawnable = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3 && isDespawnable) { other.gameObject.SetActive(false); }
    }
}
