using FabFlySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VFabFlySharp
{
    /// <summary>
    /// Logique d'interaction pour arrow.xaml
    /// </summary>
    public partial class arrow : UserControl
    {
        public double Angle { 
            get
            {
                return 
                  ((this.LayoutRoot.RenderTransform as TransformGroup).Children[1] as RotateTransform).Angle / 180 * Math.PI;
            }
            set
            {
                var T = ((this.LayoutRoot.RenderTransform as TransformGroup).Children[1] as RotateTransform);
                T.Angle = -value * 180 / Math.PI;
            }
        }
        double RealLength;
        public double Length
        {
            get
            {
                return RealLength;
            }
            set
            {
                //((this.LayoutRoot.RenderTransform as TransformGroup).Children[0] as ScaleTransform).ScaleX = -value;
                this.Width = value * 30;
                RealLength = value;
            }
        }
        public Vector3 Vector
        {
            get
            {
                return new Vector3(false)
                {
                    X = (decimal)(this.Length * Math.Cos(this.Angle)),
                    Y = (decimal)(this.Length * Math.Sin(this.Angle))
                };
            }
            set
            {
                this.Length = (double)value.Length;
                this.Angle = (double)MathHelper.Atan2(value.Z, value.X);
            }
        }
        public arrow()
        {
            InitializeComponent();
            this.LayoutRoot.DataContext = this;
            CompositionTarget.Rendering += (s, e) => { this.Value.Content = this.Length; };
        }
    }
}
