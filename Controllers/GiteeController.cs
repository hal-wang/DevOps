using Microsoft.AspNetCore.Mvc;
using System;

namespace DevOps.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GiteeController : GitBaseController
    {
        public GiteeController()
            : base("gitee.com", ConfigHelper.Instance.Get<string>("GitAccount:Gitee"), Environment.GetEnvironmentVariable("GiteePassword", EnvironmentVariableTarget.User))
        {

        }
    }
}
