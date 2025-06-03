using System;
using System.Linq;

namespace AddressableLoaderSystem.Runtime
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SceneFilterAttribute : FilterAttribute
    {
        public string[] SceneNames { get; }

        public SceneFilterAttribute(params string[] sceneNames)
        {
            SceneNames = sceneNames ?? Array.Empty<string>();
        }

        public bool Matches(string sceneName)
        {
            return SceneNames.Contains(sceneName, StringComparer.OrdinalIgnoreCase);
        }
    }
}