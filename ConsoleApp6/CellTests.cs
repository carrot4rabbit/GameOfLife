using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp6
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void Test_Cell_CreatesNewCell()
        {
            Cell cell = new Cell();

            Assert.IsNotNull(cell);
        }

        [TestMethod]
        public void Test_Cell_SetCellState()
        {
            Cell cell = new Cell();

            cell.State = true;

            Assert.IsTrue(cell.State);
        }

        [TestMethod]
        public void Test_Cell_SetCellNeighbours()
        {
            Cell cell = new Cell();

            cell.Neighbours = 3;

            Assert.AreEqual(3, cell.Neighbours);
        }

        [TestMethod]
        public void Test_Evolve_CellHas0Neighbors_Dies()
        {
            Cell cell = new Cell();
            cell.Neighbours = 0;

            cell.Evolve();
            
            Assert.IsFalse(cell.State);
        }

        [TestMethod]
        public void Test_Evolve_CellHas1Neighbour_Dies()
        {
            Cell cell = new Cell();
            cell.Neighbours = 1;

            cell.Evolve();

            Assert.IsFalse(cell.State);
        }

        [TestMethod]
        public void Test_Evolve_CellHas2Neighbours_Lives()
        {
            Cell cell = new Cell();
            cell.Neighbours = 2;

            cell.Evolve();

            Assert.IsTrue(cell.State);
        }

        [TestMethod]
        public void Test_Evolve_LiveCellHas3Neighbours_Lives()
        {
            Cell cell = new Cell();
            cell.Neighbours = 3;
            cell.State = true;

            cell.Evolve();

            Assert.IsTrue(cell.State);
        }

        [TestMethod]
        public void Test_Evolve_DeadCellHas3Neighbours_IsBorn()
        {
            Cell cell = new Cell();
            cell.Neighbours = 3;
            cell.State = false;

            cell.Evolve();

            Assert.IsTrue(cell.State);
        }

        [TestMethod]
        public void Test_Evolve_CellHas4Neighbours_Dies()
        {
            Cell cell = new Cell();
            cell.Neighbours = 4;

            cell.Evolve();

            Assert.IsFalse(cell.State);
        }

        [TestMethod]
        public void Test_Evolve_CellHas5Neighbours_Dies()
        {
            Cell cell = new Cell();
            cell.Neighbours = 5;

            cell.Evolve();

            Assert.IsFalse(cell.State);
        }

    }
}
