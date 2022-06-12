using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace benchmarking_sample
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60)]
    [MarkdownExporter, HtmlExporter]
    public class LoopBenchmark
    {
        [Benchmark]
        [Arguments(100)]
        [Arguments(1000)]
        [Arguments(10000)]
        public void ForLoop(int max)
        {
            for (int i = 0; i < max; i++)
            {
            }
        }

        [Benchmark(Baseline = true)]
        [Arguments(100)]
        [Arguments(1000)]
        [Arguments(10000)]
        public void WhileLoop(int max)
        {
            int i = 0;
            while (i < max)
            {
                i++;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}