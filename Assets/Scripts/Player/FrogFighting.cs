using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogFighting : MonoBehaviour
{
    [SerializeField] private HealthSystem _health;
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Healer _healer;

    private void Awake()
    {
        _fighter.OnChangeHealth += _health.ChangeHealth;
        _healer.OnHealing += _health.ChangeHealth;
    }

    private void FixedUpdate()
    {
        //Debug.Log($"«доровье л€гушки: {_health.Health}");

        if (_health.Health <= 0)
            SceneManager.LoadScene("SampleScene");
    }
}
