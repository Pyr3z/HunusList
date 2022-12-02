// A Popup is a thing that can "pop up" from virtually any view,
// partially obscure said view, and command the user's attention.

using Kooapps.Kore;
using UnityEngine;


public class UIPopup : UIThing
{

  public float Delay
  {
    get => m_DelaySeconds;
    set => m_DelaySeconds = value.AtLeast(0f);
  }


  [SerializeField]
  protected float m_DelaySeconds;

  [System.NonSerialized]
  private float m_Timer;

}
