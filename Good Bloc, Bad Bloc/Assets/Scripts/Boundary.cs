using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    [SerializeField] GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Good")
        {
            manager.gameOver("You killed a Good Bloc");
            
        }
        else if (other.gameObject.tag == "Bad")
        {

        }
        else
        {

        }

        Destroy(other.gameObject);
    }
}





