using Microsoft.AspNetCore.Mvc;
using Tree.DTOs;
using Tree.Interfaces;

namespace Tree.Controllers;

[ApiController]
public class TreeController : ControllerBase
{
    private readonly ITreeRepository _treeService;

    public TreeController(ITreeRepository treeService)
    {
        _treeService = treeService;
    }

    public ITreeRepository TreeService { get; }

    [HttpPost("tree.get")]
    public Task<TreeDTO> GetOrCreateTree([FromQuery] string name)
    {
        return _treeService.GetOrCreateTree(name);
    }
}
