using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLAYER : MonoBehaviour
{
    public List<GameObject> Tours;
    int tourselectionnee;
    bool peuposer;
    float chrono;
    Transform blocselectionne;
    public Text inputs;
    float tempsnecessaire;

    void Start()
    {
        tourselectionnee = 0;
        chrono = 10000f;
        tempsnecessaire = 1f;
    }


    void Update()
    {
        if(GameManager.access.isPlaying) chrono += Time.deltaTime;
        if(peuposer == false && chrono >tempsnecessaire)
        {
            inputs.color = new Color(1,1,1, 1f);
            peuposer = true;
        }
        
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


        if(Input.GetMouseButtonDown(0) && blocselectionne != null && peuposer)
        {
            PoseTour(blocselectionne); 
        }

        if(Input.GetKeyDown(KeyCode.A)) tourselectionnee = 0;
        if(Input.GetKeyDown(KeyCode.Z)) tourselectionnee = 1;
        if(Input.GetKeyDown(KeyCode.E)) tourselectionnee = 2;


    }

    void PoseTour(Transform bloc)
    {
        chrono = 0;
        tempsnecessaire +=0.5f;
        peuposer = false;
        inputs.color = new Color(1,1,1, 0.3f);
        Instantiate(Tours[tourselectionnee], bloc.position, Quaternion.identity);
        
    }


}
