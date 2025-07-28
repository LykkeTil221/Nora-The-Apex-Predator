using UnityEngine;
public class PlayerCheckPoint : MonoBehaviour
{
    private bool isChecked;
    public delegate void RespawnDelegate();
    public static RespawnDelegate RespawnEnemies;
    public Transform spawnPoint;
    [SerializeField] string Name;
    [SerializeField] float seconds;
    public delegate void SetCheckpoint(Transform spawnPoint);
    public static SetCheckpoint setCheckpoint;
    public delegate void DisplayCheckPointName(float seconds, string text);
    public static DisplayCheckPointName displayCheckPointName;
    public delegate void MaxOutPlayerHealth(float health);
    public static MaxOutPlayerHealth maxPlayerHealth;
    public delegate void MaxOutPlayerEnergy();
    public static MaxOutPlayerEnergy maxPlayerEnergy;

    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem InitialHitParticle1;
    [SerializeField] private ParticleSystem InitialHitParticle2;
    [SerializeField] private ParticleSystem LingeringParticle;
    [SerializeField] private ParticleSystem checkedParticle;
    private void Start()
    {
        LingeringParticle.Play();
        checkedParticle.Stop();
    }
    public void ActivateCheckPoint()
    {
        
        InitialHitParticle2.Play();
        
        RespawnEnemies.Invoke();
        setCheckpoint.Invoke(spawnPoint);
        displayCheckPointName.Invoke(seconds, Name);
        maxPlayerHealth.Invoke(100);
        maxPlayerEnergy.Invoke();

        animator.PlayInFixedTime("CheckPointChecked", 0, 0);
       
        if (!isChecked)
        {
            InitialHitParticle1.Play();
            LingeringParticle.Stop();
            LingeringParticle.Clear();
            checkedParticle.Play();
        }
        isChecked = true;
    }
}
