using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Orb : MonoBehaviour
{
    float _movementDuration = 0.1f;
    float _elapsedtime;
    [SerializeField] ParticleSystem burstParticles;

    public static Action<string> OnScoreIncreased;

    private void OnEnable()
    {
        SelectOnClick.OnGameObjectHit += OrbWasHit;
    }

    private void OnDisable()
    {
        SelectOnClick.OnGameObjectHit -= OrbWasHit;
    }

    void OrbWasHit(GameObject orb)
    {
        if(orb == this.gameObject)
        {
            StartCoroutine("GetSmaller");
            OnScoreIncreased(this.gameObject.name);
        }
    }

    IEnumerator GetSmaller()
    {
        while(_elapsedtime < _movementDuration)
        {
            transform.localScale = Vector3.Lerp(new Vector3(1,1,1), new Vector3(0,0,0), _elapsedtime/_movementDuration);
            _elapsedtime += Time.deltaTime;
            yield return null;
        }
        burstParticles.GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject, 0.3f);
        yield return null;
    }
}
