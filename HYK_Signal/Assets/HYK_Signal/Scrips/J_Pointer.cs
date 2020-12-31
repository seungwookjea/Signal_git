using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Pointer : MonoBehaviour
{
    GameObject pointer;
    public GameObject takenObj;
    public float distance =3 ;
    Vector3 alwaysCenter = Vector3.zero;
    Ray ray;
    Ray ray2;
    RaycastHit hitInfo;
    Vector3 PointerDistance;

    float maxRange = 10;

    public GameObject openhandUI;
    public GameObject grabUI;


    void Start()
    {
        pointer = GameObject.Find("Pointer");
        pointer.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, (Screen.height / 2), distance));

        openhandUI.SetActive(false);
        grabUI.SetActive(false);
        //J_Outline.instance.OutlineMode = J_Outline.Mode.OutlineHidden;
    }

    void Update()
    {

        pointer.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, (Screen.height / 2), distance));


        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, (Screen.height / 2), 0));
        ray2 = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, (Screen.height / 2), 0));

        Debug.DrawRay(ray.origin, ray.direction * maxRange, Color.yellow);

        // ui grab
        if (Physics.Raycast(ray2, out hitInfo, 1000))
        {
            if (hitInfo.transform.tag != "GribObj")
            {
                openhandUI.SetActive(false);
            }
        }


        if (Physics.Raycast(ray, out hitInfo, maxRange))
        {
            if (hitInfo.transform.tag == "GribObj" && takenObj == null)
            {
                openhandUI.SetActive(true);
            }
            // else if(hitInfo.transform.tag != "GribObj")
            //{
            //    openhandUI.SetActive(false);
            //}
        }




        if (Input.GetKeyDown("f") && Physics.Raycast(ray, out hitInfo, maxRange))
        {
            if (hitInfo.transform.tag == "GribObj")
            {
                openhandUI.SetActive(false);
                grabUI.SetActive(true);

                takenObj = hitInfo.transform.gameObject;
                takenObj.transform.parent = pointer.transform;
                takenObj.GetComponent<Rigidbody>().isKinematic = true;
                //takenObj.GetComponent<Collider>().isTrigger = true;

                
            }
        }

        if (Input.GetKey("f"))
        {
            if (takenObj != null)
            {
                PointerDistance = pointer.transform.position - takenObj.transform.position;
                alwaysCenter = takenObj.transform.position - takenObj.GetComponent<MeshRenderer>().bounds.center;
                takenObj.transform.position = Vector3.Lerp(takenObj.transform.position, takenObj.transform.position + alwaysCenter + PointerDistance, Time.deltaTime * 5);
                takenObj.transform.rotation = Quaternion.Lerp(takenObj.transform.rotation, Quaternion.Euler(0, takenObj.transform.eulerAngles.y, 0), Time.deltaTime * 5);
            }
        }


        if (Input.GetKeyUp("f"))
        {

            if (takenObj != null)
            {
                grabUI.SetActive(false);

                takenObj.GetComponent<Rigidbody>().isKinematic = false;
                //takenObj.GetComponent<Collider>().isTrigger = false;

                takenObj.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 1, ForceMode.Impulse);

                takenObj.transform.parent = null;
                takenObj = null;
            }
        }
    }
}