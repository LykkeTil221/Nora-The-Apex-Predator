using UnityEngine;

public class ProgressWorldUpdater : MonoBehaviour
{
    [SerializeField] private GameObject WorldUpdate;

    private void Start()
    {
        WorldUpdate.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WorldUpdate.SetActive(true);
        }
    }
}
