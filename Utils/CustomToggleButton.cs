using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using QTLProject.Enums;

namespace QTLProject.Utils
{
    public class CustomToggleButton : Control
    {

        private float diameter;
        private MyRectangle rect;
        private RectangleF circle;
        private bool isON;
        private float artis;
        private Color borderColor;
        private bool textEnabled;
        private string OnTex = "";
        private string OffTex = "";
        private Color OnCol;
        private Color OffCol;
        private Timer paintTicker = new Timer();
        public event EventHandler SliderValueChanged;


        public CustomToggleButton()
        {
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;
            this.artis = 4f;
            this.diameter = 30f;
            this.rect = new MyRectangle(2f * this.diameter, this.diameter + 2f, this.diameter / 2f, 1f, 1f);
            this.circle = new RectangleF(1f, 1f, this.diameter, this.diameter);
            this.isON = false;
            this.textEnabled = true;
            this.borderColor = ColorConstants.tableBackgroundColor;
            this.paintTicker.Tick += new EventHandler(this.paintTicker_TIck);
            this.paintTicker.Interval = 1;
            this.OnCol = ColorConstants.highliteColor;
            this.OffCol = ColorConstants.tableBackgroundColor;
            this.ForeColor = Color.White;
            this.OnTex = "ON";
            this.OffTex = "OFF";

        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.Invalidate();
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isON = !this.isON;
                this.IsOn = this.isON;
                base.OnMouseClick(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = (SmoothingMode)SmoothingMode.HighQuality;
            if (base.Enabled)
            {
                Pen pen;
                using (SolidBrush brush = new SolidBrush(this.isON ? this.OnColor : this.OffCol))
                {
                    e.Graphics.FillPath((Brush)brush, this.rect.Path);
                }

                using (pen = new Pen(this.BorderColor, 2f))
                {
                    e.Graphics.DrawPath(pen, this.rect.Path);
                }

                if (this.textEnabled)
                {
                    using (Font font = new Font("Arial", (8 + 2f * this.diameter) / 30f, (FontStyle)FontStyle.Regular))
                    {
                        SolidBrush b = new SolidBrush(this.ForeColor);
                        int height = TextRenderer.MeasureText(this.OnText, font).Height;
                        float num2 = (this.diameter - height) / 2f;
                        e.Graphics.DrawString(this.OnText, font, b, 5f, num2 + 1f);
                        height = TextRenderer.MeasureText(this.OffTex, font).Height;
                        num2 = (this.diameter - height) / 2f;
                        e.Graphics.DrawString(this.OffTex, font, b, this.diameter + 22f, num2 + 1f);
                    }
                    using (SolidBrush brush2 = new SolidBrush(Color.White))
                    {
                        e.Graphics.FillEllipse((Brush)brush2, this.circle);
                    }
                    using (pen = new Pen(Color.LightGray, 1.2f))
                    {
                        e.Graphics.DrawEllipse(pen, this.circle);
                    }
                }
                else
                {
                    using (SolidBrush brush3 = new SolidBrush(Color.White))
                    {
                        using (SolidBrush brush4 = new SolidBrush(Color.White))
                        {
                            e.Graphics.FillPath((Brush)brush3, this.rect.Path);
                            e.Graphics.FillEllipse((Brush)brush4, this.circle);
                            e.Graphics.DrawEllipse(Pens.DarkGray, this.circle);
                        }
                    }
                }
            }
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.Width = (base.Height - 2) * 2;
            this.diameter = base.Width / 2;
            this.artis = (4f * this.diameter) * 30f;
            this.rect = new MyRectangle(2f * this.diameter, this.diameter + 2f, this.diameter / 2f, 1f, 1f);
            this.circle = new RectangleF(!this.isON ? 1f : ((base.Width - this.diameter) - 1f), 1f, this.diameter, this.diameter);
            base.OnResize(e);

        }
        private void paintTicker_TIck(Object sender, EventArgs e)
        {
            float x = this.circle.X;
            if (this.isON)
            {
                if ((x + this.artis) <= ((base.Width - this.diameter) - 1f))
                {
                    x += this.artis;
                    this.circle = new RectangleF(x, 1f, this.diameter, this.diameter);
                    base.Invalidate();
                }
                else
                {
                    x = (base.Width - this.diameter) - 1f;
                    this.circle = new RectangleF(x, 1f, this.diameter, this.diameter);
                    base.Invalidate();
                    this.paintTicker.Stop();
                }
            }
            else if ((x - this.artis) >= 1f)
            {
                x -= this.artis;
                this.circle = new RectangleF(x, 1f, this.diameter, this.diameter);

            }
            else
            {
                x = 1f;
                this.circle = new RectangleF(x, 1f, this.diameter, this.diameter);
                base.Invalidate();
                this.paintTicker.Stop();

            }

        }

        public bool TextEnabled
        {
            get => this.textEnabled;
            set
            {
                this.textEnabled = value;
                base.Invalidate();
            }
        }
        public bool IsOn
        {
            get => this.isON;
            set
            {
                this.paintTicker.Stop();
                this.isON = value;
                this.paintTicker.Start();
                if (this.SliderValueChanged != null)
                {
                    this.SliderValueChanged(this,EventArgs.Empty);
                }
            }
        }
        public Color BorderColor
        {
            get => this.borderColor;
            set
            {
                this.borderColor = value;
                base.Invalidate();
            }
        }

        protected override Size DefaultSize
            => new Size(60, 35);
        
      
    
    
        public string OnText
        {
            get => this.OnTex;
            set
            {
                this.OnTex = value;
                base.Invalidate();
            }
        }
        public string OffText
        {
            get => this.OffTex;
            set
            {
                this.OffTex = value;
                base.Invalidate();
            }
        }

        public Color OnColor
        {
            get => this.OnCol;
            set
            {
                this.OnCol = value;
                base.Invalidate();

            }
        }

        public Color OffColor
        {
            get => this.OffCol;
            set
            {
                this.OffCol = value;
                base.Invalidate();
            }
        }
    
    }
}
