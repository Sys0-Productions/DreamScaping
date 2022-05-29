// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal.UnitTests/NodeMatrix.cs
// Created: 2022-05-28-5:56 PM
// *********************************************************************************************************************

namespace Levels.Universal.Tests.DataStructures
{
    using Levels.UnityFramework.DataStructure.NodeMatrix;
    using Levels.UnityFramework.Storage;
    using NUnit.Framework;

    [TestFixture]
    public class NodeMatrixBuilderTest
    {
        // Test name convention.
        // MethodBeingTested_Scenario_ExpectedBehavior
        [Test]
        public void FillNodeMatrix_MultipleSizes_ValidNodeMatrixReturned()
        {
            // TODO: move this to DI.
            new ReportPool();
            
            var holder = new NodeMatrix<int>((1, 1));
            
            Assert.IsTrue(holder.GetNodes().Count == 1);

            holder = new NodeMatrix<int>((1, 2));
            
            Assert.IsTrue(holder.GetNodes().Count == 2);
            
            /*
            new NodeMatrix<Node<int>>((1, 3));
            new NodeMatrix<Node<int>>((1, 4));
            new NodeMatrix<Node<int>>((2, 1));
            new NodeMatrix<Node<int>>((3, 1));
            new NodeMatrix<Node<int>>((4, 1));
            new NodeMatrix<Node<int>>((4, 2));
            new NodeMatrix<Node<int>>((2, 4));
            new NodeMatrix<Node<int>>((4, 4));
            new NodeMatrix<Node<int>>((128, 4));
            new NodeMatrix<Node<int>>((128, 128));*/
        }
    }
}