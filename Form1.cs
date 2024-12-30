using posConnector.bluetooth;

namespace posConnector;

public partial class Form1 : Form
{
    private CommonBle bluetoothHandler = new CommonBle();    
    public Form1()
    {
        InitializeComponent();
        bluetoothHandler.DiscoverDevices();
    }
}