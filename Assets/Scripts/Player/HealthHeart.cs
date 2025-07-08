using UnityEngine;
using UnityEngine.UI;
public class HealthHeart : MonoBehaviour
{
    [SerializeField] private Sprite fullheart, threeQHeart, halfHeart, quarterHeart, emptyHeart;
    [SerializeField] private Image HeartImage;

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                HeartImage.sprite = emptyHeart;
                break;
            case HeartStatus.Quarter:
                HeartImage.sprite = quarterHeart;
                break;
            case HeartStatus.half:
                HeartImage.sprite= halfHeart;
                break;
            case HeartStatus.threeQuarter:
                HeartImage.sprite = threeQHeart;
                break;
            case HeartStatus.Full:
                HeartImage.sprite = fullheart;
                break;
        }
    }
    public enum HeartStatus
    {
        Empty = 0,
        Quarter = 1,
        half = 2,
        threeQuarter = 3,
        Full = 4,

    }
}
