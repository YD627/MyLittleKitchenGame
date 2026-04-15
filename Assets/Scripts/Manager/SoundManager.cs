using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private int volume = 5;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OrderManager.Instance.OnRecipeSucceed += OrderManager_OnRecipeSucceed;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        KitchenObjectHolder.OnDrop += KitchenObjectHolder_OnDrop;
        KitchenObjectHolder.OnPickup += KitchenObjectHolder_OnPickup;
        TrashCounter.OnObjectTrash += TrashCounter_OnObjectTrash;
    }

    private void TrashCounter_OnObjectTrash(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.trash, 0.3f);
    }

    private void KitchenObjectHolder_OnPickup(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickup, 0.3f);
    }

    private void KitchenObjectHolder_OnDrop(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectDrop, 0.3f);
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.chop, 0.3f);
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliveryFail, 0.2f);
    }

    private void OrderManager_OnRecipeSucceed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliverySuccess, 0.2f);
    }

    private void PlaySound(AudioClip[] clips, Vector3 position, float volumeMutipler = .1f)
    {
        if (volume == 0) return;
        int index = Random.Range(0, clips.Length);
        AudioSource.PlayClipAtPoint(clips[index], position, volumeMutipler * (volume / 10.0f));
    }
    private void PlaySound(AudioClip[] clips, float volumeMutipler = .1f)
    {
        PlaySound(clips, Camera.main.transform.position, volumeMutipler);
    }
    public void PlayStepSound(float volumeMutipler = .1f)
    {
        PlaySound(audioClipRefsSO.footstep, volumeMutipler);
    }
    public void ChangeVolume()
    {
        // volume 0-10 0`1
        volume++;
        if (volume > 10) volume = 0;
    }
    public int GetVolume()
    {
        return volume;
    }
}
