using System.Text;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace posConnector.bluetooth;

public class CommonBle 
{
    BluetoothClient client = new BluetoothClient();
    public CommonBle()
    {
        
    }
    
    public void DiscoverDevices()
    {
        BluetoothDeviceInfo[] devices = client.DiscoverDevicesInRange();

        foreach (var device in devices)
        {
            Console.WriteLine(device.DeviceName);
            if (device.DeviceName.Substring(0,4) == "MPOS" || device.DeviceName.Substring(0,2) == "0C")
            {
                Console.WriteLine($"{device.DeviceName} - {device.DeviceAddress}");
                ConnectToDevice(device.DeviceName, device.DeviceAddress);
            }
        }
    }

    public void ConnectToDevice(string deviceName, InTheHand.Net.BluetoothAddress deviceAddress) 
    {
        BluetoothEndPoint endPoint = new BluetoothEndPoint(deviceAddress, BluetoothService.SerialPort);
        client.Connect(endPoint);
    }

    public void SendData(string data)
    {
        byte[] message = Encoding.ASCII.GetBytes(data);
        Stream stream = client.GetStream();
        stream.Write(message, 0, message.Length);
    }
}