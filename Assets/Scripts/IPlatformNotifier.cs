using JetBrains.Annotations;

using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;


public interface IPlatformNotifier
{

  void Initialize();

  void ScheduleNotification([NotNull] string title, [NotNull] string details, DateTime firetime, TimeSpan repeat);

}
