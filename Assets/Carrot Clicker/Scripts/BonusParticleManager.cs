using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusParticleManager : MonoBehaviour
{
    [Header(" Elements ")]
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
        Destroy(bonusParticleInstance, 1);
    }
}
