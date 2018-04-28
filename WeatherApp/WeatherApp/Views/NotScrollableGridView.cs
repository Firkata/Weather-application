using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Util;
using Java.Lang;

namespace WeatherApp.Views
{
    class NotScrollableGridView : GridView
    {
        public NotScrollableGridView(Context context) : base(context)
        {
        }

        public NotScrollableGridView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public NotScrollableGridView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int heightSpec;

            if (LayoutParameters.Height == LayoutParams.WrapContent)
            {
                // The great Android "hackatlon", the love, the magic.
                // The two leftmost bits in the height measure spec have
                // a special meaning, hence we can't use them to describe height.
                heightSpec = MeasureSpec.MakeMeasureSpec(Integer.MaxValue >> 2, MeasureSpecMode.AtMost);
            }
            else
            {
                heightSpec = heightMeasureSpec;
            }

            base.OnMeasure(widthMeasureSpec, heightSpec);
        }
    }
}