//메모리 상에서는 아래와 같은 구조로 들고 싶은 것
using System.Collections.Generic;
using System;

#region Stat
[Serializable]
public class Stat
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class StatData : ILoader<int, Stat>
{
    public List<Stat> stats = new List<Stat>();

    public Dictionary<int, Stat> MakeDict()
    {
        Dictionary<int, Stat> dict = new Dictionary<int, Stat>();

        // data.stats.ToDictionary();//ios에서 linq 버그가 굉장히 많아서, 사용 안 함
        foreach (Stat stat in stats)
            dict.Add(stat.level, stat);
        return dict;
    }
}
#endregion
