using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Simulation.Models
{
    internal static class CompositionContainer
    {
        private const string ASSEMBLYNAME_REGEX_FILTER = @".*?\.(?:exe|dll)$";
        private static string _assemblyNameRegex = ASSEMBLYNAME_REGEX_FILTER;
        private static object _mefContainerLock = new object();
        private static CompositionHost _host;
        public static void Resolve(object target)
        {
            // SatisfyImports is not thread safe, use locking to prevent multiple calls at once
            lock (_mefContainerLock)
            {
                if (_host == null)
                {
                    InitializeContainer();
                }
                _host.SatisfyImports(target);
            }
        }
        /// <summary>
        /// Use this method to override the default import (filename) filter.
        /// </summary>
        /// <param name="fileNameFilterRegex">A regular expression string to filter the filename</param>
        /// <exception cref="InvalidOperationException">When the container is already created (<see cref="CompositionContainer.Resolve(object)"/> is already called)</exception>
        public static void SetImportFilter(string fileNameFilterRegex)
        {
            lock (_mefContainerLock)
            {
                if (_host != null)
                {
                    throw new InvalidOperationException("Composition was already created, can only override import filter when nothing is resolved yet.");
                }
                _assemblyNameRegex = fileNameFilterRegex;
            }
        }
        /// <summary>
        /// This should be used in test scenario's only.
        /// </summary>
        /// <param name="fileNameFilterRegex">A regular expression string to filter the filename</param>
        /// <param name="resetContainer">If true, will recreate the container with the new filter</param>
        public static void SetImportFilter(string fileNameFilterRegex, bool resetContainer)
        {
            lock (_mefContainerLock)
            {
                if (resetContainer)
                {
                    _host = null;
                }
                SetImportFilter(fileNameFilterRegex);
                if (resetContainer)
                {
                    InitializeContainer();
                }
            }
        }
        /// <summary>
        /// Reset filter to the original value
        /// </summary>
        public static void ResetImportFilter()
        {
            SetImportFilter(ASSEMBLYNAME_REGEX_FILTER, true);
        }

        private static AssemblyName GetAssemblyNameFromFileName(string f)
        {
            return new AssemblyName(Path.GetFileNameWithoutExtension(f));
        }

        private static bool IsFileAnAssemblyToLoad(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            return Regex.IsMatch(fileName, _assemblyNameRegex, RegexOptions.IgnoreCase);
        }

        private static string[] GetFilesInCurrentDirectory()
        {
            var baseDir = AppContext.BaseDirectory;
            var files = Directory.GetFiles(baseDir, "*", SearchOption.AllDirectories);
            return files;
        }

        private static void InitializeContainer()
        {
            var config = new ContainerConfiguration().WithAssemblies(GetAssemblies());
            _host = config.CreateContainer();
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            foreach (var assemblyName in GetAssemblyNamesToLoad())
            {
                Assembly asm = null;
                try
                {
                    asm = Assembly.Load(assemblyName);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                if (asm != null)
                {
                    yield return asm;
                }
            }
        }

        private static IEnumerable<AssemblyName> GetAssemblyNamesToLoad()
        {
            return GetFilesInCurrentDirectory()
                .Where(f => IsFileAnAssemblyToLoad(f))
                .Select(GetAssemblyNameFromFileName);
        }
    }
}
