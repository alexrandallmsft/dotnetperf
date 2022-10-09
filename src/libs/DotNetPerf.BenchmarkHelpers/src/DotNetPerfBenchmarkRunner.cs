using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

using Perfolizer.Horology;

namespace DotNetPerf.BenchmarkHelpers
{
    public static class DotNetPerfBenchmarkRunner
    {
        public static void Run(Type programType, string[] args, string relativeArtifactsPath)
        {
#if DEBUG
            throw new InvalidOperationException("It is invalid to run tests in debug mode.");
#endif

            string artifactsPathBeforeGetFullPath =
                Environment.CurrentDirectory +
                "\\" +
                relativeArtifactsPath.Replace("/", "\\");
            string artifactsPath = Path.GetFullPath(artifactsPathBeforeGetFullPath);
            if (!Directory.Exists(artifactsPath))
            {
                throw new DirectoryNotFoundException(
                    "The directory \"" +
                    artifactsPath +
                    "\" was not found. You must create it manually (this is for safety).");
            }

            BenchmarkSwitcher
                .FromAssembly(programType.Assembly)
                .Run(args, ManualConfig.CreateEmpty()

                // derived from https://github.com/dotnet/performance/blob/main/src/harness/BenchmarkDotNet.Extensions/RecommendedConfig.cs
                // 6/6/2022

                .AddJob(Job.Default
                    .WithWarmupCount(1) // 1 warmup is enough for our purpose
                    .WithIterationTime(TimeInterval.FromMilliseconds(250)) // the default is 0.5s per iteration, which is slighlty too much for us
                    .WithMinIterationCount(15)
                    .WithMaxIterationCount(20) // we don't want to run more that 20 iterations
                    .DontEnforcePowerPlan() // make sure BDN does not try to enforce High Performance power plan on Windows

                    .WithGcServer(true)
                    .WithPlatform(Platform.X64)
                    )

                .AddDiagnoser(MemoryDiagnoser.Default) // MemoryDiagnoser is enabled by default

                .AddDiagnoser(new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(
                    maxDepth: 1,
                    exportGithubMarkdown: true,
                    printSource: true
                    )))

                .AddDiagnoser(new InliningDiagnoser(
                    logFailuresOnly: true,
                    filterByNamespace: true))

                .AddAnalyser(DefaultConfig.Instance.GetAnalysers().ToArray()) // copy default analysers
                .AddLogger(ConsoleLogger.Default) // log output to console
                .AddValidator(DefaultConfig.Instance.GetValidators().ToArray()) // copy default validators
                .AddColumnProvider(DefaultColumnProviders.Instance) // display default columns (method name, args etc)
                .WithSummaryStyle(SummaryStyle.Default.WithMaxParameterColumnWidth(36)) // the default is 20 and trims too aggressively some benchmark results
                .AddExporter(MarkdownExporter.GitHub) // export to GitHub markdown
                .AddExporter(JsonExporter.Full) // make sure we export to Json
                .WithArtifactsPath(artifactsPath)

                );
        }
    }
}
