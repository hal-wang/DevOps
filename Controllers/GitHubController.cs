using Microsoft.AspNetCore.Mvc;

namespace DevOps.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GitHubController : GitBaseController
    {
        public GitHubController()
            : base("github.com", GetGitAccount("GitHubAccount"), GetGitPassword("GitHubAccount"))
        {

        }
    }
}
