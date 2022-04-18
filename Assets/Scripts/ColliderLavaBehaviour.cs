using UnityEngine;

public class ColliderLavaBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>()!=null)
        {
            UIManagerScript.Instance.Defeat();
        }
    }
}