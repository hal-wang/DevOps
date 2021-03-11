using Microsoft.AspNetCore.Mvc;
using System;

namespace DevOps.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GitHubController : GitBaseController
    {
        public GitHubController()
            : base("github.com", ConfigHelper.Instance.Get<string>("GitAccount:GitHub"), Environment.GetEnvironmentVariable("GitHubPassword", EnvironmentVariableTarget.User))
        {

        }
    }
}
