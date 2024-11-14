using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace PRN221_FMart_Project.SignalR
{
    [AllowAnonymous]
    public class SignalrServer : Hub
    {
    }
}
