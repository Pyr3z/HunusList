using Kooapps.Kore;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System.Collections.Generic;


[RequireComponent(typeof(Canvas))]
public class UI : KomponentSingleton<UI>
{

[Header("UI References")]
  [SerializeField]
  private TMP_Text m_HeaderText;

  [SerializeField]
  private UIThing m_Thing;


  private static List<UIView> s_ViewStack = new List<UIView>();

  private static List<(UIPopup popup, float time)> s_PopupQueue = new List<(UIPopup popup, float time)>();


  public static void ShowThing([CanBeNull] UIThing thing)
  {
    if (thing is UIPopup popup)
    {
      QueuePopup(popup);
    }
    else if (thing is UIView view)
    {
      OpenView(view);
    }
    else if (thing)
    {
      thing.Show();
    }
  }

  public static void OpenView([CanBeNull] UIView view)
  {
    if (!view)
      return;

    if (!Current)
    {
      s_ViewStack.Add(view);
      return;
    }

    view = Adopt(view);

    s_ViewStack.Add(view);

    view.Show();
  }

  public static void QueuePopup([CanBeNull] UIPopup popup)
  {
    if (!popup)
      return;

    if (!Current)
    {
      s_PopupQueue.Add((popup, popup.Delay));
    }
  }


  private static T Adopt<T>([NotNull] T maybePrefab) where T : Component
  {
    Debug.Assert(Current);

    string sceneName = maybePrefab.gameObject.scene.name;

    if (sceneName.IsEmpty())
    {
      maybePrefab = Instantiate(maybePrefab);
      maybePrefab.hideFlags |= HideFlags.DontSave;
    }

    maybePrefab.transform.SetParent(Current.transform, worldPositionStays: true);

    return maybePrefab;
  }


  protected override void OnValidate()
  {
    base.OnValidate();

    if (!m_HeaderText)
    {
      m_HeaderText = transform.Find("Header").GetComponent<TMP_Text>();
    }

    if (m_Thing)
    {
      Debug.Log(m_Thing.gameObject.scene.name);
    }
  }

}
