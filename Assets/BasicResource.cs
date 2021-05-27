using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicResource : MonoBehaviour
{
    GameManager gmScript;
    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        gmScript.AddBasicResource(1);
        Destroy(gameObject);
    }
}
