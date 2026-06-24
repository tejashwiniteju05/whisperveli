using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{
  public float speed = 2f;
  public GameObject item;
  public Transform holdPoint;
  public Transform placeArea;

  bool holding = false;

  void Update()
  {
    if (holding)
    {
      item.transform.position = holdPoint.position;
      item.transform.rotation = holdPoint.rotation;
    }
    if (!holding &&
        Vector3.Distance(transform.position, item.transform.position) <= speed)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        holding = true;

        item.transform.SetParent(holdPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        item.transform.localScale *= 0.5f;
      }
    }
    else if (holding &&
             Vector3.Distance(transform.position, placeArea.position) <= speed)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        holding = false;

        item.transform.SetParent(null);
        item.transform.position = placeArea.position;

        item.transform.localScale *= 2f;
      }
    }
  }
}
