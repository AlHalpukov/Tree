using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Tree.Data;
using Tree.DTOs;
using Tree.Entities;
using Tree.Interfaces;

namespace Tree.Repositories
{
    public class NodeRepository : INodeRepository
    {
        private readonly TreeDbContext _treeContext;

        public NodeRepository(TreeDbContext treeContext)
        {
            _treeContext = treeContext;
        }


        public void CreateNode(Guid treeId, Guid parentId, string nodeName)
        {
            if (_treeContext.Trees.FirstOrDefault(x => x.Id == treeId) is null)
            {
                throw new Exception("Tree not found");
            }

            if (_treeContext.Nodes.FirstOrDefault(x => x.TreeId == treeId) is null)
            {
                _treeContext.Add(new Node
                {
                    ParentId = null,
                    TreeId = treeId,
                    Name = nodeName
                }); ;

                _treeContext.SaveChangesAsync();
                return;
            }


            if (_treeContext.Nodes.FirstOrDefault(x => x.Id == parentId) is null)
            {
                throw new Exception("Parent Node not found");
            }

            _treeContext.Add(new Node
            {
                ParentId = parentId,
                TreeId = treeId,
                Name = nodeName
            }); ;

            _treeContext.SaveChangesAsync();
        }
    }
}
