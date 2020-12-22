using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace afmr.data.schemaMigration
{

    class Program
    {
        private static string _dbConnStr;
        private static bool _isUIInUse = false;
        private static string _rollbackVersion = string.Empty;
        private static SchemaMigrationConfig _migrationConfig = new SchemaMigrationConfig();

        static void Main(string[] args)
        {
            ParseArgs(args);

            LoadConfigs();

            if (string.IsNullOrWhiteSpace(_dbConnStr))
            {
                throw new InvalidOperationException("Connection string not found in configuration/appSetting");
            }

            Run();
        }

        private static void ParseArgs(string[] args)
        {
            var argHelpList = new List<string>() { "?", "-?", "help", "-help" };
            var argVersionList = new List<string>() { "version", "-version", "v", "-v" };
            var argRollbackList = new List<string>() { "rollback", "r", "-rollback", "-r" };
            var argUIList = new List<string>() { "-ui", "ui" };

            var argsList = (new List<string>(argHelpList));
            argsList.AddRange(argVersionList);
            argsList.AddRange(argRollbackList);
            argsList.AddRange(argUIList);

            if (args != null &&
                args.Length > 0)
            {
                if (!args.All(a => args.Contains(a.ToLower()) || int.TryParse(a, out var value)))
                {
                    throw new ArgumentException("Unknown arguments passed. Possible values are \n" + string.Join(", ", argsList.ToArray()));
                }
                else
                {
                    //UI
                    _isUIInUse = args.Any(a => argUIList.Contains(a.ToLower()));

                    //try help
                    if (args.Any(a => argHelpList.Contains(a.ToLower())))
                    {

                        Console.WriteLine("Valid argument inputs are " + string.Join(",", argsList));
                        GetInput();
                        return;
                    }

                    //try rollback
                    if (args.Any(a => argRollbackList.Contains(a.ToLower())))
                    {
                        var argIndex = Array.FindIndex(args, a => argVersionList.Contains(a.ToLower()));
                        if (long.TryParse(args.ElementAt(argIndex + 1), out var value) &&
                            value > 200228000000 &&
                            value < 999999999999)
                        {
                            _rollbackVersion = args.ElementAt(argIndex + 1);
                        }
                        else
                        {
                            Console.WriteLine("Version argument should exist and include a version number (-r -v 200228000000).");
                            Console.WriteLine("Args passed were " + string.Join(", ", args));
                            throw new ArgumentException("Version number not found in arguments passed.");
                        }
                    }
                }
            }
        }

        private static void LoadConfigs()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            _dbConnStr = configuration.GetConnectionString("MarketResearchDbSchemaDeploy");
            configuration.Bind(nameof(SchemaMigrationConfig), _migrationConfig);
        }

        private static void Run()
        {
            Console.WriteLine("Connection string: " + _dbConnStr);

            var serviceProvider = CreateServices();

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                // Instantiate the runner
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

                if (string.IsNullOrWhiteSpace(_rollbackVersion))
                {
                    runner.MigrateUp();
                }
                else
                {
                    Console.Write("Rollback back to Version " + _rollbackVersion);

                    runner.RollbackToVersion(long.Parse(_rollbackVersion));
                }
            }

            GetInput();
        }

        private static void GetInput()
        {
            if (_isUIInUse)
            {
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()

                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer2016()
                    .WithGlobalConnectionString(_dbConnStr)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(Program).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .Configure<RunnerOptions>(o =>
                {
                    o.TransactionPerSession = true;

                    var tagsList = new List<string>();
                    if (_migrationConfig.DevTag)
                        tagsList.Add(Tags.DevTag);
                    if (_migrationConfig.TestTag)
                        tagsList.Add(Tags.TestTag);
                    if (_migrationConfig.ProdTag)
                        tagsList.Add(Tags.ProdTag);

                    o.Tags = tagsList.ToArray();
                })
                // Build the service provider
                .BuildServiceProvider(false);
        }
    }
}
