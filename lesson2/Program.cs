using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson2
{
    public class TestClass
    {
        [Benchmark]
        public void ContainerIntEx1()
        {
            Container<object> container = new Container<object>();
            for (int i = 0; i < 1000000; i++)
            {
                IntEx1 integer = new IntEx1(i);
                container.Add(integer, new object());
            }
        }

        [Benchmark]
        public void ContainerIntEx2()
        {
            Container<object> container = new Container<object>();
            for (int i = 0; i < 1000000; i++)
            {
                IntEx2 integer = new IntEx2(i);
                container.Add(integer, new object());
            }
        }

        [Benchmark]
        public void ContainerIntEx3()
        {
            Container<object> container = new Container<object>();
            for (int i = 0; i < 1000000; i++)
            {
                IntEx3 integer = new IntEx3(i);
                container.Add(integer, new object());
            }
        }

        [Benchmark]
        public void ContainerWithCollisions()
        {
            Container<object> container = new Container<object>();
            for (int i = 0; i < 1000000; i++)
            {
                IntBad integer = new IntBad(i);
                container.Add(integer, new object());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TestClass>();
        }
    }
}

