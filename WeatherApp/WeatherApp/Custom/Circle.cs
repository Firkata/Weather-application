using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;

namespace WeatherApp.Custom
{
    public class Circle : View
    {
        private static int startAnglePoint = 110;

        private Paint paint;
        private RectF rect;

        public float Angle { get; set; }

        public Circle(Context context, IAttributeSet attributeSet) : base(context, attributeSet)
        {
            int strokeWidth = 25;

            paint = new Paint();
            paint.AntiAlias = true;
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = strokeWidth;
            paint.Color = Color.White;

            //size 200x200 example
            rect = new RectF(strokeWidth, strokeWidth, 300 + strokeWidth, 300 + strokeWidth);

            //Initial Angle (optional, it can be zero)
            Angle = 0;
        }
        
        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawArc(rect, startAnglePoint, Angle, false, paint);
        }
    }
}