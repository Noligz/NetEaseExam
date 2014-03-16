using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;



namespace qaExam2014
{
    /// <summary>
    /// C#一级的三条题目答题模板，这几道题主要是考查各位对代码质量的把控；
    /// Tips：先想清楚测试用例，用测试驱动开发将能提高代码的质量。
    /// </summary>
    class Level_1
    {
        //【强大的攻击值】
        //游戏中的数值系数会随着等级或者装备的提升而不断增大，如果一开始没有规划好，
        //将会导致数值计算超出程序语言所能支持的最大精度而溢出；譬如一个高阶玩家的攻
        //击数值是“865987453”，在战斗中触发了强力暴击，攻击系数提升73倍，那算起来
        //就超过了32bit的数值精度；现在为了全面解决这类问题，程序员已经全部把计算接
        //口做了改善增加了对大数据的支持；现在你需要简单地写段大数据乘法的代码去测试
        //程序员的改动是否正确。
        //===============================
        //【参数】：   2个字符串参数（a，b）分别是两个用半角字符串表示的实数(只包括
        //             正负号、小数点和数字，且题目保证单个参数的字符长度<=50)；
        //             比如：参数为-865987453.36589，73.23658）,代表将要乘的两个乘数
        //             是-865987453.36589，73.23658；
        //
        //【返回】：   全精度计算结果（半角字符串，碰到小数位末尾有0请截去）；
        //             上述例子中的参数将对应输出字符串：-63421959407.4272722562;
        public string p1_damageBonuses(string a, string b)
        {
            //请填入代码
            BigNum l = new BigNum(a);
            BigNum r = new BigNum(b);
            BigNum result = l * r;
            return result.ToString();
        }


        //【夺命机关】
        //X游戏的策划小明想到了一个休闲的机关玩法并把玩法文档交给了你做审核；
        //他的玩法要点如下：怪物和玩家所操控的角色都被限定在一段距离为S的直线
        //路径上面且初始时分据两个端点，游戏开始后，无论怪物还是玩家角色都会
        //自动沿着直线路径匀速移动（速度分别为V1和V2，且开始时是相向而行），
        //当他们到达路径的端点后，会马上按原速度折返继续匀速移动；怪物和玩家
        //相遇时，玩家可以跳起通过踩踏的方式攻击怪物，若未能及时跳起怪物将会
        //发起攻击从而造成玩家角色血量的下降。看完小明的这个策划文档，对游戏
        //数值异常敏感的你马上发现，要预估玩家在时间T之内是否能通关，很有必要
        //算出在时间T之内，怪物和玩家角色相遇的次数，于是你准备写一个小程序用
        //来算这个相遇次数。
        //===============================
        //【参数】：  4个int参数（s，v1，v2，t）分别是：
        //            路径长度（米）、怪物速度（米/秒）、角色速度（米/秒）、运动的时间（秒）；
        //            如：（2,1,1,1）指的是：在2米的路径长度下，怪物和玩家角色都以1米/s的速度相向
        //            而行，要求1秒钟他们会相遇多少次？

        //【返回】：  怪物和玩家角色的相遇次数（int），
        //            如上述输入参数，将会输出：1，代表怪物和玩家角色将会相遇1次。

        public int p2_trap(int s, int v1, int v2, int t)
        {
            //请填入代码
            return 0;
        }


        //【卡牌的组合技】
        //C游戏是一个卡牌类游戏，玩家通过战斗或抽牌可以拿到一些技能牌，
        //每张技能牌都有对应的伤害值（伤害值>=0），当你有了组合技属性之
        //后，你可以在自己手头上选择任意张技能牌，以组合技的方式来攻击
        //boss，组合技的总伤害将等于所组合的各张技能牌的伤害值的乘积(只
        //有一张牌时，组合技伤害值等于这张牌本身的伤害值)，但是能发动组
        //合技必须有个前提：所有被选择的技能牌的伤害系数之和必须等于m（m>0）
        //以解开封印；你为了能赢得最终PK，需要在所有技能牌中挑出若干张技
        //能牌触发组合技（每张牌只能用一次），以形成最大威力的组合技攻击效果。
        //============================
        //【参数】：
        //            t:	你所拥有的n张技能牌 的伤害系数数组；
        //                （如：[1,2,3,4,5,6]，降低难度，牌的数量n<=20张）
        //            m:	组合技需要凑的伤害数之和;(如：7)

        //【返回】：   返回的是一个int整数（如：12），代表能解开封印（即：和等于m）
        //            且能发出最大攻击的卡牌伤害值组合数组（如：[3,4]）所触发的组
        //            合技总伤害值；若没有符合要求的卡牌组合，请输出int整数：-1。
        public int p3_combo(int[] t, int m)
        {
            //请填入代码
            if (t == null || m < 0)
                return -1;

            Int64[,] record = new Int64[m + 1, t.Length];
            for (int i = 0; i <= m; i++)
            {
                record[i, 0] = -1;
            }
            if (t[0] <= m)
                record[t[0], 0] = t[0];

            for (int j = 1; j < t.Length; j++)
            {
                for (int i = 0; i <= m; i++)
                {
                    record[i, j] = record[i, j - 1];
                }
                if (t[j] <= m && t[j] > record[t[j], j])
                    record[t[j], j] = t[j];
                for (int i = 0; i <= m; i++)
                {
                    if (record[i, j - 1] > -1 && i + t[j] <= m && record[i, j - 1] * t[j] > record[i + t[j], j])
                        record[i + t[j], j] = record[i, j - 1] * t[j];
                }
            }

            Int64 ret = -1;
            for (int j = 0; j < t.Length; j++)
            {
                if (record[m, j] > ret)
                    ret = record[m, j];
            }

            //for (int i = 0; i <= m; i++)
            //{
            //    for (int j = 0; j < t.Length; j++)
            //    {
            //        Console.Write(record[i, j]);
            //        Console.Write("\t");
            //    }
            //    Console.Write("\n");
            //}

            return (int)ret;
        }

    }

    /// <summary>
    /// C#二级的题目答题模板，这级别的题目主要考查各位对于设计方面的基础，
    /// 具体主要涉及到这几个知识点：观察者设计模式、C#的委托事件、面向对象开发以及理解和使用类库     
    /// </summary>
    /// <remarks>
    /// 【父类介绍】：
    /// MazeRobot是一个迷宫寻宝机器人的原型（abstract类，无法实例化，无法运行），功能简介如下：
    /// 1、每次初始化机器后，基类会自动清空注册到委托事件的方法-->初始化机器人的信息等；
    /// 2、run方法可以被调用，通过传入运动方向参数以及预设的运动距离来让机器人在迷宫中往指定方向前进探索；
    ///    探索的结果可能有以下情况，包括：
    ///     2.1、顺利向指定方向前进了指定的距离，中途无碰壁；
    ///     2.2、向指定方向前进的过程中碰壁，机器人将在墙壁的前一个格子位置自动停下来；
    ///     2.3、在向指定方向前进指定距离的过程中，发现了宝物投放点，机器人将在投放点停下来；
    ///    以上的三种情况均会在run方法调用后自动广播【doAfterStop】委托事件，注册此事件的方法将被自动触发执行；
    ///    注册此事件的回调方法可以从参数中获取机器人在当前的run方法调用中，移动的实际方向与距离，以及停下来的原因；
    /// 3、autoRun方法未实现，继承的子类类需要实现这个方法，让机器人获得寻宝的智能。   
    /// ---**---**---**---**---**---**---**---**---**---**---**---**---**---**---**---**---**---**---**---
    /// 【你的任务】：
    /// 你的任务就是要在这个寻宝机器人原型的基础上（即：继承MazeRobot类），
    /// 利用run方法操控机器人，以及利用doAfterStop委托事件感知未知地形，
    /// 以补充在迷宫地图中自动寻宝的外挂逻辑（即：override autoRun方法）
    /// 让你的autoRun方法在机器人reset后，一旦被执行，就能够尽量快地在未知的迷宫地图中探索到宝物投放点；
    /// 
    /// 注意：
    /// 后台自动判题程序会自动载入不同复杂度的迷宫地图并执行autoRun以验证autoRun的功能是否满足效率和正确性的要求；
    /// 迷宫地图均为平面地图，路点规模在700*700范围内；请注意代码的执行效率
    /// </remarks>    
    public class MyMazeRobot : qaExam2014.Level_2_Lib.MazeRobot
    {        
        class Position
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public static bool operator ==(Position a,Position b)
            {
                return a.X == b.X && a.Y == b.Y;
            }

            public static bool operator !=(Position a,Position b)
            {
                return !(a == b);
            }

            public static Position operator +(Position a, Position b)
            {
                return new Position(a.X + b.X, a.Y + b.Y);
            }

            public static Position operator -(Position a, Position b)
            {
                return new Position(a.X - b.X, a.Y - b.Y);
            }

            public Position GetNewPosFromDir(Direction dir,int dist)
            {
                Position delta = new Position(0, 0);
                switch (dir)
                {
                    case Direction.down:
                        delta.Y = -dist;
                        break;
                    case Direction.left:
                        delta.X = -dist;
                        break;
                    case Direction.right:
                        delta.X = dist;
                        break;
                    case Direction.up:
                        delta.Y = dist;
                        break;
                    default:
                        break;
                }
                return new Position(X + delta.X, Y + delta.Y);
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(X).Append(",").Append(Y);
                return sb.ToString();
            }
        }

        class Maze
        {
            public enum GridType
            {
                Unknown
                ,Road
                ,Wall
                //,NoGrid
            }

            GridType[,] grid;
            int size;

            public Maze()
            {
                size=1400;
                grid = new GridType[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        grid[i, j] = GridType.Unknown;
                    }
                }
            }

            public GridType GetGrid(Position pos)
            {
                if (pos.X < size && pos.Y < size)
                    return grid[pos.X, pos.Y];
                else
                    return GridType.Unknown;
            }

            public void SetGrid(Position pos,GridType gt)
            {
                if (pos.X < size && pos.Y < size)
                    grid[pos.X, pos.Y] = gt;
            }
        }

        /// <summary>
        /// 请重写自动跑迷宫的逻辑：
        /// 1、规划好机器人的探索策略；
        /// 2、规划好机器人自动停机的处理逻辑；
        /// 最终能让机器人对象一旦调用autoRun就能自动在迷宫中找到目标位置
        /// </summary>
        public override void autoRun()
        {
            //throw new NotImplementedException("未实现");
            doAfterStop += new StopEventHandler(process);
            while (path.Count > 0 )
            {
                bool isDeadEnd = true;
                foreach (var dir in (Direction[])Enum.GetValues(typeof(Direction)))
                {
                    if (maze.GetGrid(currPos.GetNewPosFromDir(dir, 1)) == Maze.GridType.Unknown)
                    {
                        run(dir, 1);
                        switch (sr)
                        {
                            case StopReason.arrive:
                                currPos = currPos.GetNewPosFromDir(dir, rd);
                                maze.SetGrid(currPos, Maze.GridType.Road);
                                path.Push(currPos);
                                isDeadEnd = false;
                                break;
                            case StopReason.done:
                                return;
                            case StopReason.hitWall:
                                maze.SetGrid(currPos.GetNewPosFromDir(dir, rd + 1), Maze.GridType.Wall);
                                break;
                            default:
                                break;
                        }
                        if (!isDeadEnd)
                            break;
                    }
                }
                if (isDeadEnd)
                    GoBack();
            }
        }

        void GoBack()
        {
            Position target= path.Pop();
            if (target == new Position(-1, -1))
                return;
            Position delta = target - currPos;
            if (delta.X != 0)
            {
                if (delta.X > 0)
                    run(Direction.right, delta.X);
                else
                    run(Direction.left, -delta.X);
            }
            else
            {
                if (delta.Y> 0)
                    run(Direction.down, delta.Y);
                else
                    run(Direction.up, -delta.Y);
            }
            currPos = target;
        }

        void process(object sender, Level_2_Lib.MazeRobot.StopEventArgs args)
        {
            sr = args.stopReason;
            rd = args.runDistance;
        }

        Stack<Position> path;
        Maze maze;
        Position currPos;
        StopReason sr;
        int rd;

        public MyMazeRobot():base()
        {
            maze = new Maze();
            path = new Stack<Position>();
            currPos = new Position(700, 700);
            path.Push(new Position(-1, -1));
            path.Push(currPos);
        }
        
        /// <summary>
        /// 供各位同学使用的调试入口
        /// (真实的测试用例接口调用方式和下面代码类似)
        /// </summary>
        /// <param name="args">参数</param>
        public static void Main(string[] args)
        {
            MyMazeRobot mRobot = new MyMazeRobot();
            string runnerInfo = mRobot.sampleTestCase();
            Console.Write(runnerInfo);
            Console.Read();
        }

        
    }

}
