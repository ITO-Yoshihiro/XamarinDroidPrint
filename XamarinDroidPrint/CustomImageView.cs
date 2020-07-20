using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamarinDroidPrint
{
    public class CustomImageView : ImageView
    {
        public CustomImageView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public CustomImageView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            var paint = new Paint
            {
                TextSize = 60,
                Color = Color.Red,
                AntiAlias = true
            };

            //canvas.DrawColor(Color.Gray);
            canvas.DrawText("名前を直接描画", 300, 570, paint);

        }
    }
}