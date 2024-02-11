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
            _treeContext.Add(new Entities.Tree { Name = name });
            await _treeContext.SaveChangesAsync();
            tree = _treeContext.Trees.Where(x => x.Name == name).FirstOrDefault();
        }

        return new TreeDTO
        {
            Id = tree.Id,
            Name = tree.Name
        };
    }
}
