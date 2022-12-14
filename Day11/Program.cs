using Day11;
using System.Numerics;
//21816744824

//Monkey[] Monkeys =
//{
//    new Monkey()
//    {
//        Number = 0,
//        Items = new Queue<ulong>(new List<ulong>() {79, 98}),
//        Divisor = 23,
//        TrueTarget = 2,
//        FalseTarget = 3,
//        Operation = new Func<ulong, ulong>(i => i * 19)
//    },
//    new Monkey()
//    {
//        Number = 1,
//        Items = new Queue<ulong>(new List<ulong>() {54, 65, 75, 74}),
//        Divisor = 19,
//        TrueTarget = 2,
//        FalseTarget = 0,
//        Operation = new Func<ulong, ulong>(i => i + 6)
//    },
//    new Monkey()
//    {
//        Number = 2,
//        Items = new Queue<ulong>(new List<ulong>() {79, 60, 97}),
//        Divisor = 13,
//        TrueTarget = 1,
//        FalseTarget = 3,
//        Operation = new Func<ulong, ulong>(i => i * i)
//    },
//    new Monkey()
//    {
//        Number = 3,
//        Items = new Queue<ulong>(new List<ulong>() {74}),
//        Divisor = 17,
//        TrueTarget = 0,
//        FalseTarget = 1,
//        Operation = new Func<ulong, ulong>(i => i + 3)
//    }
//};

Monkey[] Monkeys =
{
    new Monkey()
    {
        Number = 0,
        Items = new Queue<ulong>(new List<ulong>() {89, 74}),
        Operation = new Func<ulong, ulong>(i => i * 5),
        Divisor = 17,
        TrueTarget = 4,
        FalseTarget = 7,
    },
    new Monkey()
    {
        Number = 1,
        Items = new Queue<ulong>(new List<ulong>() {75, 69, 87, 57, 84, 90, 66, 50}),
        Operation = new Func<ulong, ulong>(i => i + 3),
        Divisor = 7,
        TrueTarget = 3,
        FalseTarget = 2,
    },
    new Monkey()
    {
        Number = 2,
        Items = new Queue<ulong>(new List<ulong>() {55}),
        Operation = new Func<ulong, ulong>(i => i + 7),
        Divisor = 13,
        TrueTarget = 0,
        FalseTarget = 7,
    },
    new Monkey()
    {
        Number = 3,
        Items = new Queue<ulong>(new List<ulong>() {69, 82, 69, 56, 68}),
        Operation = new Func<ulong, ulong>(i => i + 5),
        Divisor = 2,
        TrueTarget = 0,
        FalseTarget = 2,
    },
    new Monkey()
    {
        Number = 4,
        Items = new Queue<ulong>(new List<ulong>() {72, 97, 50}),
        Operation = new Func<ulong, ulong>(i => i + 2),
        Divisor = 19,
        TrueTarget = 6,
        FalseTarget = 5,
    },
    new Monkey()
    {
        Number = 5,
        Items = new Queue<ulong>(new List<ulong>() {90, 84, 56, 92, 91, 91}),
        Operation = new Func<ulong, ulong>(i => i * 19),
        Divisor = 3,
        TrueTarget = 6,
        FalseTarget = 1,
    },
    new Monkey()
    {
        Number = 6,
        Items = new Queue<ulong>(new List<ulong>() {63, 93, 55, 53}),
        Operation = new Func<ulong, ulong>(i => i * i),
        Divisor = 5,
        TrueTarget = 3,
        FalseTarget = 1,
    },
    new Monkey()
    {
        Number = 7,
        Items = new Queue<ulong>(new List<ulong>() {50, 61, 52, 58, 86, 68, 97}),
        Operation = new Func<ulong, ulong>(i => i + 4),
        Divisor = 11,
        TrueTarget = 5,
        FalseTarget = 4,
    }
};

ulong GCP = Monkeys.Select(m => m.Divisor).Aggregate((d1, d2) => d1 * d2);
for (int i = 0; i < 10000; i++)
{
    for (int j = 0; j < Monkeys.Length; j++)
    {
        Monkey monkey = Monkeys[j];
        while (monkey.Items.Any())
        {
            monkey.TimesInspected++;
            ulong item = monkey.Items.Dequeue();
            item = monkey.Operation(item) % GCP;
            //item = monkey.Operation(item) / 3;
            int target;
            if (item % monkey.Divisor == 0ul) target = monkey.TrueTarget;
            else target = monkey.FalseTarget;
            Monkeys[target].Items.Enqueue(item);
        }
    }
}
Monkeys = Monkeys.OrderByDescending(x => x.TimesInspected).ToArray();
Console.WriteLine((ulong)Monkeys[0].TimesInspected * (ulong)Monkeys[1].TimesInspected);