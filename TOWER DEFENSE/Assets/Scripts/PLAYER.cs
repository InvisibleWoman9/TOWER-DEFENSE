using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public List<GameObject> Tours;
    Transform blocselectionne;

    void Start()
    {
        
    }


    void Update()
    {
        RaycastHit hit;
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 100f))
        {
            if(hit.transform.CompareTag("POSELA"))
            {
                if(blocselectionne != null && hit.transform != blocselectionne)
                { 
                    blocselectionne.GetChild(0).gameObject.SetActive(false);
                    blocselectionne = null;
                }

                blocselectionne = hit.transform;
                hit.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                if(blocselectionne != null)
                { 
                    blocselectionne.GetChild(0).gameObject.SetActive(false);
                    blocselectionne = null;
                } 
            }
        }


        if(Input.GetMouseButtonDown(0) && blocselectionne != null)
        {
            PoseTour(blocselectionne); 
        }


    }

    void PoseTour(Transform bloc)
    {
        if(Tours.Count < 1) return;
        Instantiate(Tours[0], bloc.position, Quaternion.identity);
        Tours.RemoveAt(0);
    }


}
