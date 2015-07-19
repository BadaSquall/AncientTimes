using UnityEngine;

namespace AncientTimes.Assets.Scripts.NPCs.Pokemons.Volern
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Animator))]
    public class Volern : MonoBehaviour
    {
        #region Properties

        private bool hasToFlyAway;
        private float timeElapsedFromFlyingAway;
        private const float timeToWaitBeforeDestroyAfterFlyingAway = 1000.0f;
        private Vector2 speedOnFlight = new Vector2(10.0f, 5.0f);
        private Animator animator;

        #endregion Properties

        #region Methods

        private void Start() { animator = gameObject.GetComponent<Animator>(); }

        private void OnTriggerEnter2D(Collider2D colliderObject)
        {
            switch (colliderObject.tag)
            {
                case "Player":
                    hasToFlyAway = true;
                    if (colliderObject.transform.position.x > gameObject.transform.position.x)
                    {
                        var scale = gameObject.transform.localScale;
                        gameObject.transform.localScale = new Vector3(scale.x * (-1.0f), scale.y, scale.z);
                        gameObject.rigidbody2D.velocity = new Vector2(speedOnFlight.x * (-1.0f), speedOnFlight.y);
                    }
                    else gameObject.rigidbody2D.velocity = speedOnFlight;

                    animator.SetTrigger("Fly");
                    break;
            }
        }

        private void Update()
        {
            if (hasToFlyAway)
            {
                timeElapsedFromFlyingAway += Time.deltaTime;

                if (timeElapsedFromFlyingAway * 1000.0f >= timeToWaitBeforeDestroyAfterFlyingAway) Destroy(gameObject);

                return;
            }

            switch (Random.Range(0, 100))
            {
                case 0:
                    animator.SetTrigger("PeckFront");
                    break;

                case 1:
                    animator.SetTrigger("FrontIdle");
                    break;

                case 2:
                    animator.SetTrigger("PeckRear");
                    break;

                case 3:
                    animator.SetTrigger("RearIdle");
                    break;
            }
        }

        #endregion Methods
    }
}