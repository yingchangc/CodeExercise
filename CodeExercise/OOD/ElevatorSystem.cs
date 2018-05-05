using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeExercise.OOD
{
    /// <summary>
    /// 708. Elevator system - OO Design 
    /// 题目：为一栋大楼设计电梯系统

    /// 不需要考虑超重的情况
    /// 该电梯系统目前只有1台电梯, 该楼共有n层
    /// 每台电梯有三种状态：上升，下降，空闲
    /// 当电梯往一个方向移动时，在电梯内无法按反向的楼层
    /// 我们提供了其他几个已经实现好的类，你只需要实现Elevator Class内的部分函数即可。
    /// 
    /// 
    /// 5           // 电梯一共有5层
    /// ExternalRequest(3, "Down")
    /// ExternalRequest(2, "Up")
    /// openGate()
    /// InternalRequest(1)
    /// closeGate()
    /// openGate()
    /// closeGate()
    /// openGate()
    /// closeGate()
    /// // 注意每行命令之后我们都会调用elevatorStatusDescription 函数，用于测试你是否处于一个正确的状态。
    /// 
    /// 你能看到的正确的内容应该是：
    /// 
    /// Currently elevator status is : DOWN.
    /// Current level is at: 1.
    /// up stop list looks like: [false, false, false, false, false].
    /// down stop list looks like:  [false, false, true, false, false].
    /// *****************************************
    /// 
    /// Currently elevator status is : DOWN.
    /// Current level is at: 1.
    /// up stop list looks like: [false, true, false, false, false].
    /// down stop list looks like:  [false, false, true, false, false].
    /// *****************************************
    /// 
    /// Currently elevator status is : DOWN.
    /// Current level is at: 3.
    /// up stop list looks like: [false, true, false, false, false].
    /// down stop list looks like:  [false, false, false, false, false].
    /// *****************************************
    /// 
    /// Currently elevator status is : DOWN.
    /// Current level is at: 3.
    /// up stop list looks like: [false, true, false, false, false].
    /// down stop list looks like:  [true, false, false, false, false].
    /// *****************************************
    /// 
    /// Currently elevator status is : DOWN.
    /// Current level is at: 3.
    /// up stop list looks like: [false, true, false, false, false].
    /// down stop list looks like:  [true, false, false, false, false].
    /// *****************************************
    /// 
    /// Currently elevator status is : DOWN.
    /// Current level is at: 1.
    /// up stop list looks like: [false, true, false, false, false].
    /// down stop list looks like:  [false, false, false, false, false].
    /// *****************************************
    /// 
    /// Currently elevator status is : UP.
    /// Current level is at: 1.
    /// up stop list looks like: [false, true, false, false, false].
    /// down stop list looks like:  [false, false, false, false, false].
    /// *****************************************
    /// 
    /// Currently elevator status is : UP.
    /// Current level is at: 2.
    /// up stop list looks like: [false, false, false, false, false].
    /// down stop list looks like:  [false, false, false, false, false].
    /// *****************************************
    /// 
    /// Currently elevator status is : IDLE.
    /// Current level is at: 2.
    /// up stop list looks like: [false, false, false, false, false].
    /// down stop list looks like:  [false, false, false, false, false].
    /// *****************************************
    /// </summary>
    public class ElevatorSystem
    {
        List<Elevator> elevators;

        Queue<Request> queuRequests;
        public ElevatorSystem()
        {
            elevators = new List<Elevator>();

            elevators.Add(new Elevator("elevator1"));
            elevators.Add(new Elevator("elevator2"));

            queuRequests = new Queue<Request>();

            Task.Run(() => ExecuteQueuTask());
        }


        private void ExecuteQueuTask()
        {
            while(true)
            {
                while (queuRequests.Count > 0)
                {
                    var req = queuRequests.Dequeue();
                    HandleRequestInternal(req);

                    Thread.Sleep(1000);
                }

                Thread.Sleep(1000);
            }
            
        }

        /// <summary>
        /// return elevator index
        /// </summary>
        /// <param name="level"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public Elevator HandleRequest(int level, Direction dir)
        {
            var request = new Request(level, dir);
            return HandleRequestInternal(request);
        }

        private Elevator HandleRequestInternal(Request request)
        {
            int numElevators = elevators.Count;
            for(int i = 0; i < numElevators; i++)
            {
                var elevator = elevators[i];
                var currSatus = elevator.GetDirectionStatus();
                if (currSatus == Direction.Idle || currSatus == request.dir)
                {
                    // check if passed level
                    if (elevator.HandleExternalRequest(request))
                    {
                        return elevator;
                    }
                }
            }

            queuRequests.Enqueue(request);
            return null;
        }
    }

    public class Elevator
    {
        private Controller controller;

        private Direction dirStatus = Direction.Idle;  // up, down, idle

        private int currLevel = 1 ;

        public string name;

        public Elevator(string name)
        {
            this.name = name;
            controller = new Controller(this);
        }

       

        public bool HandleExternalRequest(Request r)
        {
            if (controller.HasLevelToGo())
            {
                // if curr level has passed the request level, skip it
                if ((r.level > this.currLevel && dirStatus == Direction.UP) ||
                        (r.level < this.currLevel && dirStatus == Direction.Down))
                {
                    controller.SetLevelButton(r.level);
                    return true;
                }
                return false;
            }
            else
            {
                OccupyAndSetDirection(r);
                return true;
            }  
        }

        public void HandleInternalRequest(int level)
        {
            if (controller.HasLevelToGo())
            {
                int nextToGoLevel = controller.NextLevelToGo();
                if ((level > this.currLevel && dirStatus == Direction.UP) ||
                    (level < this.currLevel && dirStatus == Direction.Down))
                {
                    controller.SetLevelButton(level);
                }
                else
                {
                    throw new ArgumentException("Internal request direction is not the same as current elevator {0} direction.", name);
                }
            }
            else
            {
                Direction newDir = currLevel >= level ? Direction.Down : Direction.UP;
                OccupyAndSetDirection(new Request(level, newDir));
            }
            
        }
        public Direction GetDirectionStatus()
        {
            return dirStatus;
        }

        /// <summary>
        ///  update level
        /// </summary>
        public void OpenGate()
        {
            this.currLevel = controller.PopLevel();
            Console.WriteLine("[open]" + elevatorStatusDescription());
        }

        /// <summary>
        /// update direction
        /// </summary>
        public void CloseGate()
        {
            if (!controller.HasLevelToGo())
            {
                dirStatus = Direction.Idle;
            }

            Console.WriteLine("[close]" + elevatorStatusDescription());
        }

        // elevator is idle, ready for new directon request
        private void OccupyAndSetDirection(Request r)
        {
            dirStatus = r.dir;
            controller.SetLevelPlan(r.dir);
            controller.SetLevelButton(r.level);
        }

        

        private string elevatorStatusDescription()
        {

            string stops = string.Empty;

            string description = "Currently " + name + " status is : " + dirStatus
                    + ".\nCurrent level is at: " + currLevel
                    + ".\n Stop list looks like: " + controller.printLevels()
                    + ".\n*****************************************\n";
            return description;
        }
    }

    class AscComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    class DecComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    class Controller
    {
        private SortedSet<int> levelsToGo;
        private Elevator parent;

        public Controller(Elevator elevator)
        {
            parent = elevator;
        }

        public void SetLevelPlan(Direction dir)
        {
            if (Direction.UP == dir)
            {
                levelsToGo = new SortedSet<int>(new AscComparer());
            }
            else
            {
                levelsToGo = new SortedSet<int>(new DecComparer());
            }
        }

        public string printLevels()
        {
            string levels = string.Empty;
            foreach(var level in levelsToGo)
            {
                levels += "level " + level + ", ";
            }

            return levels;
        }

        public void SetLevelButton(int level)
        {
            if (!levelsToGo.Contains(level))
            {
                levelsToGo.Add(level);
            }  
        }

        public int NextLevelToGo()
        {
            if (levelsToGo.Count <= 0 )
            {
                throw new ArgumentOutOfRangeException("no next level to go for {0}", parent.name);
            }
            return levelsToGo.First();
        }

        public bool HasLevelToGo()
        {
            return levelsToGo !=null && levelsToGo.Count > 0;
        }

        public int PopLevel()
        {
            if (levelsToGo.Count <= 0)
            {
                throw new ArgumentOutOfRangeException("no levels to go at this {0} elevator", parent.name);
            }
            int fistLevel = levelsToGo.First();
            levelsToGo.Remove(fistLevel);

            return fistLevel;
        }
    }

    public class Request
    {
        public int level;
        public Direction dir;

        public Request(int leve, Direction dir)
        {
            this.level = leve;
            this.dir = dir;
        }
    }

    public enum Direction
    {
        UP=1,
        Down,
        Idle
    }
}
