using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    // Start is called before the first frame update
    float scaleSize;
    public float speed;
    void Start()
    {
        
        
        scaleSize = Random.Range(0.1f, 1);
        transform.localScale = new Vector3(scaleSize, scaleSize, 1);
        transform.Rotate(0,0, Random.Range(1,359));
        speed = 1 / scaleSize;
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
