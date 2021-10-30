using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GalaxyLib.Msg;

namespace GalaxyLib.AppCommands
{
    public class KeyMap : BaseSubject
    {
        public Dictionary<string, Tuple<string, AppCommand>> GestureDictionary { get; set; }

        public KeyMap(Simulation sim)
        {
            // default gesture map
            GestureDictionary = new Dictionary<string, Tuple<string, AppCommand>>();
            SetGesture("SpeedUp", "A", new SpeedUpCommand(sim));
            SetGesture("SpeedDown", "S", new SpeedDownCommand(sim));
            SetGesture("Pause", "P", new PauseCommand(sim));
            SetGesture("Bookmark", "B", new RevertCommand(sim));
        }

        public void SetGesture(string feature, string gesture, AppCommand command)
        {
            GestureDictionary.Remove(feature);
            GestureDictionary.Add(feature, new Tuple<string, AppCommand>(gesture, command));
        }

        public void SetGesture(string feature, string gesture)
        {
            if (!GestureDictionary.TryGetValue(feature, out var keyValue))
            {
                return;
            }

            var cmd = keyValue.Item2;

            SetGesture(feature, gesture, cmd);
        }
        
        public void GesturePressed(string gesture)
        {
            var cmd = GestureDictionary.Where(x => x.Value.Item1.Equals(gesture, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.Value.Item2)
                .FirstOrDefault();

            if (cmd == null)
            {
                Console.WriteLine("Gesture not bound.");
                return;
            }

            Console.WriteLine($"Executed: {cmd.Feature}");
            cmd.Execute();
        }

        public static implicit operator DataTable(KeyMap map)
        {
            var dt = new DataTable();
            var commandCol = new DataColumn("Feature", typeof(string));
            var gestureCol = new DataColumn("Gesture", typeof(string));

            commandCol.ReadOnly = true;

            dt.Columns.Add(commandCol);
            dt.Columns.Add(gestureCol);
            
            foreach (var (feature, gesture) in map.GestureDictionary)
            {
                var dr = dt.NewRow();
                dr[0] = feature;
                dr[1] = gesture.Item1;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public bool ValidateGestures(IDictionary<string, string> gestures, List<string> validGestures, out KeyValuePair<string, string> firstInvalid)
        {
            firstInvalid = new KeyValuePair<string, string>();

            var invalidGestures = gestures.Where(keyValue =>
                    string.IsNullOrWhiteSpace(keyValue.Value) || !validGestures.Contains(keyValue.Value))
                .ToDictionary(x => x.Key, y => y.Value);

            if (invalidGestures.Count == 0) return true;

            firstInvalid = invalidGestures.First();
            return false;
        }

        public void SaveGestures(IDictionary<string, string> gestures)
        {
            foreach (var (feature, gesture) in gestures)
            {
                SetGesture(feature, gesture);
            }
        }
    }
}
