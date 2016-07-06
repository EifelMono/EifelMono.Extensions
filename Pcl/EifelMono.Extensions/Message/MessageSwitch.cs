using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace EifelMono.Extensions
{
    public class MessageSwitch
    {
        #region Convert
        public bool UseBase64 { get; set; } = false;

        public JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        public string ToBase64(string text)
        {
            if (UseBase64)
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            else
                return text;
        }

        public string FromBase64(string text)
        {
            if (UseBase64)
            {
                var bytes = Convert.FromBase64String(text);
                return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            }
            else
                return text;
        }

        public string ToText(SwitchMessage message)
        {
            return ToBase64(JsonConvert.SerializeObject(message, JsonSerializerSettings));
        }

        public SwitchMessage FromText(string text)
        {
            return JsonConvert.DeserializeObject<SwitchMessage>(FromBase64(text), JsonSerializerSettings);
        }
        #endregion

        #region Output
        public Action<string> OnOutput { get; set; } = null;

        public void Output(SwitchMessage message)
        {
            if (OnOutput != null)
                OnOutput(ToText(message));
        }
        #endregion

        #region Input
        public Dictionary<Type, Action<SwitchMessage>> Cases = new Dictionary<Type, Action<SwitchMessage>>();
        public void Case<T>(Action<T> action) where T : SwitchMessage
        {
            var objType = typeof(T);
            if (!Cases.ContainsKey(objType))
                Cases.Add(objType, null);
            Cases[objType] = (obj) => action((T)obj);
        }

        public void Switch(string text)
        {
            var message = FromText(text);
            Switch(message);
        }

        public void Switch(SwitchMessage message, bool toText= false)
        {
            if (toText)
                Switch(ToText(message));
            else
            {
                var objType = message.GetType();
                if (Cases.ContainsKey(objType))
                {
                    var action = Cases[objType];
                    if (action != null)
                        action(message);
                } 
            }
        }

        #endregion
    }
}

