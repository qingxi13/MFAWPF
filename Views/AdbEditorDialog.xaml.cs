using System.Windows;
using MFAWPF.Utils;
using Microsoft.Win32;
using Window = HandyControl.Controls.Window;

namespace MFAWPF.Views;

public partial class AdbEditorDialog : Window
{
    public AdbEditorDialog()
    {
        InitializeComponent();
    }

    private void Load(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Title = "LoadFileTitle".GetLocalizationString(),
            Filter = "AllFilter".GetLocalizationString()
        };

        if (openFileDialog.ShowDialog().IsTrue())
        {
            AdbPath = openFileDialog.FileName;
        }
    }

    private void Save(object sender, RoutedEventArgs e)
    {
        Console.WriteLine($"{AdbName},{AdbPath},{AdbSerial}");
        DialogResult = true;
    }

    private void Cancel(object sender, RoutedEventArgs e)
    {
        Close();
    }

    public static readonly DependencyProperty AdbNameProperty =
        DependencyProperty.Register(
            nameof(AdbName),
            typeof(string),
            typeof(AdbEditorDialog),
            new FrameworkPropertyMetadata(
                "Simulator".GetLocalizationString(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string AdbName
    {
        get => (string)GetValue(AdbNameProperty);
        set => SetValue(AdbNameProperty, value);
    }

    public static readonly DependencyProperty AdbPathProperty =
        DependencyProperty.Register(
            nameof(AdbPath),
            typeof(string),
            typeof(AdbEditorDialog),
            new FrameworkPropertyMetadata(
                string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string AdbPath
    {
        get => (string)GetValue(AdbPathProperty);
        set => SetValue(AdbPathProperty, value);
    }

    public static readonly DependencyProperty AdbSerialProperty =
        DependencyProperty.Register(
            nameof(AdbSerial),
            typeof(string),
            typeof(AdbEditorDialog),
            new FrameworkPropertyMetadata(
                string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string AdbSerial
    {
        get => (string)GetValue(AdbSerialProperty);
        set => SetValue(AdbSerialProperty, value);
    }
}