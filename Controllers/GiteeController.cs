using Microsoft.AspNetCore.Mvc;

namespace DevOps.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GiteeController : GitBaseController
    {
        public GiteeController()
            : base("gitee.com", GetGitAccount("GiteeAccount"), GetGitPassword("GiteeAccount"))
        {

        }
    }
}
