using System;
using System.Collections.Generic;
using System.Linq;

namespace EifelMono.Extensions
{
    public static partial class FlowExtensions
    {
        /// <summary>
        /// Flow.
        /// Its more a container
        /// </summary>
        public class Flow
        {
            public enum Operator
            {
                Or,
                And
            }

            public class Decision
            {
                public bool Value { get; set; }= false;

                public bool First { get; set; }= true;

                public Flow.Operator Operator { get; set; }= Flow.Operator.Or;

                public Flow.Operator PushOperator { get; set; }= Flow.Operator.And;

                public void CalcDecision(bool nextDecision, bool first= false)
                {
                    if (First || first)
                        Value = nextDecision;
                    else
                        switch (Operator)
                        {
                            case Flow.Operator.Or:
                                Value = Value | nextDecision;
                                break;
                            case Flow.Operator.And:
                                Value = Value & nextDecision;
                                break;
                        }
                    First = false;
                }

                public void InvertDecision()
                {
                    Value = !Value;
                }
            }

            public class Pipe<T>
            {
                public T CompareValue = default(T);

                public bool Executed { get; set; }= false;

                public List<Decision> Decisisons = new List<Decision>()
                {
                    new Decision()
                };

                public Decision CurrentDecision
                {
                    get
                    {
                        return Decisisons.Last();
                    }
                }

                public void PushDecision(Flow.Operator pushOperator)
                {
                    CurrentDecision.PushOperator = pushOperator;
                    Decisisons.Add(new Decision());
                }

                public void PopDecision()
                {
                    if (Decisisons.Count > 1)
                    {
                        Decision lastDecision = Decisisons[Decisisons.Count - 1];
                        Decisisons.Remove(lastDecision);
                        switch (CurrentDecision.PushOperator)
                        {
                            case Operator.Or:
                                CurrentDecision.Value = CurrentDecision.Value || lastDecision.Value;
                                break;
                            case Operator.And:
                                CurrentDecision.Value = CurrentDecision.Value && lastDecision.Value;
                                break;
                        }
                    }
                }

                public void PopDecisions()
                {
                    if (Decisisons.Count > 1)
                        PopDecision();
                }

                public object Data = null;

                public delegate void Action(Pipe<T> r);
            }
        }

        public static T CurrentValue<T>(this Flow.Pipe<T> pipe, Flow.Pipe<T>.Action action) 
        {
            if (action != null)
                action(pipe);
            return pipe.CompareValue;
        }

        public static T Pipe<T>(this T pipe, Func<T, T> func) 
        {
            if (func != null)
                pipe = func(pipe);
            return pipe;
        }
    }
}
