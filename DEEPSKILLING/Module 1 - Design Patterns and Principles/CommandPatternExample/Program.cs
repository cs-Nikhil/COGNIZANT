using CommandPatternExample.Commands;
using CommandPatternExample.Invokers;
using CommandPatternExample.Receivers;

namespace CommandPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light();

            ICommand lightOn = new LightOnCommand(light);
            ICommand lightOff = new LightOffCommand(light);

            RemoteControl remote = new RemoteControl();

            remote.SetCommand(lightOn);
            remote.PressButton();

            remote.SetCommand(lightOff);
            remote.PressButton();
        }
    }
}