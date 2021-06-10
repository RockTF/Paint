namespace NewPaitnt.VectorModel
{
    public class Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void ChangeX(int x)
        {
            X = x;
        }
        public void ChangeY(int y)
        {
            Y = y;
        }
        public void Cnahge(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
