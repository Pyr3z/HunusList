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


  private static List<UIView> s_ViewStack = new List<UIView>();


  public static void OpenView([CanBeNull] UIView view)
  {
    if (!view || !Current)
      return;

    if (view.gameObject.scene.name != Current.gameObject.scene.name)
    {
      view = Instantiate(view);
      view.hideFlags |= HideFlags.DontSave;
    }

    s_ViewStack.Add(view);

    view.transform.SetParent(Current.transform, worldPositionStays: true);
    view.Show();
  }


  protected override void OnValidate()
  {
    base.OnValidate();

    if (!m_HeaderText)
    {
      m_HeaderText = transform.Find("Header").GetComponent<TMP_Text>();
    }
  }

}
