#region

using EventSystem;

#endregion

namespace GameEvents
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGameEventListener
    {
        public void OnEventRaised();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGameEventListener<T> where T : EventInfo
    {
        public void OnEventRaised(T value);
    }
}