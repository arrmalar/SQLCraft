using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SQLCraft.API.Controllers.User
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionUserAnswerController : ControllerBase
    {
        public QuestionUserAnswerController() { 
            
        }
    }
}
