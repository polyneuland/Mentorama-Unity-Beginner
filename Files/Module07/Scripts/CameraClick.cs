using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClick : MonoBehaviour
{
    public Transform alvo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(raio, out hit, 1000f))
            {
                Debug.Log($"Clicou {hit.transform.name} no ponto {hit.point}");
                alvo.position = hit.point;
            }
        }
    }
}
