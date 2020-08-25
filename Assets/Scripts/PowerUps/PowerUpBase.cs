using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    [SerializeField] float _powerupDuration = 2f;

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
}
