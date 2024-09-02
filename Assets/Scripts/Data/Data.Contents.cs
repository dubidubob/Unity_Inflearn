//�޸� �󿡼��� �Ʒ��� ���� ������ ��� ���� ��
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

        // data.stats.ToDictionary();//ios���� linq ���װ� ������ ���Ƽ�, ��� �� ��
        foreach (Stat stat in stats)
            dict.Add(stat.level, stat);
        return dict;
    }
}
#endregion