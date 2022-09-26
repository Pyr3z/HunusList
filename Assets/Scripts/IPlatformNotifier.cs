using DateTime = System.DateTime;


public interface IPlatformNotifier
{

  void Initialize();

  void ScheduleNotification(TaskData task, DateTime firetime);

}
