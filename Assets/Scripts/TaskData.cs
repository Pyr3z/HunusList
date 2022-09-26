


[System.Serializable]
public class TaskData
{
  public string Name = string.Empty;

  public string Details = string.Empty;

  public FrequencyCategory Frequency = FrequencyCategory.Once;

  public DayCondition DayCondition = DayCondition.Any;

  public long CreatedAt;

  public long[] Completions = System.Array.Empty<long>();


  public static TaskData MakeNew(string name)
  {
    return new TaskData
    {
      Name      = name ?? string.Empty,
      CreatedAt = System.DateTime.UtcNow.ToBinary()
    };
  }

}
