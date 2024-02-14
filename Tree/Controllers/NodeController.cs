using Microsoft.AspNetCore.Mvc;
using Tree.DTOs;
using Tree.Interfaces;

namespace Tree.Controllers;

[ApiController]
[Route("")]
public class NodeController : ControllerBase
{
    private readonly INodeRepository _nodeRepository;

    public NodeController(INodeRepository nodeRepository)
    {
        _nodeRepository = nodeRepository;
    }

    [HttpPost("node.create")]
    public async Task<IActionResult> CreateNode([FromQuery] Guid treeId,
                                                [FromQuery] Guid parentId,
                                                [FromQuery] string nodeName)
    {
        _nodeRepository.CreateNode(treeId, parentId, nodeName);

        return Ok(StatusCodes.Status200OK);
    }
}
