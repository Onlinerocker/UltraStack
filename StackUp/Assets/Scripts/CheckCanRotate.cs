using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanRotate : MonoBehaviour
{
    public Move move;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || this.transform.parent == other.gameObject.transform.parent)
            return;

        Debug.Log("test " + other.gameObject.name);

        float angle = this.transform.rotation.eulerAngles.z;

        move.setCanRotate((int)angle / 90, false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
            return;

        float angle = this.transform.rotation.eulerAngles.z;
        move.setCanRotate((int)angle / 90, true);
    }
}
