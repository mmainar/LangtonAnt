using NUnit.Framework;

namespace LangtonAnt
{
    [TestFixture]
    public class LangtonAntTests
    {
        [Test]
        public void OnCreatingAnt_ItFacesRight()
        {
            var ant = new LangtonAnt();
            Assert.AreEqual(Direction.RIGHT, ant.Direction);
        }

        [Test]
        public void OnCreatingAnt_ItIsAtOrigin()
        {
            var ant = new LangtonAnt();
            Assert.AreEqual(0, ant.CurrentRow);
            Assert.AreEqual(0, ant.CurrentCol);
        }

        [Test]
        public void WhiteSquare_FlipColor_ChangesToBlack()
        {
            var square = new Square(0, 0, Color.WHITE);

            square.FlipColor();

            Assert.AreEqual(Color.BLACK, square.Color);
        }

        [Test]
        public void BlackSquare_FlipColor_ChangesToWhite()
        {
            var square = new Square(0, 0, Color.BLACK);

            square.FlipColor();

            Assert.AreEqual(Color.WHITE, square.Color);
        }

        [Test]
        public void TopDirection_TurnClockwise_ChangesToRight()
        {
            var topDirection = Direction.TOP;

            var newDirection = topDirection.TurnClockwise();

            Assert.AreEqual(Direction.RIGHT, newDirection);
        }

        [Test]
        public void TopDirection_TurnAntiClockwise_ChangesToLeft()
        {
            var topDirection = Direction.TOP;

            var newDirection = topDirection.TurnAntiClockwise();

            Assert.AreEqual(Direction.LEFT, newDirection);
        }

        [Test]
        public void OnBlackSquare_FlipsColorTurnsAntiClockwiseAndMovesForward()
        {
            var col = 15;
            var row = 10;
            var sq = new Square(col, row, Color.BLACK);
            var ant = new LangtonAnt(Direction.RIGHT, sq);

            ant.Move();

            Assert.AreEqual(Color.WHITE, ant.CurrentSquare.Color);
            Assert.AreEqual(Direction.TOP, ant.Direction);
            Assert.AreEqual(col, ant.CurrentCol);
            Assert.AreEqual(row - 1, ant.CurrentRow);
        }

        [Test]
        public void OnWhiteSquare_FlipsColorTurnsClockwiseAndMovesForward()
        {
            var col = 15;
            var row = 10;
            var sq = new Square(col, row, Color.WHITE);
            var ant = new LangtonAnt(Direction.RIGHT, sq);

            ant.Move();

            Assert.AreEqual(Color.BLACK, ant.CurrentSquare.Color);
            Assert.AreEqual(Direction.BOTTOM, ant.Direction);
            Assert.AreEqual(col, ant.CurrentCol);
            Assert.AreEqual(row + 1, ant.CurrentRow);
        }
    }
}
