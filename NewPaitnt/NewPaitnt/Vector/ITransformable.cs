using System.Drawing;

namespace NewPaitnt.Vector
{
    interface ITransformable
    {
        abstract void Refresh(ref Graphics graphics);
        void Scale(float scaleFactor);
        void Rotate(double rotationAngle);
    }
}
