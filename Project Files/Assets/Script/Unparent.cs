using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unparent : MonoBehaviour
{
    public void UnparentObject(GameObject go)
    {
        go.transform.parent = null;
    }
}
