using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public Sprite portalOnSprite;
    public Sprite portalOffSprite;
    private GameObject lever;
    private SpriteRenderer spriteRenderer;
    private Sprite currentSprite;
    public bool isOpen { get { return portalOpen; }}
    private bool portalOpen;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lever =  GameObject.FindGameObjectWithTag("lever");
        // daca exista o pranghie, portalul va fii deschs 
        portalOpen = false;
        if (lever == null)
        {
            portalOpen = true;
            spriteRenderer.sprite = portalOnSprite;
        }
    }

    public void OpenPortal()
    {
        spriteRenderer.sprite = portalOnSprite;
        portalOpen = true;
    }
}
