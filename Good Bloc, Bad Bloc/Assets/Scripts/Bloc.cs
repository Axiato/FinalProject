using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloc : MonoBehaviour
{

    [SerializeField] GameObject face;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        face.transform.position = gameObject.transform.position;
    }
}
