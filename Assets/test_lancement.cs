using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class test_lancement : MonoBehaviour
{
    public Animator animator;
    public string stateName = "Entry"; // nom exact de l'état dans l'Animator
    
    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip detectionSound;
    
    [Header("Animation & Sound Settings")]
    [Tooltip("Triggers de l'Animator pour chaque animation")]
    public string attackTriggerName = "AttackTrigger";
    public string screamTriggerName = "ScreamTrigger";
    public string deathTriggerName = "DeathTrigger";
    public string idleTriggerName = "IdleTrigger";
    
    [Tooltip("Sons à jouer pour chaque action")]
    public AudioClip attackSound;
    public AudioClip screamSound;
    public AudioClip deathSound;
    
    [Header("UI Buttons")]
    public Button attackButton;
    public Button screamButton;
    public Button deathButton;
    
    private ObserverBehaviour observerBehaviour;
    private bool isTracked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Récupérer le composant ObserverBehaviour (ImageTarget)
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        
        // Si l'Animator n'est pas assigné, le chercher dans les enfants
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        
        // S'assurer qu'on a un AudioSource
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        
        // Configurer les boutons UI
        SetupUIButtons();
    }

    void SetupUIButtons()
    {
        // Associer les méthodes aux boutons et les désactiver au début
        if (attackButton != null)
        {
            attackButton.onClick.AddListener(() => PlayAnimationWithSound(attackTriggerName, attackSound));
            attackButton.interactable = false;
        }
        
        if (screamButton != null)
        {
            screamButton.onClick.AddListener(() => PlayAnimationWithSound(screamTriggerName, screamSound));
            screamButton.interactable = false;
        }
        
        if (deathButton != null)
        {
            deathButton.onClick.AddListener(() => PlayAnimationWithSound(deathTriggerName, deathSound));
            deathButton.interactable = false;
        }
    }

    void OnDestroy()
    {
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    // Méthode appelée quand le statut de l'image change
    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        var name = behaviour.name;
        var status = targetStatus.Status;

        if (status == Status.TRACKED || status == Status.EXTENDED_TRACKED)
        {
            if (!isTracked)
            {
                Debug.Log("Image détectée : " + name);
                OnTrackingFound();
            }
        }
        else
        {
            if (isTracked)
            {
                Debug.Log("Image perdue : " + name);
                OnTrackingLost();
            }
        }
    }

    void OnTrackingFound()
    {
        isTracked = true;
        
        // Jouer le son de détection
        if (audioSource && detectionSound)
        {
            audioSource.PlayOneShot(detectionSound);
        }
        
        // Lancer l'animation du dinosaure (état par défaut)
        if (animator)
        {
            animator.SetTrigger(idleTriggerName);
        }
        
        // Rendre l'objet visible
        SetRendererEnabled(true);
        
        // Activer les boutons UI
        SetButtonsInteractable(true);
    }

    void OnTrackingLost()
    {
        isTracked = false;
        
        // Cacher l'objet
        SetRendererEnabled(false);
        
        // Désactiver les boutons UI
        SetButtonsInteractable(false);
    }

    void SetButtonsInteractable(bool interactable)
    {
        if (attackButton != null)
            attackButton.interactable = interactable;
        
        if (screamButton != null)
            screamButton.interactable = interactable;
        
        if (deathButton != null)
            deathButton.interactable = interactable;
    }

    public void PlayAnimationWithSound(string triggerName, AudioClip soundClip)
    {
        // Vérifier si le dinosaure est visible et tracké
        if (!isTracked)
        {
            Debug.Log("Dinosaure non visible, impossible de jouer l'animation");
            return;
        }
        
        // Déclencher l'animation via le trigger
        if (animator && !string.IsNullOrEmpty(triggerName))
        {
            Debug.Log("Déclenchement du trigger : " + triggerName);
            animator.SetTrigger(triggerName);
        }
        
        // Jouer le son
        if (audioSource && soundClip)
        {
            Debug.Log("Lecture du son pour : " + triggerName);
            audioSource.PlayOneShot(soundClip);
        }
    }

    void SetRendererEnabled(bool enabled)
    {
        var renderers = GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = enabled;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
