using UnityEngine;

public class safe : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      enemy.safeZone = true;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      enemy.safeZone = false;
    }
  }
}
