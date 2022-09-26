using Unity.Notifications.Android;

using UnityEngine;

using DateTime = System.DateTime;


public class AndroidPlatformNotifier : IPlatformNotifier
{
  public void Initialize()
  {
    Importance[] importances = new[]
    {
      //Importance.Low,
      //Importance.Default,
      Importance.High,
    };

    foreach (var importance in importances)
    {
      var channel = new AndroidNotificationChannel(
        id: $"{Application.identifier}+{importance}",
        name: $"{Application.productName}",
        description: $"{importance} importance channel",
        importance: importance
      );

      AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }
  }

  public void ScheduleNotification(TaskData task, DateTime firetime)
  {

  }
}
