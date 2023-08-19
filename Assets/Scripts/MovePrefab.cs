using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public GameObject prefabToMove;
    public GameObject sensorToActivate, sensorToDeactivate;
    private float deltaX;

    // Start is called before the first frame update
    void Start()
    {
        deltaX = 76.80217f;
       /* sensor1ToActivate.SetActive(false);
        sensor2ToActivate.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sensorToActivate.SetActive(true);
        prefabToMove.transform.position = new Vector2(prefabToMove.transform.position.x + deltaX, prefabToMove.transform.position.y);
        Debug.Log("sensor triggered...");
        sensorToDeactivate.SetActive(false);
        Debug.Log("sensor triggered..ffffff.");
    }
}
