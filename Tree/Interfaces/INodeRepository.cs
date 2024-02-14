using Microsoft.AspNetCore.Mvc;
using Tree.DTOs;

namespace Tree.Interfaces;

public interface INodeRepository
{
    public void CreateNode(Guid treeId, Guid parentId, string nodeName);
}
