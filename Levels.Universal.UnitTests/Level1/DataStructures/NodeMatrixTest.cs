// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal.UnitTests/NodeMatrix.cs
// Created: 2022-05-28-5:56 PM
// *********************************************************************************************************************

namespace Levels.Universal.Tests.DataStructures
{
    using Levels.UnityFramework.DataStructure.NodeMatrix;
    using Levels.UnityFramework.DataStructure.NodeMatrix.LinkLogic;
    using Levels.UnityFramework.Storage;
    using NUnit.Framework;

    [TestFixture]
    public class NodeMatrixBuilderTest
    {
        [SetUp]
        public void Setup()
        {
            new ReportPool();
        }
        
        // Test name convention.
        // MethodBeingTested_Scenario_ExpectedBehavior
        [Test]
        [TestCase(1, 1)]
        [TestCase(5, 1)]
        [TestCase(2, 2)]
        [TestCase(25, 25)]
        public void FillNodeMatrix_MultipleSizes_ReturnValidNodeMatrix(int x, int y)
        {
            var holder = NodeMatrix<int>.Build((x, y));
            
            Assert.IsTrue(holder.GetNodes().Count == x * y && 
                          holder.ViewAllLinks().Count == (x - 1) * y + x * (y - 1));
        }
    }
}