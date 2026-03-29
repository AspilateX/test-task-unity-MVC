namespace Game.Scripts.Models
{
    /// <summary>
    /// Определяет контракт электроприбора
    /// </summary>
    public interface IElectricalDevice
    {
        public float Resistance { get; }
        public float Power { get; }
    }
}