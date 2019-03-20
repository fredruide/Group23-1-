using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    // raycast2d bliver gemt som en vector2 værdi, og 3d som en vector3
    public float minGroundNormalY = 0.65f;
    public float gravityModifier = 1f; 

    protected bool grounded;
    protected Vector2 groundNormal;
    protected Vector2 targetVelocity;
    protected Rigidbody2D rb2d;
    public Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);     

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    // Start is called before the first frame update
    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {        
        contactFilter.useTriggers = false;
        // this uses the settings from the physics settings in unity. Edit/project settings/physics2D
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fixed update kalder funktionen en specifik mængde gange i sekundet
    public void Gravity()
    {
        //gravity er en standard værdi (0.-9,8) Minus fordi gravity hiver os ned. Det ganger vi med Deltatime fordi at vi skal accelerere vores hastighed
        //deltatime er vores tid mellem Frames f.eks. 0,162 sekunder
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        grounded = false;

        //Vi har så ærkleret en vector2 hvor vi så gemmer hastigheden i
        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }



    void Movement(Vector2 move, bool yMovement)
    {
        //magnitude er distancen for vores vector2
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            /* Move er vores hastigheden vi bevæger os med.
             * Contactfilter er sådan vi bestemmer hvad vi kan kollidere med via Unity project settings
             * Hitbuffer er vores raycast der skydder ud under os
             * distance og shell er længden af vores raycast
             */
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear(); // vi clear vores liste så vi ikke arbejder med gammel information
            for (int i = 0; i < count; i++)
            {
                //Vi gemmer så informationen vi får af vores raycast i vores liste efter hvor mange gange vi får information
                hitBufferList.Add(hitBuffer[i]);                
            }

            // Vi bruger så hvor mange gange vi har fået et resultat til at beregne om vi står på jorden
            for (int i = 0; i < hitBufferList.Count; i++)
            {
                //currentNormal er vores vector2 værdi normaliseret fra vores vector2 liste
                Vector2 currentNormal = hitBufferList[i].normal;
                //hvis vores y værdi er mindre end vores minimum værdi er vi så grounded
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    //yMovement er en bool
                    if (yMovement)
                    {
                        //vi laver vores x værdi 0 fordi at vi ikke har noget at bruge vores x værdi til i vores næste beregning
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
                
                // vi finder så punkt værdien for vores vektorer,
                // og bestemmer hvad vores y hastighed er når vi står på en rigidbody
                float projection = Vector2.Dot(velocity, currentNormal);
                //for at kunne stå på skrå kanter(Der kan være en grænse for hvor skrå den kan være)
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                
                // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

        }

        rb2d.position = rb2d.position + move.normalized * distance;

    }
}
