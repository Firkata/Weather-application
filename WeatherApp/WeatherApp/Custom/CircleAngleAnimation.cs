
using Android.Views.Animations;

namespace WeatherApp.Custom
{
    public class CircleAngleAnimation : Animation
    {
        private Circle circle;

        private float oldAngle;
        private float newAngle;

        public CircleAngleAnimation(Circle circle, int newAngle)
        {
            this.oldAngle = circle.Angle;
            this.newAngle = newAngle;
            this.circle = circle;
        }

        protected override void ApplyTransformation(float interpolatedTime, Transformation t)
        {
            base.ApplyTransformation(interpolatedTime, t);
            float angle = oldAngle + ((newAngle - oldAngle) * (interpolatedTime));

            circle.Angle = angle;
            circle.RequestLayout();
        }
    }
}