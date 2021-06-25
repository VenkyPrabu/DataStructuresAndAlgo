using System.Collections.Generic;

namespace DataStructuresAndAlgo.Graph
{
    public class TreeNode
    {
        public int Id;
        public TreeNode ParentNode;
        public List<TreeNode> ChildrenNodes;  
        public TreeNode(int id){
            Id = id;
            ParentNode=null;
            ChildrenNodes = new List<TreeNode>();
        }
        public TreeNode(int id, TreeNode parent){
            Id=id;
            ParentNode=parent;
            ChildrenNodes = new List<TreeNode>();
        }        

        public TreeNode BuildTree(Dictionary<int, List<Edge>> Graph, TreeNode root){
            
            if(Graph.ContainsKey(root.Id)){
                foreach(var child in Graph[root.Id]){
                    //Avoid adding an edge pointing back to the parent.
                    if (root.ParentNode != null && child.To == root.ParentNode.Id){
                        continue;
                    }
                    TreeNode childNode = new TreeNode(child.To,root);
                    root.ChildrenNodes.Add(childNode);
                    BuildTree(Graph,childNode);
                }
            }
            return root;
        }

        public string Encode(TreeNode root){    
            //base case
            if(root == null){
                return "";
            }   
            //DFS - for each child go into 
            List<string> output=new List<string>();
            foreach(var child in root.ChildrenNodes){
                output.Add(Encode(child));
            }
            output.Sort();
            string outputString="";            
            foreach(var item in output){
                outputString=outputString+item.ToString();
            }
            return "("+ outputString + ")";
        }
    }
}