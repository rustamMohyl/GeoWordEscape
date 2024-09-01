using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CattGPX : MonoBehaviour
{
    public AIPath aiPath;
    void CatGPXUpdate()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01){
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}
