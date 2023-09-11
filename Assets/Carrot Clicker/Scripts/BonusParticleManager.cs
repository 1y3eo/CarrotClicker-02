using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusParticleManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private CarrotManager carrotManager;
    [SerializeField] private GameObject bonusParticlePrefab;

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
        
    }

    void Update()
    {
        
    }

    private void CarrotClickedCallBack(Vector2 clickedPosition)
    {
        GameObject bonusParticleInstance = Instantiate(bonusParticlePrefab, clickedPosition, Quaternion.identity, transform);

        bonusParticleInstance.GetComponent<BonusParticle>().Configure(carrotManager.GetCurrentMultiplier()); ;
        
        Destroy(bonusParticleInstance, 1);
    }
}
