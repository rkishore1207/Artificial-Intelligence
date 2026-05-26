using Microsoft.AspNetCore.Mvc;
using Services.FunctionCalling;
using Services.FunctionCalling.Models;
using Services.VectorEmbeddingAgent;

namespace AIAgent.Controllers
{
    [Route("api/aiagent")]
    [ApiController]
    public class AIAgentController : ControllerBase
    {
        private readonly IFunctionCalling _functionCalling;
        private readonly IVectorEmbedding _vectorEmbedding;

        public AIAgentController(IFunctionCalling functionCalling, IVectorEmbedding vectorEmbedding)
        {
            _functionCalling  = functionCalling;
            _vectorEmbedding = vectorEmbedding;
        }

        [HttpPost]
        [Route("functionCalling")]
        public async Task<ActionResult> FunctionCallingWithAgent(PromptRequest prompt)
        {
            var result = await _functionCalling.CallModelWithFunction(prompt.UserPrompt);
            return Ok(result);
        }

        [HttpPost]
        [Route("vectorEmbedding")]
        public async Task<ActionResult> VectorEmbedding(PromptRequest prompt)
        {
            var result = await _vectorEmbedding.GetEmbeddingForText(prompt.UserPrompt);
            return Ok(result);
        }
    }
}
