using Microsoft.EntityFrameworkCore;
using Tree.Data;
using Tree.DTOs;
using Tree.Interfaces;

namespace Tree.Repositories;

public class TreeRepository : ITreeRepository
{
    private readonly TreeDbContext _treeContext;

    public TreeRepository(TreeDbContext treeContext)
    {
        _treeContext = treeContext;
    }

    public async Task<TreeDTO> GetOrCreateTree(string name)
    {
        var tree = _treeContext.Trees.Where(x => x.Name == name).FirstOrDefault();

        if (tree == null)
        {
            var newTree = new Entities.Tree { Id = Guid.NewGuid(), Name = name };

            _treeContext.Add(newTree);
            _treeContext.Add(new Entities.Node
            {
                Name = name,
                ParentId = null,
                TreeId = newTree.Id
            });

            await _treeContext.SaveChangesAsync();
        }

        var root = _treeContext.Nodes.FirstOrDefault(x => x.Tree.Name == name && x.ParentId == null);

        return new TreeDTO
        {
            Id = root.Id,
            Name = root.Name,
            Children = GetTree(_treeContext, root.Id)
        };
    }

    static List<NodeDTO> GetTree( TreeDbContext _treeContext, Guid rootId)
    {
        var query = _treeContext.Nodes
            .Where(n => n.Id == rootId)
            .Select(n => new NodeDTO
            {
                Id = n.Id,
                NodeName = n.Name,
                Children = GetTree(_treeContext, n.Id)
            });

        return query.ToList();
    }
}
