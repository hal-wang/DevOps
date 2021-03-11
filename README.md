# DevOps

WebApi for DevOps

## Function

When you push code to GitHub, you can use the API to build and deploy other projects automatically

## Environment

- Docker: to running other projects
- git: to clone your repositories
- windows/linux

## Usage

1. Edit `appsettings.json` and change the `GitAccount`
   - GitAccount/GitHub: your github account, if you use the github
   - GitAccount/Gitee: your gitee account, if you use the gitee
1. Add User Environment Variables
   - GitHubPassword: your github password, if you use the github
   - GiteePassword: your gitee password, if you use the gitee
1. Deploy this WebApi Server
1. Add Webhooks to repository in GitHub/Gitee, the url is the path to invoke api, like `https://domain.com/github/test/v1/443`
