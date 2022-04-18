using UnityEngine;

public class ColliderFinishBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            UIManagerScript.Instance.Win();
        }
    }
}