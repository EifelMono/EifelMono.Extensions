using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace EifelMono.Extensions
{
    public class Select
    {
        #region Convert and Options

        #region Json
        // Attention !!! 
        // This is the Key!!!
        // Addes the namespace in the json string
        protected JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        public string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSerializerSettings);
        }

        public object FromJson(string text)
        {
            return JsonConvert.DeserializeObject<object>(text, JsonSerializerSettings);
        }
        #endregion

        #region Encrypt
        public bool UseEncrypt { get; set; } = false;

        public string ToEncrypt(string text)
        {
            // comming later this year
            if (UseEncrypt)
                return text;
            else
                return text;
        }

        public string FromEncrypt(string text)
        {
            // comming later this year
            if (UseEncrypt)
                return text;
            else
                return text;
        }
        #endregion

        #region Compress

        public bool UseCompress { get; set; } = false;

        public string ToCompress(string text)
        {
            // comming later this year
            if (UseCompress)
                return text;
            else
                return text;
        }

        public string FromCompress(string text)
        {
            // comming later this year
            if (UseCompress)
            {
                return text;
            }
            else
                return text;
        }

        #endregion

        #region Base64
        public bool UseBase64 { get; set; } = false;

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
        #endregion

        #region Text
        public Select Options(bool useEncrypt = false, bool useCompress = false, bool useBase64 = false)
        {
            UseEncrypt = useEncrypt;
            UseCompress = useCompress;
            UseBase64 = useBase64;
            return this;
        }

        public string ToText(object obj)
        {
            return ToBase64(ToCompress(ToEncrypt(ToJson(obj))));
        }

        public object FromText(string text)
        {
            return FromJson(FromEncrypt(FromCompress(FromBase64(text))));
        }
        #endregion

        #endregion

        #region Output
        protected Action<string, object, Select> m_OnOutput { get; set; } = null;
        public Select OnOutput(Action<string, object, Select> action)
        {
            m_OnOutput = action;
            return this;
        }

        public void Output(object obj)
        {
            m_OnOutput.SafeInvoke(ToText(obj), obj, this);
        }
        #endregion

        #region Flow
        protected Dictionary<Type, Action<object, Select>> Cases = new Dictionary<Type, Action<object, Select>>();

        public Select Case<T>(Action<T, Select> action) where T : class
        {
            var objType = typeof(T);
            if (!Cases.ContainsKey(objType))
                Cases.Add(objType, null);
            Cases[objType] = (obj, select) => action((T)obj, select);
            return this;
        }

        protected Action<object, Select> m_OnDefault = null;
        public Select Default(Action<object, Select> action)
        {
            m_OnDefault = action;
            return this;
        }

        #endregion

        #region Input
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
                m_OnDefault.SafeInvoke(obj, this);
        }

        public void InputUnitTest(object obj)
        {
            Input(ToText(obj));
        }

        #endregion
    }
}

