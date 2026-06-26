using UnityEngine;

public class CollisionDetec : MonoBehaviour

{
   [SerializeField] GameObject thePlayer;
   [SerializeField] GameObject playerAnim;
   [SerializeField] AudioSource collisionFX;
    void OnTriggerEnter(Collider other)
    {
       thePlayer.GetComponent<PlayerMovement>().enabled = false;
       playerAnim.GetComponent<Animator>().Play("Death");
       collisionFX.Play();
    }
}