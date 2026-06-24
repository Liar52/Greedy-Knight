using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;

    private bool collected = false;

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        collected = true;

        coinFX.Play();
        MasterInfo.AddCoin();
        this.gameObject.SetActive(false);
    }
}