using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    [SerializeField] float _powerupDuration = 2f;
    [SerializeField] float _movementSpeed = 1;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(_rb);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
            Feedback();
            StartCoroutine(Duration(player));
        }
    }

    IEnumerator Duration(Player player)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(_powerupDuration);

        PowerDown(player);
        gameObject.SetActive(false);
    }

    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    private void Feedback()
    {
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
        }

        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }

    protected virtual void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(0, 0, _movementSpeed);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }
}
