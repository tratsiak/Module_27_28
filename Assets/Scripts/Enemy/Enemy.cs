using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isDead;

    public bool IsDead => _isDead;

    public float Lifetime { get; private set; }

    private void Update()
    {
        LifeTimer();
    }

    private void LifeTimer() => Lifetime += Time.deltaTime;
}
