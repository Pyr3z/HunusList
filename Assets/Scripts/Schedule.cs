using Kooapps.Kore;

using UnityEngine;


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


  public static void TaskNotification(TaskData task)
  {

  }

}
