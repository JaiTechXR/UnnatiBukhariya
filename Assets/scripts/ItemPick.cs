using UnityEngine;

public class ItemPick : Interactable
{
   public override void Interact()
    {
        base.Interact();
        PickUp();
        void PickUp()
        {
            Debug.Log("Picking up item");
            Destroy(gameObject);
        }
    }
}
