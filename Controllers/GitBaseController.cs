using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace DevOps.Controllers
{
    public abstract class GitBaseController : ControllerBase
    {
        private readonly string _domain;
        private readonly string _account;
        private readonly string _password;

        internal GitBaseController(string domain, string account, string password = null)
        {
            if (string.IsNullOrEmpty(domain)) throw new ArgumentNullException(nameof(domain));
            if (string.IsNullOrEmpty(account)) throw new ArgumentNullException(nameof(account));

            _domain = domain;
            _account = account;
            _password = password;
        }

        [HttpPost("{repos}/{version}/{port}")]
        public IActionResult Post(string repos, string version, int port)
        {
            if (string.IsNullOrEmpty(repos)) return BadRequest(new { message = "请输入仓库" });
            if (port < 1 || port > 65535) return BadRequest(new { message = "请输入正确端口" });

            var folderPath = $"repos/{repos.ToLower()}";
            var containerName = $"{repos.ToLower()}-{port}{(string.IsNullOrEmpty(version) ? "" : $"-{version}")}";
            var cloneUrl = $"https://{(string.IsNullOrEmpty(_password) ? "" : $"{_account}:{_password}@")}{_domain}/{_account}/{repos}.git {folderPath}";

            Exec("git", $"clone {cloneUrl}");
            Exec("docker", $"stop {containerName}");
            Exec("docker", $"rm {containerName}");
            Exec("docker", $"rmi {repos.ToLower()}");
            Exec("docker", $"build ./{folderPath} -t {repos.ToLower()} -f ./{folderPath}/Dockerfile");
            Exec("docker", $"create -p {port}:{port} --name {containerName} {repos.ToLower()}");
            Exec("docker", $"start {containerName}");

            return NoContent();
        }

        private void Exec(string fileName, string arguments)
        {
            using var proc = Process.Start(fileName, arguments);
            if (proc == null) throw new Exception("Can not exec");
            proc.WaitForExit();
        }

        internal static string GetGitAccount(string variableName)
        {
            var variable = Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(variable)) return null;

            var strs = variable.Split('/');
            if (strs.Length < 1) return null;
            else return strs[0];
        }

        internal static string GetGitPassword(string variableName)
        {
            var variable = Environment.GetEnvironmentVariable(variableName, EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(variable)) return null;

            var strs = variable.Split('/');
            if (strs.Length < 2) return null;
            else return strs[1];
        }
    }
}
