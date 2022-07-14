// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal.UnitTests/NodeMatrix.cs
// Created: 2022-05-28-5:56 PM
// *********************************************************************************************************************

namespace Levels.Universal.Tests.DataStructures {
	using Levels.UnityFramework.DataStructure.NodeMatrix;
	using Levels.UnityFramework.DataStructure.NodeMatrix.Datatypes;
	using Levels.UnityFramework.DataStructure.NodeMatrix.LinkLogic;

	using NUnit.Framework;

	[TestFixture]
	public class NodeMatrixBuilderTest {
		[SetUp]
		public void Setup() {
			new ReportPool();
		}

		// Test name convention.
		// MethodBeingTested_Scenario_ExpectedBehavior
		[Test]
		[TestCase(1, 1)]
		[TestCase(5, 1)]
		[TestCase(2, 2)]
		[TestCase(25, 25)]
		public void Build_MultipleSizes_ReturnValidNodeMatrix(int x, int y) {
			var holder = NodeMatrix<int>.Build((x, y));

			Assert.IsTrue(holder.GetNodes().Count == x * y &&
						  holder.ViewAllLinks().Count == (x - 1) * y + x * (y - 1));
		}

		[TestCase(5, 1, 1, 1, 2, 1)]
		[TestCase(5, 1, 2, 1, 3, 1)]
		[TestCase(5, 2, 1, 1, 1, 2)]
		public void IsLinked_IsLinkedFromTo_LinkExists(int x, int y, int xfrom, int yfrom, int xto, int yto) {
			var holder = NodeMatrix<int>.Build((x, y));

			Assert.IsTrue(holder.IsLinked((xfrom, yfrom), (xto, yto)));
		}

		[TestCase(1, 1)]
		public void ViewNodeAt_NodeExists_ReturnsNode(int x, int y) {
			var holder = NodeMatrix<int>.Build((1, 1));

			Assert.IsNotNull(holder.ViewNodeAt((x, y)));
		}

		[TestCase(2, 1)]
		public void ViewNodeAt_NodeDoesntExists_ReturnsNull(int x, int y) {
			var holder = NodeMatrix<int>.Build((1, 1));

			Assert.IsNull(holder.ViewNodeAt((x, y)));
		}

		[Test]
		public void ViewLinkFor_LinkExists_ReturnsLink() {
			var holder = NodeMatrix<int>.Build((1, 2));

			Assert.IsNotNull(holder.ViewLinkFor(holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 2))));
		}

		[Test]
		public void ViewLinkFor_LinkDoesntExists_ReturnsNull() {
			var holder = NodeMatrix<int>.Build((1, 2));

			Assert.IsNull(holder.ViewLinkFor(holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 3))).nodeA);
		}

		[TestCase(ConnectionTypes.Connected)]
		[TestCase(ConnectionTypes.Disconnected)]
		[TestCase(ConnectionTypes.Locked)]
		[TestCase(ConnectionTypes.Not)]
		public void IsLinkType_ConnectionTypeGiven_ReturnTrue(ConnectionTypes connection) {
			var holder = NodeMatrix<int>.Build((1, 2));

			holder.ChangeConnectionType((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 2)), connection));

			Assert.IsTrue(holder.IsLinkType(holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 2)), connection));
		}

		[Test]
		public void IsLinkType_ConnectionTypeGiven_ReturnFalse() {
			var holder = NodeMatrix<int>.Build((1, 2));

			holder.ChangeConnectionType((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 2)), ConnectionTypes.Connected));

			Assert.IsFalse(holder.IsLinkType(holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 2)), ConnectionTypes.Locked));
		}

		[Test]
		public void IsLinkType_LinkDoesntExist_ReturnFalse() {
			var holder = NodeMatrix<int>.Build((1, 2));

			holder.ChangeConnectionType((holder.ViewNodeAt((1, 3)), holder.ViewNodeAt((1, 2)), ConnectionTypes.Connected));

			Assert.IsFalse(holder.IsLinkType(holder.ViewNodeAt((1, 3)), holder.ViewNodeAt((1, 2)), ConnectionTypes.Locked));
		}

		[TestCase(ConnectionTypes.Connected)]
		[TestCase(ConnectionTypes.Disconnected)]
		[TestCase(ConnectionTypes.Locked)]
		[TestCase(ConnectionTypes.Not)]
		public void ChangeConnectionType_ConnectionTypeGiven_ConnectionChanged(ConnectionTypes connection) {
			var holder = NodeMatrix<int>.Build((1, 2));

			Assert.IsTrue(holder.ChangeConnectionType((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 2)), connection)));
		}

		[Test]
		public void ChangeConnectionType_ConnectionTypeGiven_ConnectionNotChanged() {
			var holder = NodeMatrix<int>.Build((1, 2));
			holder.ChangeConnectionType((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 2)), ConnectionTypes.Not));

			Assert.IsFalse(holder.ChangeConnectionType((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((1, 2)), ConnectionTypes.Connected)));
		}

		[TestCase(1, 2, 1, 1, 1)]
		[TestCase(2, 2, 1, 1, 2)]
		[TestCase(3, 2, 2, 1, 3)]
		[TestCase(3, 3, 2, 2, 4)]
		public void ViewLinksOn_LinksExist_CorrectNumberOfLinksReturned(int x, int y, int fromx, int fromy, int linkCount) {
			var holder = NodeMatrix<int>.Build((x, y));

			Assert.IsTrue(holder.ViewLinksOn(holder.ViewNodeAt((fromx, fromy))).Count == linkCount);
		}

		[TestCase(1, 2, 2, 2)]
		public void ViewLinksOn_NodeDoesntExist_ReturnsNull(int x, int y, int fromx, int fromy) {
			var holder = NodeMatrix<int>.Build((x, y));

			Assert.IsNull(holder.ViewLinksOn(holder.ViewNodeAt((fromx, fromy))));
		}

		[Test]
		public void TryLink_LinkExists_ReturnTrue() {
			var holder = NodeMatrix<int>.Build((3, 1));

			Assert.IsTrue(holder.TryLink((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((3, 1)), ConnectionTypes.Connected)));
		}

		[Test]
		public void TryLink_LinkExists_Returnfalse() {
			var holder = NodeMatrix<int>.Build((2, 1));

			Assert.IsFalse(holder.TryLink((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((2, 1)), ConnectionTypes.Connected)));
		}

		[Test]
		public void TryUnlink_LinkExists_ReturnTrue() {
			var holder = NodeMatrix<int>.Build((2, 1));

			Assert.IsTrue(holder.TryUnlink((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((2, 1)), ConnectionTypes.Connected)));
		}

		[Test]
		public void TryUnlink_LinkDoesntExist_ReturnFalse() {
			var holder = NodeMatrix<int>.Build((2, 1));

			Assert.IsFalse(holder.TryUnlink((holder.ViewNodeAt((1, 1)), holder.ViewNodeAt((3, 1)), ConnectionTypes.Connected)));
		}
	}
}