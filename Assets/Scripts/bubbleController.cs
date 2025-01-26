
using UnityEngine;
using UnityEngine.InputSystem;

public class bubbleController : MonoBehaviour
{
    [SerializeField] float maxBubbleSize = 2f;
    [SerializeField] float spawnOffsetX = 0f;
    [SerializeField] float spawnOffsetY = 0f;
    [SerializeField] float growSpeed = 1f;
    [SerializeField] float shootForce = 10f;
    [SerializeField] public bool isBlowing;
    [SerializeField] float bubbleSize = 0.5f;
    [SerializeField] GameObject bubblePrefab;

[SerializeField] string gumType;
    [SerializeField] Camera cam;
     public GameObject currentBubble;
     

    void Start(){
        
    }

    void FixedUpdate()
    {
        if(isBlowing){
            bubbleSize+=growSpeed*Time.deltaTime;
            bubbleSize = Mathf.Clamp(bubbleSize, 0.5f, maxBubbleSize);
            currentBubble.transform.localScale = Vector3.one*bubbleSize;
            currentBubble.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }

    public void StartBlow(){
        if(currentBubble==null){
            isBlowing=true;
            bubbleSize = 0.5f;
            currentBubble = Instantiate(bubblePrefab, transform.position+new Vector3(spawnOffsetX, spawnOffsetY, 0f), Quaternion.identity);
            if(gumType=="fire"){
                currentBubble.GetComponent<SpriteRenderer>().color = Color.red;
            }
            currentBubble.transform.SetParent(transform, true);
        }
    }

    public void StopBlowingShoot(){
        if(currentBubble!=null){
            Physics2D.IgnoreCollision(currentBubble.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            isBlowing = false;
            currentBubble.transform.SetParent(null);
            Rigidbody2D rb = currentBubble.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldMousePosition = cam.ScreenToWorldPoint(mousePosition);
            Vector2 shootDirection = (worldMousePosition - (Vector2)currentBubble.transform.position).normalized;
            rb.AddForce(shootDirection*shootForce, ForceMode2D.Impulse);
        }
    }
}
