﻿using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDistance;
    public static bool holding;

    

    public string[] prompt = new string[] { "Grab", "Release" };
   
    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDistance);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Grabbable")
        {
            if (Input.GetKeyDown(KeyCode.C)) holding = !holding;

           

            if (holding)
            {
               

                grabCheck.collider.gameObject.transform.parent = boxHolder;

                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
       



    }    
}