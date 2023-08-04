using System;
using UnityEngine;

namespace Player
{
    /**
     * === HeightController.cs ===
     * Description: C# script that is attached to Submit button
     * Function:
     *      - Generate JSON string by heights
     *      - Send JSON string to hardware
     */
    public class HeightSender : MonoBehaviour
    {
        public void OnClickSubmit()
        {
            for (var i = 0; i < GlobalManager.Pins.Count; i++)
            {
                var json = GetJsonFromHeights(i);
                print(json);
                SerialPortHandler.Write(json);
            }
        }


        [Serializable]
        private class PortJson
        {
            // JSON: {"i":1,"c":"motor","d":[40,30,20,10,40,30,20,10,40,30,20,10,40,30,20,10]}

            // i: [1, ..., n]
            // c: "motor"
            // d: [0, 1, 2, ..., 15, 16]
            public int i;
            public string c;
            public int[] d;
        }

        private string GetJsonFromHeights(int i)
        {
            // if all 0 => reset
            var heights = GlobalManager.Pins[i].GetHeight();
            var reset = true;
            foreach (var height in heights)
            {
                reset &= height == 0;
            }

            var jsonObj = new PortJson
            {
                i = i + 1, // NOTE: i+1
                c = reset ? "reset" : "motor",
                d = heights
            };
            var json = JsonUtility.ToJson(jsonObj);
            return " " + json;
        }
    }
}
