using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SharpDX.DirectInput;

namespace IRacingSpeedTrainer
{
    internal struct ControllerInfo
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
        private Form? mainForm = null;
        private IntPtr mainFormHandle = IntPtr.Zero;
        private System.Threading.Timer? timer = null;
        private int inTimerFunc = 0;

        private List<ControllerInfo> connectedControllers = new List<ControllerInfo>();
        private HashSet<string> currentInputs = new HashSet<string>();

        public IReadOnlyList<ControllerInfo> ConnectedControllers => this.connectedControllers;
        public IReadOnlySet<string> CurrentInputs => this.currentInputs;

        public event EventHandler<IReadOnlyList<ControllerInfo>>? ControllersChanged = null;
        public event EventHandler<IReadOnlySet<string>>? InputsChanged = null;

        public bool IsListening { get; private set; }
        public bool IsMonitoredOnly { get; set; }
        public ISet<string> MonitoredInputSet { get; init; } = new HashSet<string>();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.timer?.Dispose();
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

        public void StartListening(Form mainForm)
        {
            this.mainForm = mainForm;
            this.mainFormHandle = mainForm.Handle;
            this.ScanAndAquire();
            this.timer = new System.Threading.Timer(this.TimerFunc, null, 1000 / 30, 1000 / 30);
        }

        public void StopListening()
        {
            this.timer?.Dispose();
            this.timer = null;
            this.Unacquire();
        }

        private void TimerFunc(Object? stateInfo) {
            if (0 == Interlocked.CompareExchange(ref this.inTimerFunc, 1, 0))
            {
                try
                {
                    this.UpdateInputs(this.IsMonitoredOnly);
                }
                finally
                { 
                    this.inTimerFunc = 0; 
                }
            }
        }

        private void ScanAndAquire()
        {
            var devices = di.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
            int deviceId = 0;
            foreach (var device in devices)
            {
                var controller = new Joystick(di, device.InstanceGuid);
                joysticks.Add(controller);
                controller.SetCooperativeLevel(mainFormHandle, CooperativeLevel.Background | CooperativeLevel.NonExclusive);
                controller.Acquire();
                this.connectedControllers.Add(new IRacingSpeedTrainer.ControllerInfo { Id = device.InstanceGuid, Name = String.Format("Dev {0}: {1}", deviceId++, device.InstanceName) });
            }
            var keyboardDevice = di.GetDevices(DeviceClass.Keyboard, DeviceEnumerationFlags.AttachedOnly).First();
            if (keyboardDevice != null)
            {
                this.connectedControllers.Add(new IRacingSpeedTrainer.ControllerInfo { Id = keyboardDevice.InstanceGuid, Name = keyboardDevice.InstanceName });
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
            this.connectedControllers.Clear();
        }

        private void RescanControllers()
        {
            this.Unacquire();
            this.ScanAndAquire();
            this.mainForm?.Invoke(this.ControllersChanged, this, this.ConnectedControllers);
        }

        private void UpdateInputs(bool monitoredOnly)
        {
            var activeInputs = this.GetInputs();
            if (monitoredOnly)
            {
                activeInputs.IntersectWith(this.MonitoredInputSet);
            }
            if (!this.currentInputs.SetEquals(activeInputs))
            {
                this.currentInputs = activeInputs;
                if (this.mainForm != null)
                {
                    this.mainForm?.Invoke(this.InputsChanged, this, activeInputs);
                }
            }
        }

        private HashSet<string> GetInputs()
        {
            HashSet<string> inputs = new HashSet<string>();
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
                    return new HashSet<string>();
                }
                throw ex;
            }
            return inputs;
        }
    }
}
