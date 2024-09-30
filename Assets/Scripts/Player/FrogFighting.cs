using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogFighting : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Healer _healer;

    private void Awake()
    {
        _fighter.TakingDamage += _health.DecreaseHealth;
        _healer.Healing += _health.IncreaseHealth;
    }

    private void FixedUpdate()
    {
        if (_health.Value <= 0)
            SceneManager.LoadScene("SampleScene");
    }
}
