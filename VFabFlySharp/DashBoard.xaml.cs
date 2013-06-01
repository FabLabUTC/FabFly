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
    /// Logique d'interaction pour DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        public double Angle
        {
            get
            {
                return (LayoutRoot.RenderTransform as RotateTransform).Angle / 180 * Math.PI;
            }
            set
            {
                (LayoutRoot.RenderTransform as RotateTransform).Angle = value * 180 / Math.PI;
            }
        }
        public DashBoard()
        {
            InitializeComponent();
        }
    }
}
