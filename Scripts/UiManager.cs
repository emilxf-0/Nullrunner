using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using RenderingLibrary;
using NullRunner;

namespace NullRunner
{
    public class UiManager
    {
        private GraphicalUiElement _gumScreen;
        private GraphicalUiElement _runnerZone;
        private GraphicalUiElement _corpZone;
        private GraphicalUiElement _card;

        public void Init()
        {
            //initialize Gum UI

            var gumProject = GumProjectSave.Load("gum/ui.gumx", out GumLoadResult result);
            ObjectFinder.Self.GumProjectSave = gumProject;
            gumProject.Initialize();

            // This assumes that your project has at least 1 screen
            _gumScreen = gumProject.Screens.First().ToGraphicalUiElement(SystemManagers.Default, addToManagers: true);
            _runnerZone = _gumScreen.GetGraphicalUiElementByName("RunnerZone");
            
            var componentSave = ObjectFinder.Self.GumProjectSave.Components
                .First(item => item.Name == "CardInstance");

            _card = componentSave.ToGraphicalUiElement(SystemManagers.Default, addToManagers: true);
            // the componentRuntime can be modified here

            Debug.WriteLine(_runnerZone);
            _card.Visible = true; 
        
            if (_card == null)
            {
                throw new Exception("Could not find the card in the UI");
            }
          


        }


        public void Update()
        {
            _runnerZone.Y -= 1;

            _card.X += 1;
       
        }
    }
}
