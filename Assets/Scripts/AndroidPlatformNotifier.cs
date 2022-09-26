using Unity.Notifications.Android;

using UnityEngine;

using System.Collections.Generic;
using JetBrains.Annotations;

using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;


public class AndroidPlatformNotifier : IPlatformNotifier
{
  private Dictionary<Importance, string> m_Channels = new Dictionary<Importance, string>()
  {
    [Importance.Low]     = $"{Application.identifier}+{Importance.Low}",
    [Importance.Default] = $"{Application.identifier}+{Importance.Default}",
    [Importance.High]    = $"{Application.identifier}+{Importance.High}",
  };

  public void Initialize()
  {
    foreach (var (importance, id) in m_Channels)
    {
      var channel = new AndroidNotificationChannel(
        id: id,
        name: $"{Application.productName}",
        description: $"{importance} importance channel",
        importance: importance
      );

      AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }
  }

  public void ScheduleNotification(string name, string details, DateTime firetime, TimeSpan repeat)
  {
    var notif = new AndroidNotification(
      title:          name,
      text:           details,
      fireTime:       firetime
    );

    if (repeat != TimeSpan.Zero)
    {
      // need to check this beforehand since the backend does some funky null-ish patterns
      notif.RepeatInterval = repeat;
    }

    AndroidNotificationCenter.SendNotification(notif, m_Channels[Importance.Default]);
  }
}
