namespace MyGame.Shared
{
    public enum MoveDirection
    {
        Forward,
        Backward,
        Left,
        Right
    }

    public class Pion
    {
        public int X;
        public int Y;

        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Forward:
                    Y += 1;
                    break;
                case MoveDirection.Backward:
                    Y -= 1;
                    break;
                case MoveDirection.Left:
                    X -= 1;
                    break;
                case MoveDirection.Right:
                    X += 1;
                    break;
            }
        }

        public void MoveForward()  => Move(MoveDirection.Forward);
        public void MoveBackward() => Move(MoveDirection.Backward);
        public void MoveLeft()     => Move(MoveDirection.Left);
        public void MoveRight()    => Move(MoveDirection.Right);
    }
}
