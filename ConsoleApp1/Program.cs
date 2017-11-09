using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        /* Classe de test  */
        static void Main(string[] args)
        {
            Light lamp = new Light();
            Command switchUp = new TurnOnCommand(lamp);
            Command switchDown = new TurnOffCommand(lamp);

            Switch s = new Switch(switchUp, switchDown);

            s.flipUp();
            s.flipDown();
        }

        /* Invocateur */
        public class Switch
        {
            private Command flipUpCommand;
            private Command flipDownCommand;

            public Switch(Command flipUpCmd, Command flipDownCmd)
            {
                this.flipUpCommand = flipUpCmd;
                this.flipDownCommand = flipDownCmd;
            }

            public void flipUp()
            {
                flipUpCommand.execute();
            }

            public void flipDown()
            {
                flipDownCommand.execute();
            }
        }

        /* Récepteur */
        public class Light
        {
            public Light() { }

            public void turnOn()
            {
                Console.WriteLine("The light is on");
            }

            public void turnOff()
            {
                Console.WriteLine("The light is off");
            }
        }

        /* Commande */
        public interface Command
        {
            void execute();
        }

        /* Commande concrète pour allumer la lumière */
        public class TurnOnCommand : Command
        {
            private Light theLight;

            public TurnOnCommand(Light light)
            {
                this.theLight = light;
            }

            public void execute()
            {
                theLight.turnOn();
            }
        }

        /* Commande concrète pour éteindre la lumière */
        public class TurnOffCommand : Command
        {
            private Light theLight;

            public TurnOffCommand(Light light)
            {
                this.theLight = light;
            }

            public void execute()
            {
                theLight.turnOff();
            }
        }
    }
}
