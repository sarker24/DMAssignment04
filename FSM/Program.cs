using System;
using System.Collections.Generic;
using System.Reflection;

namespace GFSM
{
    enum MyStates { Init, Foo, Bar, Empty, Finish };

    class MyFSM : FSM<MyStates>
    {
        public MyFSM() : base(MyStates.Init) { }

        void InitTransition(MyStates prev)
        {
            Console.Out.WriteLine(prev.ToString() + " -> Init");
        }

        void InitState()
        {
            Console.Out.WriteLine("Init State");
            Transition(MyStates.Foo);
        }

        void FooTransition(MyStates prev)
        {
            Console.Out.WriteLine(prev.ToString() + " -> Foo");
        }

        void FooState()
        {
            Console.Out.WriteLine("Foo State");
            Transition(MyStates.Bar);
        }

        // Simply omit empty transitions

        void BarState()
        {
            Console.Out.WriteLine("Bar State");
            Transition(MyStates.Finish);
        }

        // Simply omit empty states

        void FinishTransition(MyStates prev)
        {
            Console.Out.WriteLine(prev.ToString() + " -> Finish");
            Transition(MyStates.Bar);
        }

        void FinishState()
        {
            Console.Out.WriteLine("Finish State");
            Environment.Exit(0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyFSM fsm = new MyFSM();

          
            fsm.Transition(MyStates.Init);

           
            while (true)
            {
                fsm.StateDo();
            }
        }
    }
}
