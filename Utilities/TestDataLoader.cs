using System.Text.Json;

namespace Playwright_Framework.Utilities
{

    public static class TestDataLoader
    {
        public static T Load<T>(string relativePath)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            var json = File.ReadAllText(fullPath);

            return JsonSerializer.Deserialize<T>(json)
                   ?? throw new InvalidOperationException($"Could not deserialize file: {relativePath}");
        }
    }
}
