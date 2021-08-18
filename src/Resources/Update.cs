using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Update
{
    public class CheckForUpdate
    {
        public static async Task CheckGitHubNewerVersion()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("RSA-WPF"));
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("AdisonCavani", "RSA-WPF");
            var latest = releases[0];

            string latestGitHubVersion = releases[0].TagName;
            const string currentGithubVersion = "v1.2";

            int comparasion = String.Compare(currentGithubVersion, latestGitHubVersion);

            if (comparasion < 0)
            {
                MessageBox.Show("Need update");
            }
            else if (comparasion > 0)
            {
                MessageBox.Show("Version ahead");
            }
            else
            {
                MessageBox.Show("Up to date!");
            }
        }
    }
}
