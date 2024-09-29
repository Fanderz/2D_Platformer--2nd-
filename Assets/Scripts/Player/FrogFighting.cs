using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogFighting : MonoBehaviour
{
    [SerializeField] private HealthSystem _health;
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Healer _healer;

    private void Awake()
    {
        _fighter.TakingDamage += _health.DecreaseHealth;
        _healer.Healing += _health.IncreaseHealth;
    }

    private void FixedUpdate()
    {
        //Debug.Log($"«доровье л€гушки: {_health.Health}");

        if (_health.Health <= 0)
            SceneManager.LoadScene("SampleScene");
    }
}
