


[System.Flags]
public enum DayCondition
{
  None      = (0 << 0),

  Monday    = (1 << 0),
  Tuesday   = (1 << 1),
  Wednesday = (1 << 2),
  Thursday  = (1 << 3),
  Friday    = (1 << 4),
  Saturday  = (1 << 5),
  Sunday    = (1 << 6),

  AnyDay    = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday,
  Weekday   = Monday | Tuesday | Wednesday | Thursday | Friday,
  Weekend   = Saturday | Sunday,

  Morning   = (1 << 7),
  Afternoon = (1 << 8),
  Evening   = (1 << 9),

  AnyTime   = Morning | Afternoon | Evening,

  Any = AnyDay | AnyTime
}
