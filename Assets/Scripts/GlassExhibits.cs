using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassExhibits : Exhibits
{
    [SerializeField]
    List<GameObject> GlassChildren = new List<GameObject>();

    [SerializeField] private Exhibits ExhibitsToObserve;
    

    // Start is called before the first frame update
    void Start()
    {
        if (ExhibitsToObserve != null) {
            ExhibitsToObserve.GotHit += DestroyGlass;
        }

        foreach(Transform child in transform) {
            GameObject glassChild = child.gameObject;
            GlassChildren.Add(glassChild);
        }

        Debug.Log(GlassChildren.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyGlass(Collision collisionInfo) {
        if(collisionInfo.gameObject.tag == "Possessable" && !ManagerScript.IsPossessed) {
            for(int i = 0; i < GlassChildren.Count; i++) {
                Rigidbody rigidbody = GlassChildren[i].AddComponent<Rigidbody>();
            }
        }
    }

    private void OnDestroy()
    {
        if (ExhibitsToObserve != null)
        {
            ExhibitsToObserve.GotHit -= DestroyGlass;
        }
    }
}
