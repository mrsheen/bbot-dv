using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace BBot.DebuggerVisualizers
{
    // TODO: Add the following to SomeType's definition to see this visualizer when debugging instances of SomeType:
    // 
    //  [DebuggerVisualizer(typeof(BBot))]
    //  [Serializable]
    //  public class SomeType
    //  {
    //   ...
    //  }
    // 
    /// <summary>
    /// A Visualizer for SomeType.  
    /// </summary>
    
    [DebuggerVisualizer(typeof(BBot.GameDefinitions.GameBoard))]
    public class GameBoardVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
                throw new ArgumentNullException("windowService");
            if (objectProvider == null)
                throw new ArgumentNullException("objectProvider");

            // TODO: Get the object to display a visualizer for.
            //       Cast the result of objectProvider.GetObject() 
            //       to the type of the object being visualized.
            object data = (object)objectProvider.GetObject();

            // TODO: Display your view of the object.
            //       Replace displayForm with your own custom Form or Control.
            using (Form displayForm = new Form())
            {
                displayForm.Text = data.ToString();
                windowService.ShowDialog(displayForm);
            }
        }

        // TODO: Add the following to your testing code to test the visualizer:
        // 
        //    BBot.TestShowVisualizer(new SomeType());
        // 
        /// <summary>
        /// Tests the visualizer by hosting it outside of the debugger.
        /// </summary>
        /// <param name="objectToVisualize">The object to display in the visualizer.</param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(GameBoardVisualizer));
            visualizerHost.ShowVisualizer();
        }
    }
}
