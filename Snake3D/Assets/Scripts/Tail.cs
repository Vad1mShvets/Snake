using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    int targetNumber;

    private void Start()
    {
        targetNumber = int.Parse(this.name) - 1;
        this.transform.position = GameObject.Find(targetNumber + "").transform.position;
    }

    private void FixedUpdate()
    {
        GameObject c = GameObject.Find(targetNumber + "");
        Vector3 target = c.transform.position - this.transform.position;

        if (target.magnitude > 0.25f)
        {
            this.transform.Translate(target.normalized * 0.035f);
        }
    }
}
