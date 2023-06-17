using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    public bool hasRegenerated = true;
    public bool isSprinting = false;
    public bool isCanRun = true;

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 1.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;


    [Header("Stamina UI Elements")]
    [SerializeField] private Image StaminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private PlayerMove playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (!isSprinting)
        {
            if(playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);

                if(playerStamina >= maxStamina)
                {
                    sliderCanvasGroup.alpha = 0;
                    hasRegenerated = true;
                }
            }
        }
    }

    public void Sprinting()
    {
        if(hasRegenerated)
        {
            isSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if(playerStamina <= 0)
            {
                sliderCanvasGroup.alpha = 0;
                isSprinting = false;
                hasRegenerated = false;
                isCanRun = false;
            }
        }
        if(playerStamina >= 90)
        {
            isCanRun = true;
        }
    }

    void UpdateStamina(int value)
    {
        StaminaProgressUI.fillAmount = playerStamina / maxStamina;
           
        if(value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
