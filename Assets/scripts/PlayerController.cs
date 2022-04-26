using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public TextMeshProUGUI countText, winText,systemID;
    Camera cam;
    public AudioClip barrelSound,winSound;
    bool gameEnded = false;
    public float RestartDelay = 3f;
    PlayerMotor motor;
    public Interactable focus;
    private int count;
    void Start()
    {
        systemID.text = "System ID: "+ SystemInfo.deviceUniqueIdentifier;
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        count = 0;
        
    }

    
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                RemoveFocus();
                
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

    }
    void SetFocus(Interactable newFocus)
    {   if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        
        newFocus.OnFocused(transform);
        
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        
        focus = null;
        
        motor.StopFollow();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("barrel"))
        {
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(barrelSound, transform.position, 2);
            count++;
            countText.text = "score: " + count.ToString();
            if (count >= 10)
            {
                if (gameEnded == false)
                {
                    gameEnded = true;
                    AudioSource.PlayClipAtPoint(winSound, transform.position, 4);
                    winText.gameObject.SetActive(true);
                    Invoke("Restart", RestartDelay);
                }
                
            }
        }
       
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
