using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace EifelMono.Extensions
{
    public class MessageConverter
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

        public string ToText(Message message)
        {
            return ToBase64(JsonConvert.SerializeObject(message, JsonSerializerSettings));
        }

        public Message FromText(string text)
        {
            return JsonConvert.DeserializeObject<Message>(FromBase64(text), JsonSerializerSettings);
        }
        #endregion

        #region Output
        public Action<string> OnOutput { get; set; } = null;

        public void Output(Message message)
        {
            if (OnOutput != null)
                OnOutput(ToText(message));
        }
        #endregion

        #region Input
        public Dictionary<Type, Action<Message>> OnInputs = new Dictionary<Type, Action<Message>>();
        public void OnInut<T>(Action<T> action) where T : Message
        {
            var objType = typeof(T);
            if (!OnInputs.ContainsKey(objType))
                OnInputs.Add(objType, null);
            OnInputs[objType] = (obj) => action((T)obj);
        }

        public void Input(string text)
        {
            var obj = FromText(text);
            var objType = obj.GetType();
            if (OnInputs.ContainsKey(objType))
            {
                var action = OnInputs[objType];
                if (action != null)
                    action(obj);
            }
        }

        #endregion
    }
}

