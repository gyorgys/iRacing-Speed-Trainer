using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace IRacingSpeedTrainer
{
    internal struct ControllerData
    {
        public Guid Id;
        public string Name;

        override public string ToString()
        {
            return Name;
        }
    }

    internal class GameControllers : IDisposable
    {
        private DirectInput di = new DirectInput();
        private List<Joystick> joysticks = new List<Joystick>();
        private Keyboard? keyboard = null;
        private bool disposedValue;
        private IntPtr? windowHandle = null;

        private List<ControllerData> controllerData = new List<ControllerData>();

        public IList<ControllerData> ControllerData => this.controllerData;

        public event EventHandler? ControllersChanged = null;


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Unacquire();
                    this.di.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void ScanAndAquire(IntPtr mainFormHandle)
        {
            this.windowHandle = mainFormHandle;
            var devices = di.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
            int deviceId = 0;
            foreach (var device in devices)
            {
                var controller = new Joystick(di, device.InstanceGuid);
                joysticks.Add(controller);
                controller.SetCooperativeLevel(mainFormHandle, CooperativeLevel.Background | CooperativeLevel.NonExclusive);
                controller.Acquire();
                this.controllerData.Add(new IRacingSpeedTrainer.ControllerData { Id = device.InstanceGuid, Name = String.Format("Dev {0}: {1}", deviceId++, device.InstanceName) });
            }
            var keyboardDevice = di.GetDevices(DeviceClass.Keyboard, DeviceEnumerationFlags.AttachedOnly).First();
            if (keyboardDevice != null)
            {
                this.controllerData.Add(new IRacingSpeedTrainer.ControllerData { Id = keyboardDevice.InstanceGuid, Name = keyboardDevice.InstanceName });
                this.keyboard = new Keyboard(di);
                this.keyboard.SetCooperativeLevel(mainFormHandle, CooperativeLevel.Background | CooperativeLevel.NonExclusive);
                this.keyboard.Acquire();
            }
            else
            {
                this.keyboard = null;
            }
        }
        private void Unacquire()
        {
            foreach (var joystick in this.joysticks)
            {
                joystick.Unacquire();
                joystick.Dispose();
            }
            this.joysticks.Clear();
            this.keyboard?.Unacquire();
            this.keyboard?.Dispose();
            this.keyboard = null;
            this.controllerData.Clear();
        }

        private void RescanControllers()
        {
            this.Unacquire();
            if (this.windowHandle != null)
            {
                this.ScanAndAquire(this.windowHandle ?? IntPtr.Zero);
            }
            this.ControllersChanged?.Invoke(this, new EventArgs());
        }

        public List<string> GetInputs()
        {
            string text = "<none>";
            List<string> inputs = new List<string>();
            try
            {
                int deviceId = 0;
                foreach (var joystick in this.joysticks)
                {
                    joystick.Poll();
                    var state = joystick.GetCurrentState();
                    var buttons = state.Buttons;
                    var hat = state.PointOfViewControllers;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        if (buttons[i])
                        {
                            inputs.Add(String.Format("Dev {0} Btn {1}", deviceId, i));
                        }
                    }
                    deviceId++;
                }
                if (this.keyboard != null)
                {
                    this.keyboard.Poll();
                    var state = this.keyboard.GetCurrentState();
                    var keys = state.PressedKeys;
                    if (keys != null && keys.Count > 0)
                    {
                        var keyStrings = keys.Select(k => k.ToString()).ToList();
                        foreach (string keyString in keyStrings) {
                            inputs.Add(keyString);
                        }
                    }
                }
            }
            catch (SharpDX.SharpDXException ex)
            {
                if (ex.Descriptor.ApiCode == "InputLost")
                {
                    this.RescanControllers();
                    return new List<string>();
                }
                throw ex;
            }
            return inputs;
        }
    }
}
