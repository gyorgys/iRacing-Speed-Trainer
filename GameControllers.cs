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
        public string Id;
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

        private List<ControllerData> controllerData = new List<ControllerData>();

        public IList<ControllerData> ControllerData => this.controllerData;


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
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

        public void ScanAndAquire(Form mainForm)
        {
            var windowHandle = mainForm.Handle;
            var devices = di.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
            foreach (var device in devices)
            {
                var controller = new Joystick(di, device.InstanceGuid);
                joysticks.Add(controller);
                controller.SetCooperativeLevel(windowHandle, CooperativeLevel.Background | CooperativeLevel.NonExclusive);
                controller.Acquire();
                this.controllerData.Add(new IRacingSpeedTrainer.ControllerData { Id = device.InstanceGuid.ToString(), Name = device.InstanceName });
            }
            var keyboardDevice = di.GetDevices(DeviceClass.Keyboard, DeviceEnumerationFlags.AttachedOnly).First();
            if (keyboardDevice != null)
            {
                this.controllerData.Add(new IRacingSpeedTrainer.ControllerData { Id = keyboardDevice.InstanceGuid.ToString(), Name = keyboardDevice.InstanceName });
                this.keyboard = new Keyboard(di);
                this.keyboard.SetCooperativeLevel(windowHandle, CooperativeLevel.Background | CooperativeLevel.NonExclusive);
                this.keyboard.Acquire();
            }
            else
            {
                this.keyboard = null;
            }
        }

        public string GetState()
        {
            string text = "<none>";
            foreach (var joystick in this.joysticks)
            {
                joystick.Poll();
                var state = joystick.GetCurrentState();
                var buttons = state.Buttons;
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i])
                    {
                        text = String.Format("Gamepad {0} BTN:{1}", joystick.Information.InstanceName, i);
                    }
                }
            }
            if (this.keyboard != null)
            {
                this.keyboard.Poll();
                var state = this.keyboard.GetCurrentState();
                var keys = state.PressedKeys;
                if (keys != null && keys.Count > 0)
                {
                    var keyStrings = keys.Select(k => k.ToString()).ToList();
                    text = String.Format("{0} [{1}]", keyboard.Information.InstanceName, String.Join("+", keyStrings));
                }
            }
            return text;
        }
    }
}
