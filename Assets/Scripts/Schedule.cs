using JetBrains.Annotations;

using Kooapps.Kore;

using UnityEngine;

using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;


[AssetPath("Resources/Schedule.asset")]
public class Schedule : AssetSingleton<Schedule>
{

#if UNITY_ANDROID
  // only Android is planned for now... but you never know ~(￣▽￣)~*
  private static readonly IPlatformNotifier s_Notifier = new AndroidPlatformNotifier();
#endif

  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
  private static void SubsystemInit()
  {
    s_Notifier.Initialize();
  }


  public static void TaskNotification([NotNull] TaskData task)
  {
    // TODO handle resolution logic for user's chosen frequency + day condition parameters

    if (task.Frequency == FrequencyCategory.Once)
    {
      s_Notifier.ScheduleNotification(task.Name, task.Details, DateTime.Now.AddMinutes(1), TimeSpan.Zero);
    }
  }

}
