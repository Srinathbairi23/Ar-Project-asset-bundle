using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static GameObject objinscene;

    public void ScaleObj(float value)
    {
        if (objinscene == null) return;
        objinscene.transform.localScale += new Vector3(value, value, value);
        if (objinscene.transform.localScale.x < 0.5f)
        {
            objinscene.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (objinscene.transform.localScale.x > 5f)
        {
            objinscene.transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }

    public void RotateObj(string axis)
    {
        float value = 5f;
        Quaternion rot = Quaternion.Euler(objinscene.transform.rotation.x, objinscene.transform.rotation.y, objinscene.transform.rotation.z);
        if (objinscene == null) return;

        switch (axis)
        {
            case "x":
                objinscene.transform.Rotate(Vector3.right, value);
                break;
            case "y":
                objinscene.transform.Rotate(Vector3.up, value);
                break;
            case "z":
                objinscene.transform.Rotate(Vector3.forward, value);
                break;
            case "-x":
                objinscene.transform.Rotate(Vector3.right, -value);
                break;
            case "-y":
                objinscene.transform.Rotate(Vector3.up, -value);
                break;
            case "-z":
                objinscene.transform.Rotate(Vector3.forward, -value);
                break;
            default:
                Debug.LogError("type the axis in x, y or z (in small)");
                break;

        }

    }
}
