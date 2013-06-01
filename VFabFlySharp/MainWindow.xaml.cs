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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MotorPack Source;
        FabFlySharp.IMU VirtImu;
        DateTime LastUpdate;
        public MainWindow()
        {
            InitializeComponent();
            var Motor = new FourMotor() { _X_Y = new VirtualMotor(1000), _YX = new VirtualMotor(1000), XY = new VirtualMotor(1000), Y_X = new VirtualMotor(1000)};
            VirtImu = new FabFlySharp.VirtualIMU(Motor);
            Source = new MotorPack(Motor, VirtImu);
            Source.Speed = new Vector3(false);
            LastUpdate = DateTime.Now;
            CompositionTarget.Rendering += (s, e) =>
                {
                    TimeSpan Spacing = (DateTime.Now - LastUpdate);
                    LastUpdate = DateTime.Now;
                    Source.Update(Spacing);
                    VirtImu.Update(Spacing);
                    this.Speed.Vector = Source.Speed;
                    this.DB.LeftMotor.Content = (double)(Motor._X_Y.RPM + Motor.Y_X.RPM);
                    this.DB.RightMotor.Content = (double)(Motor.XY.RPM + Motor._X_Y.RPM);
                    this.DB.Angle = (double)this.VirtImu.Rotation.Y;
                    this.Spacing.Content = Spacing.TotalMilliseconds;
                };
        }

        private void SetSpeed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender == SpeedX) this.Source.Speed = new Vector3(false) { X = (decimal)e.NewValue, Y = this.Source.Speed.Y, Z = this.Source.Speed.Z };
            if (sender == SpeedY) this.Source.Speed = new Vector3(false) { X = this.Source.Speed.X, Z = (decimal)e.NewValue, Y = this.Source.Speed.Y };
        }
    }
}
