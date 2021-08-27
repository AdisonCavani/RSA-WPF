using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Update
{
    public class CheckForUpdate
    {
        public static async Task<int> CheckGitHubNewerVersion()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("RSA-WPF"));
            // Get all releases
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("AdisonCavani", "RSA-WPF");
            // Get latest release
            var latest = releases[0];

            // Get latest release tag name
            string latestGitHubVersion = releases[0].TagName;
            // Current app version
            const string currentGithubVersion = "v1.2";

            // Compare versions
            int comparasion = string.Compare(currentGithubVersion, latestGitHubVersion);

            return comparasion;
        }

        public static async Task<string> GetLatestRelease()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("RSA-WPF"));
            // Get all releases
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("AdisonCavani", "RSA-WPF");
            // Get latest release
            var latest = releases[0];

            return releases[0].TagName;
        }
    }
}
