using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace EifelMono.Extensions
{
    public class Select
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

        public string ToText(object obj)
        {
            return ToBase64(JsonConvert.SerializeObject(obj, JsonSerializerSettings));
        }

        public object FromText(string textobj)
        {
            return JsonConvert.DeserializeObject<object>(FromBase64(textobj), JsonSerializerSettings);
        }
        #endregion

        #region Output
        protected Action<string> m_OnOutput { get; set; } = null;
        public Select OnOutput(Action<string> action)
        {
            m_OnOutput = action;
            return this;
        }

        public void Output(object obj)
        {
            m_OnOutput.SafeInvoke(ToText(obj));
        }
        #endregion

        #region Input
        protected Dictionary<Type, Action<object, Select>> Cases = new Dictionary<Type, Action<object, Select>>();
        public Select Case<T>(Action<T, Select> action) where T : class
        {
            var objType = typeof(T);
            if (!Cases.ContainsKey(objType))
                Cases.Add(objType, null);
            Cases[objType] = (obj, select) => action((T)obj, select);
            return this;
        }

        public Select Case<T>(Action<T> action) where T : class
        {
            var objType = typeof(T);
            if (!Cases.ContainsKey(objType))
                Cases.Add(objType, null);
            Cases[objType] = (obj, select) => action((T)obj);
            return this;
        }

        protected Action<object, Select> m_OnDefaultObjectSelect = null;
        protected Action<object> m_OnDefaultObject = null;
        public Select Default(Action<object, Select> action)
        {
            m_OnDefaultObjectSelect = action;
            return this;
        }

        public Select Default(Action<object> action)
        {
            m_OnDefaultObject = action;
            return this;
        }

        public void Input(string text)
        {
            Input(FromText(text));
        }
        public void Input(object obj)
        {
            var objType = obj.GetType();
            if (Cases.ContainsKey(objType))
                Cases[objType].SafeInvoke(obj, this);
            else
            {
                m_OnDefaultObjectSelect.SafeInvoke(obj, this);
                m_OnDefaultObject.SafeInvoke(obj);
            }
        }

        public void InputUnitTest(object obj)
        {
            Input(ToText(obj));
        }

        #endregion
    }
}

