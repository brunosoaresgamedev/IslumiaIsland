﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterFacing2D))]
public class AIVision : MonoBehaviour
{
    public bool IsTargetUp;
    public bool IsTargetUpOrDown;
    [Range(0.5f, 10.0f)]
    public float visionRange = 5;
    [Range(0, 180)]
    public float visionAngle = 180;
    public float FullvisionAngle = 90;
    public bool isvisible;
    

    private CharacterFacing2D charFacing;

    
    private void Awake()
    {
        
        charFacing = GetComponent<CharacterFacing2D>();
    }
    public bool IsVisible(GameObject target)
    {
        if(target == null)
        {
            
            return false;

        }
        if(Vector2.Distance(transform.position,target.transform.position) > visionRange)
        {
         
            return false;
        }

        Vector2 toTarget = target.transform.position - transform.position;
        Vector2 visionDirection = GetVisionDirection();
     
        if (Vector2.Angle(visionDirection, toTarget) > visionAngle / 2)
        {
            
            if (Vector2.Angle(visionDirection, toTarget) > 0  )
            {
                
                
                return false;
            }
            
            return false;
        }


        
       
      

        //TODO fazer ele n ver atravez da parede
        return true;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector3 visionDirection = GetVisionDirection();
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, visionAngle / 2) * visionDirection * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, - visionAngle / 2) * visionDirection * visionRange);

    }

    private Vector2 GetVisionDirection()
    {
        if(charFacing == null)
        {
            return Vector2.right;
        }
       return charFacing.IsFacingRight() ? Vector2.right : Vector2.left;
    }
}
