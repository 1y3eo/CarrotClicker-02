using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BonusParticleManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private CarrotManager carrotManager;
    [SerializeField] private GameObject bonusParticlePrefab;

    [Header(" Pooling ")]
    private ObjectPool<GameObject> bonusParticlesPool;

    private void Awake()
    {
        InputManager.onCarrotClickedPosition += CarrotClickedCallBack;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClickedPosition -= CarrotClickedCallBack;

    }
    void Start()
    {
        bonusParticlesPool = new ObjectPool<GameObject>(CreateFunction, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }

    void Update()
    {
        
    }

    private GameObject CreateFunction()
    {
        return Instantiate(bonusParticlePrefab, transform);
    }

    private void ActionOnGet(GameObject bonusParticle)
    {
        bonusParticle.SetActive(true);
    }

    private void ActionOnRelease(GameObject bonusParticle)
    {
        bonusParticle.SetActive(false);
    }

    private void ActionOnDestroy(GameObject bonusParticle)
    {
        Destroy(bonusParticle);
    }

    private void CarrotClickedCallBack(Vector2 clickedPosition)
    {
        GameObject bonusParticleInstance = bonusParticlesPool.Get();

        bonusParticleInstance.transform.position = clickedPosition;
        bonusParticleInstance.GetComponent<BonusParticle>().Configure(carrotManager.GetCurrentMultiplier());

        LeanTween.delayedCall(1, () => bonusParticlesPool.Release(bonusParticleInstance));
    }
}
