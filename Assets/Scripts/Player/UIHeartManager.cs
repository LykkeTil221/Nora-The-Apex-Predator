using System.Collections.Generic;
using UnityEngine;
using static HealthHeart;

public class UIHeartManager : MonoBehaviour
{
    [SerializeField] private GameObject UIHeartPrefab;
    [SerializeField] private PlayerStateManager Player;
    [SerializeField] List<HealthHeart> hearts = new List<HealthHeart>();

    private void Start()
    {
        DrawHearts();
        UpdateHearts();
    }
    public void DrawHearts()
    {
        ClearHearts();
        int heartsToMake = (int)Player.currentHeartAmount;

        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();

        }
        
    }
    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            int currentHealthStatus = (int)Mathf.Clamp(Player.CurrentPlayerHealth - (i * 4), 0, 4);
            Debug.Log(currentHealthStatus);
            hearts[i].SetHeartImage((HeartStatus)currentHealthStatus);
        }
    }
    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(UIHeartPrefab);
        newHeart.transform.SetParent(transform);
        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
}
